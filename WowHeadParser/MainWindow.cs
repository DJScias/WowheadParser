/*
 * * Created by Traesh for AshamaneProject (https://github.com/AshamaneProject)
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WowHeadParser.Entities;

namespace WowHeadParser
{
    public partial class MainWindow : Form
    {
        public enum LocaleConstant
        {
            enUS = 0,
            koKR = 1,
            frFR = 2,
            deDE = 3,
            zhCN = 4,
            zhTW = 5,
            esES = 6,
            esMX = 7,
            ruRU = 8,
            ptPT = 9,
            itIT = 10,
        };

        public MainWindow()
        {
            InitializeComponent();

            comboBoxChoice.Items.Add("Single");
            comboBoxChoice.Items.Add("Range");
            comboBoxChoice.Items.Add("Zone");

            comboBoxEntity.Items.Add("BlackMarket");
            comboBoxEntity.Items.Add("Creature");
            comboBoxEntity.Items.Add("Gameobject");
            comboBoxEntity.Items.Add("Item");
            comboBoxEntity.Items.Add("Quest");
            comboBoxEntity.Items.Add("Zone");

            comboBoxLocale.Items.Add("www");
            comboBoxLocale.Items.Add("fr");
            comboBoxLocale.Items.Add("es");
            comboBoxLocale.Items.Add("de");
            comboBoxLocale.Items.Add("it");
            comboBoxLocale.Items.Add("pt");
            comboBoxLocale.Items.Add("ru");

            comboBoxChoice.SelectedIndex = 0;

            comboBoxVersion.Items.Add("8.0.1.28153");
            comboBoxVersion.Items.Add("7.3.5.26972");
            comboBoxVersion.SelectedIndex = 0;

            HideToTextbox(true);
            HideDataGroups(true);

            ids = new List<String>();
            currentId = 0;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBoxLocale.Items.Count; ++i)
                if (Properties.Settings.Default.wowheadLocale == (String)comboBoxLocale.Items[i])
                    comboBoxLocale.SelectedIndex = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String selectedLocale = comboBoxLocale.Items[comboBoxLocale.SelectedIndex].ToString();
            String selectedVersion = comboBoxVersion.Items[comboBoxVersion.SelectedIndex].ToString();
            Properties.Settings.Default.wowheadLocale = selectedLocale;
            Properties.Settings.Default.selectedEntity = comboBoxEntity.SelectedIndex;
            Properties.Settings.Default.version = selectedVersion;
            Entity.ReloadWowheadBaseUrl();
            UpdateCheckboxSettings(); // Must be done before Properties.Settings.Default.Save

            switch (selectedLocale)
            {
                case "www": Properties.Settings.Default.localIndex = (int)LocaleConstant.enUS; break;
                case "fr": Properties.Settings.Default.localIndex = (int)LocaleConstant.frFR; break;
                case "es": Properties.Settings.Default.localIndex = (int)LocaleConstant.esES; break;
                case "de": Properties.Settings.Default.localIndex = (int)LocaleConstant.deDE; break;
                case "it": Properties.Settings.Default.localIndex = (int)LocaleConstant.itIT; break;
                case "pt": Properties.Settings.Default.localIndex = (int)LocaleConstant.ptPT; break;
                case "ru": Properties.Settings.Default.localIndex = (int)LocaleConstant.ruRU; break;
                default: Properties.Settings.Default.localIndex = (int)LocaleConstant.frFR; break;
            }

            Properties.Settings.Default.Save();

            ids = new List<String>(textBoxFrom.Text.Split(' '));
            m_fileName = Tools.GetFileNameForCurrentTime();
            StartParsing();

            SetStartButtonEnableState(false);
        }

        public void StartParsing()
        {
            setProgressBar(0);
            switch (comboBoxChoice.SelectedIndex)
            {
                case 0:
                {
                    int firstId = Int32.Parse(ids[currentId]);

                    Range range = new Range(this, m_fileName);
                    range.StartParsing(firstId, firstId);

                    break;
                }
                case 1:
                {
                    int firstId = Int32.Parse(textBoxFrom.Text);
                    int lastId = Int32.Parse(textBoxTo.Text);

                    Range range = new Range(this, m_fileName);
                    range.StartParsing(firstId, lastId);

                    break;
                }
                case 2:
                {
                    Zone zone = new Zone(this);
                    zone.StartParsing(ids[currentId]);
                    break;
                }
            }
        }

        public void SetStartButtonEnableState(bool state)
        {
            button1.Enabled = state;
        }

        public void setProgressBar(int progress)
        {
            this.progressBar1.Value = progress;
            this.ProgressBarValue.Text = progress + "%";
        }

        public void SetTimeLeft(int seconds)
        {
            int hours = seconds / 3600;
            seconds %= 3600;

            int minutes = seconds / 60;
            seconds %= 60;

            timeLeftLabel.Text = hours.ToString("00") + "h" + minutes.ToString("00") + "m" + seconds.ToString("00") + "s";
        }

        public void SetWorkDone()
        {
            if (ids.Count > ++currentId)
            {
                StartParsing();

                setProgressBar(100);
                timeLeftLabel.Text = "Finished (" + (currentId + 1) + "/" + ids.Count + ")";
            }
            else
            {
                setProgressBar(100);
                timeLeftLabel.Text = "Finished";
                SetStartButtonEnableState(true);
                currentId = 0;
                if (m_zeroPercentLootChance)
                {
                    m_zeroPercentLootChance = false;
                    ShowZeroPercentPopup();
                }               
            }
        }

        private void comboBoxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChoice.SelectedIndex == 1)
                HideToTextbox(true);
            else
                HideToTextbox(false);
        }

        private void HideToTextbox(bool hide)
        {
            if (hide)
            {
                textBoxTo.Hide();
                labelTo.Hide();
            }
            else
            {
                textBoxTo.Show();
                labelTo.Show();
            }
        }

        private void HideDataGroups(bool hide)
        {
            if (hide)
            {
                leftDataGroup.Hide();
                rightDataGroup.Hide();
            }
            else
            {
                leftDataGroup.Show();
                rightDataGroup.Show();
            }
        }

        private bool hasHealthFiles()
        {
            string path = "Ressources";
            DirectoryInfo dir = new DirectoryInfo(path);

            var files = dir.GetFiles("NPCTotalHP*.txt");
            if (files.Length < 7) // Legion/BFA = 7 files
                return false;

            return true;
        }

        private void comboBoxEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            leftListView.Clear();
            rightListView.Clear();
            HideDataGroups(true);

            switch (comboBoxEntity.SelectedIndex)
            {
                // Black Market
                case 0:
                {
                    leftDataGroup.Show();
                    leftDataGroup.Text = "Data";
                    leftListView.Items.Add("Debug");
                    break;
                }
                // Creature
                case 1:
                {
                    HideDataGroups(false);
                    leftDataGroup.Text = "Data";
                    if (hasHealthFiles()) // hide if files not present
                        leftListView.Items.Add("health modifier");
                    leftListView.Items.Add("is dungeon/raid boss");
                    leftListView.Items.Add("locale");
                    leftListView.Items.Add("money");
                    leftListView.Items.Add("simple faction");
                    leftListView.Items.Add("template");
                    rightDataGroup.Text = "Extra";
                    rightListView.Items.Add("loot");
                    rightListView.Items.Add("quest starter");
                    rightListView.Items.Add("quest ender");
                    rightListView.Items.Add("skinning");
                    rightListView.Items.Add("trainer");
                    rightListView.Items.Add("vendor");
                    break;
                }
                // Gameobject
                case 2:
                {
                    leftDataGroup.Show();
                    leftDataGroup.Text = "Data";
                    leftListView.Items.Add("herbalism");
                    leftListView.Items.Add("locale");
                    leftListView.Items.Add("loot");
                    leftListView.Items.Add("mining");
                    break;
                }
                // Item
                case 3:
                {
                    leftDataGroup.Show();
                    leftDataGroup.Text = "Data";
                    leftListView.Items.Add("create item");
                    leftListView.Items.Add("dropped by");
                    leftListView.Items.Add("loot");
                    break;
                }
                // Quest
                case 4:
                {
                    leftDataGroup.Show();
                    leftDataGroup.Text = "Data";
                    leftListView.Items.Add("class");
                    leftListView.Items.Add("serie");
                    leftListView.Items.Add("starter/ender");
                    leftListView.Items.Add("team");
                    break;
                }
                // Zone
                case 5:
                {
                    leftDataGroup.Show();
                    leftDataGroup.Text = "Data";
                    leftListView.Items.Add("Fishing");
                    break;
                }
            }
        }

        public void UpdateCheckboxSettings()
        {
            if (Properties.Settings.Default.checkedList == null)
                Properties.Settings.Default.checkedList = new System.Collections.Specialized.StringCollection();
            else
                Properties.Settings.Default.checkedList.Clear();

            for (int i = 0; i < leftListView.Items.Count; ++i)
                if (leftListView.Items[i].Checked)
                    Properties.Settings.Default.checkedList.Add(leftListView.Items[i].Text);

            for (int i = 0; i < rightListView.Items.Count; ++i)
                if (rightListView.Items[i].Checked)
                    Properties.Settings.Default.checkedList.Add(rightListView.Items[i].Text);
        }

        public Entity CreateNeededEntity(int id = 0)
        {
            switch (Properties.Settings.Default.selectedEntity)
            {
                case 0: return new BlackMarket(id);
                case 1: return new Creature(id);
                case 2: return new Gameobject(id);
                case 3: return new Item(id);
                case 4: return new Quest(id);
                case 5: return new ZoneEntity(id);
            }

            return null;
        }

        public void ShowZeroPercentPopup()
        {
            string message = "Wowhead does not have a drop percentage for one or more items dropped by this creature.\r\n\r\nPlease fill the chance in manually as it was set to 0.";
            string caption = "Creature Loot - Warning!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            MessageBox.Show(message, caption, buttons, icon);
        }

        public static bool m_zeroPercentLootChance;
        private int currentId;
        private List<String> ids;
        private String m_fileName;
    }
}
