/*
 * * Created by Traesh for AshamaneProject (https://github.com/AshamaneProject)
 */
using Newtonsoft.Json;
using Sql;
using System;
using System.Collections.Generic;

namespace WowHeadParser.Entities
{
    class Item : Entity
    {
        struct ItemParsing
        {
            public int id;
            public string name;
            public string namedesc;
            public string description;
            public List<int> specs;
            public int level;
            public int classs;
            public int subclass;
            public int quality;
        }

        public struct ItemSpellParsing
        {
            public int id;
        }

        public struct ItemCreateItemParsing
        {
            public int id;
        }

        public struct ItemLootTemplateParsing
        {
            public int id;
            public int count;
            public int[] stack;
        }

        public struct ItemDroppedByTemplateParsing
        {
            public int id;
            public int count;
            public int outof;
        }

        public Item()
        {
            m_data.id = 0;
        }

        public Item(int id)
        {
            m_data.id = id;
        }

        public override String GetWowheadUrl()
        {
            return GetWowheadBaseUrl() + "/item=" + m_data.id + "&bonus=524";
        }

        public override bool ParseSingleJson(int id = 0)
        {
            if (m_data.id == 0 && id == 0)
                return false;
            else if (m_data.id == 0 && id != 0)
                m_data.id = id;

            bool optionSelected = false;
            String itemHtml = Tools.GetHtmlFromWowhead(GetWowheadUrl());

            String dataPattern = @"\$\.extend\(g_items\[" + m_data.id + @"\], (.+)\);";

            String itemDataJSon = Tools.ExtractJsonFromWithPattern(itemHtml, dataPattern);
            if (itemDataJSon != null)
            {
                m_data = JsonConvert.DeserializeObject<ItemParsing>(itemDataJSon);
            }

            if (IsCheckboxChecked("locale"))
                optionSelected = true;

            /* We currently don't use an item's quality for anything
            String qualityPattern = @"_\[" + m_data.id + @"\]" + "={\"name_frfr\":\"(?:.+?)\",\"quality\":([0-9])";

            String itemQuality = Tools.ExtractJsonFromWithPattern(itemHtml, qualityPattern);
            if (itemQuality != null)
            {
                Int32.TryParse(itemQuality, out m_data.quality);
            }
            */

            if (IsCheckboxChecked("create item"))
            {
                String itemSpellPattern = @"new Listview\(\{\n* *template: 'spell',\n* *id: 'reagent-for',\n* *name: WH.TERMS.reagentfor,\n* *tabs: 'tabsRelated',\n* *parent: 'lkljbjkb574',\n* *data: (.+),\n\}\);";

                String itemSpellJSon = Tools.ExtractJsonFromWithPattern(itemHtml, itemSpellPattern);
                if (itemSpellJSon != null)
                {
                    m_itemSpellDatas = JsonConvert.DeserializeObject<ItemSpellParsing[]>(itemSpellJSon);
                    optionSelected = true;
                }

                String itemCreatePattern = @"new Listview\(\{\n* *template: 'item',\n* *id: 'creates',\n* *name: WH.TERMS.creates,\n* *tabs: 'tabsRelated',\n* *parent: 'lkljbjkb574',\n* *sort:\['name'\],.*(?:\n)?.*data: (.+),\n\}\);";

                String itemCreateJSon = Tools.ExtractJsonFromWithPattern(itemHtml, itemCreatePattern);
                if (itemCreateJSon != null)
                {
                    m_itemCreateItemDatas = JsonConvert.DeserializeObject<ItemCreateItemParsing[]>(itemCreateJSon);
                    optionSelected = true;
                }
            }

            if (IsCheckboxChecked("loot"))
            {
                String itemLootTemplatePattern = @"new Listview\(\{\n* *template: 'item',\n* *id: 'contains',\n* *name: WH.TERMS.contains,\n* *tabs: 'tabsRelated',\n* *parent: 'lkljbjkb574',\n* *extraCols: \[Listview.extraCols.count, Listview.extraCols.percent\],\n* *sort:\['noteworthy', '-percent', 'name'\],\n* *computeDataFunc: Listview.funcBox.initLootTable,\n* *note: WH.sprintf\(WH.TERMS.itemopened_format, [0-9]+\),\n* *_totalCount: ([0-9]+),\n* *data: (.+),\n\}\);";

                String lootMaxCountStr = Tools.ExtractJsonFromWithPattern(itemHtml, itemLootTemplatePattern, 0);
                m_lootMaxCount = lootMaxCountStr != null ? Int32.Parse(lootMaxCountStr) : 0;
                String itemLootTemplateJSon = Tools.ExtractJsonFromWithPattern(itemHtml, itemLootTemplatePattern, 1);
                if (itemLootTemplateJSon != null)
                {
                    m_itemLootTemplateDatas = JsonConvert.DeserializeObject<ItemLootTemplateParsing[]>(itemLootTemplateJSon);
                    optionSelected = true;
                }
            }

            if (IsCheckboxChecked("dropped by"))
            {
                String itemDroppedByPattern = @"new Listview\(\{\n* *template: 'npc',\n* *id: 'dropped-by',\n* *name: WH.TERMS.droppedby,\n* *tabs: 'tabsRelated',\n* *parent: 'lkljbjkb574',\n* *hiddenCols: \['type'\],\n* *extraCols: \[Listview.extraCols.count, Listview.extraCols.percent, Listview.extraCols.popularity\],\n* *sort: \['-percent', '-count', 'name'\],\n* *computeDataFunc: Listview.funcBox.initLootTable,\n* *data: (.+),\n\}\);";

                String itemDroppedByJson = Tools.ExtractJsonFromWithPattern(itemHtml, itemDroppedByPattern);
                if (itemDroppedByJson != null)
                {
                    m_itemDroppedByDatas = JsonConvert.DeserializeObject<ItemDroppedByTemplateParsing[]>(itemDroppedByJson);
                    optionSelected = true;
                }
            }

            if (optionSelected)
                return true;
            else
                return false;
        }

        public override String GetSQLRequest()
        {
            String returnSql = "";

            if (m_data.id == 0 || isError)
                return returnSql;

            if (IsCheckboxChecked("locale"))
            {
                int localeIndex = Properties.Settings.Default.localIndex;

                if (localeIndex >= 1 && localeIndex <= 10)
                {
                    SqlBuilder m_itemLocalesBuilder = new SqlBuilder("item_sparse_locale", "ID", SqlQueryType.InsertOrUpdate);

                    String locale = "";

                    switch (localeIndex)
                    {
                        case 1:  locale = "koKR"; break;
                        case 2:  locale = "frFR"; break;
                        case 3:  locale = "deDE"; break;
                        case 4:  locale = "zhCN"; break;
                        case 5:  locale = "zhTW"; break;
                        case 6:  locale = "esES"; break;
                        case 7:  locale = "esMX"; break;
                        case 8:  locale = "ruRU"; break;
                        case 9:  locale = "ptPT"; break;
                        case 10: locale = "itIT"; break;
                    }

                    switch (GetVersion())
                    {
                        case "9.2.0.42560":
                        {
                            m_itemLocalesBuilder.SetFieldsNames("locale", "Description_lang", "Display3_lang", "Display2_lang", "Display1_lang", "Display_lang");
                            m_itemLocalesBuilder.AppendFieldsValue(m_data.id, locale, "", "", "", "", m_data.name.Substring(1) ?? "");
                        }
                        break;
                        default: // 8.x and 7.x
                        {
                            m_itemLocalesBuilder.SetFieldsNames("Name_" + locale);
                            m_itemLocalesBuilder.AppendFieldsValue(m_data.id, m_data.name.Substring(1) ?? "");
                        }
                        break;
                    }

                    returnSql += m_itemLocalesBuilder.ToString() + "\n";
                }
            }

            if (IsCheckboxChecked("create item") && m_itemCreateItemDatas != null)
            {
                m_spellLootTemplateBuilder = new SqlBuilder("spell_loot_template", "entry", SqlQueryType.InsertIgnore);

                m_spellLootTemplateBuilder.SetFieldsNames("Item", "Reference", "Chance", "QuestRequired", "LootMode", "GroupId", "MinCount", "MaxCount", "Comment");

                foreach (ItemCreateItemParsing itemLootData in m_itemCreateItemDatas)
                    m_spellLootTemplateBuilder.AppendFieldsValue(m_itemSpellDatas[0].id, // Entry
                                                                 itemLootData.id, // Item
                                                                 0, // ReferenceitemLootData
                                                                 "100", // Chance
                                                                 0, // QuestRequired
                                                                 1, // LootMode
                                                                 0, // GroupId
                                                                 "1", // MinCount
                                                                 "1", // MaxCount
                                                                 ""); // Comment

                returnSql += m_spellLootTemplateBuilder.ToString() + "\n";
            }

            if (IsCheckboxChecked("loot") && m_itemLootTemplateDatas != null)
            {
                m_itemLootTemplateBuilder = new SqlBuilder("item_loot_template", "entry", SqlQueryType.InsertIgnore);
                m_itemLootTemplateBuilder.SetFieldsNames("Item", "Reference", "Chance", "QuestRequired", "LootMode", "GroupId", "MinCount", "MaxCount", "Comment");

                foreach (ItemLootTemplateParsing itemLootData in m_itemLootTemplateDatas)
                {
                    String percent = ((float)itemLootData.count / (float)m_lootMaxCount * 100).ToString().Replace(",", ".");

                    int minLootCount = itemLootData.stack.Length >= 1 ? itemLootData.stack[0] : 1;
                    int maxLootCount = itemLootData.stack.Length >= 2 ? itemLootData.stack[1] : minLootCount;

                    m_itemLootTemplateBuilder.AppendFieldsValue(m_data.id, // Entry
                                                                itemLootData.id, // Item
                                                                0, // Reference
                                                                percent, // Chance
                                                                0, // QuestRequired
                                                                1, // LootMode
                                                                0, // GroupId
                                                                minLootCount, // MinCount
                                                                maxLootCount, // MaxCount
                                                                ""); // Comment
                }

                returnSql += m_itemLootTemplateBuilder.ToString() + "\n";
            }

            if (IsCheckboxChecked("dropped by") && m_itemDroppedByDatas != null)
            {
                m_itemDroppedByBuilder = new SqlBuilder("creature_loot_template", "entry", SqlQueryType.InsertIgnore);

                switch (GetVersion())
                {
                    case "9.2.0.42560":
                    {
                        m_itemDroppedByBuilder.SetFieldsNames("Item", "Chance", "LootMode", "GroupId", "MinCount", "MaxCount");
                    }
                    break;
                    default: // 8.x and 7.x
                    {
                        m_itemDroppedByBuilder.SetFieldsNames("item", "ChanceOrQuestChance", "lootmode", "groupid", "mincountOrRef", "maxcount", "itemBonuses");
                    }
                    break;
                }
            

                foreach (ItemDroppedByTemplateParsing itemDroppedByData in m_itemDroppedByDatas)
                {
                    float percent = ((float)itemDroppedByData.count / (float)itemDroppedByData.outof) * 100.0f;
                    String percentStr = Tools.NormalizeFloat(percent);

                    switch (GetVersion())
                    {
                        case "9.2.0.42560":
                        {
                            m_itemDroppedByBuilder.AppendFieldsValue(itemDroppedByData.id, m_data.id, percentStr, 1, 0, "1", "1");
                        }
                        break;
                        default: // 8.x and 7.x
                        {
                            m_itemDroppedByBuilder.AppendFieldsValue(itemDroppedByData.id, m_data.id, percentStr, 1, 0, "1", "1", "");
                        }
                        break;
                    }
                }

                returnSql += "DELETE FROM creature_loot_template WHERE item = " + m_data.id + ";\n";
                returnSql += m_itemDroppedByBuilder.ToString() + "\n";
            }

            return returnSql;
        }

        protected int m_lootMaxCount;

        private ItemParsing m_data;
        protected ItemSpellParsing[] m_itemSpellDatas;
        protected ItemCreateItemParsing[] m_itemCreateItemDatas;
        protected ItemLootTemplateParsing[] m_itemLootTemplateDatas;
        protected ItemDroppedByTemplateParsing[] m_itemDroppedByDatas;

        protected SqlBuilder m_spellLootTemplateBuilder;
        protected SqlBuilder m_itemLootTemplateBuilder;
        protected SqlBuilder m_itemDroppedByBuilder;
    }
}
