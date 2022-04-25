namespace WowHeadParser
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.comboBoxChoice = new System.Windows.Forms.ComboBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.parseBtn = new System.Windows.Forms.Button();
            this.comboBoxLocale = new System.Windows.Forms.ComboBox();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.comboBoxEntity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.leftDataGroup = new System.Windows.Forms.GroupBox();
            this.leftListView = new System.Windows.Forms.ListView();
            this.rightDataGroup = new System.Windows.Forms.GroupBox();
            this.rightListView = new System.Windows.Forms.ListView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressBarValue = new System.Windows.Forms.Label();
            this.comboBoxVersion = new System.Windows.Forms.ComboBox();
            this.leftDataGroup.SuspendLayout();
            this.rightDataGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTo
            // 
            this.textBoxTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTo.Location = new System.Drawing.Point(367, 10);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(80, 20);
            this.textBoxTo.TabIndex = 4;
            this.textBoxTo.Text = "2";
            this.textBoxTo.TextChanged += new System.EventHandler(this.textBoxTo_TextChanged);
            // 
            // comboBoxChoice
            // 
            this.comboBoxChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChoice.Enabled = false;
            this.comboBoxChoice.FormattingEnabled = true;
            this.comboBoxChoice.Location = new System.Drawing.Point(118, 10);
            this.comboBoxChoice.Name = "comboBoxChoice";
            this.comboBoxChoice.Size = new System.Drawing.Size(100, 21);
            this.comboBoxChoice.TabIndex = 1;
            this.comboBoxChoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoice_SelectedIndexChanged);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFrom.Location = new System.Drawing.Point(253, 10);
            this.textBoxFrom.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(80, 20);
            this.textBoxFrom.TabIndex = 3;
            this.textBoxFrom.Text = "1";
            this.textBoxFrom.TextChanged += new System.EventHandler(this.textBoxFrom_TextChanged);
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrom.Location = new System.Drawing.Point(218, 13);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(32, 13);
            this.labelFrom.TabIndex = 5;
            this.labelFrom.Text = "Start:";
            this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelFrom.UseCompatibleTextRendering = true;
            // 
            // labelTo
            // 
            this.labelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTo.Location = new System.Drawing.Point(335, 13);
            this.labelTo.Margin = new System.Windows.Forms.Padding(0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(29, 13);
            this.labelTo.TabIndex = 6;
            this.labelTo.Text = "End:";
            this.labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelTo.UseCompatibleTextRendering = true;
            // 
            // parseBtn
            // 
            this.parseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.parseBtn.Enabled = false;
            this.parseBtn.Location = new System.Drawing.Point(372, 248);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(75, 21);
            this.parseBtn.TabIndex = 7;
            this.parseBtn.Text = "Parse";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.parseBtn_Click);
            // 
            // comboBoxLocale
            // 
            this.comboBoxLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocale.FormattingEnabled = true;
            this.comboBoxLocale.Location = new System.Drawing.Point(12, 248);
            this.comboBoxLocale.Name = "comboBoxLocale";
            this.comboBoxLocale.Size = new System.Drawing.Size(51, 21);
            this.comboBoxLocale.TabIndex = 6;
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.Location = new System.Drawing.Point(247, 248);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(63, 21);
            this.timeLeftLabel.TabIndex = 9;
            this.timeLeftLabel.Text = "00h00m00s";
            this.timeLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timeLeftLabel.UseCompatibleTextRendering = true;
            // 
            // comboBoxEntity
            // 
            this.comboBoxEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEntity.FormattingEnabled = true;
            this.comboBoxEntity.Location = new System.Drawing.Point(12, 10);
            this.comboBoxEntity.Name = "comboBoxEntity";
            this.comboBoxEntity.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEntity.TabIndex = 2;
            this.comboBoxEntity.SelectedIndexChanged += new System.EventHandler(this.comboBoxEntity_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(157, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Time remaining:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // leftDataGroup
            // 
            this.leftDataGroup.Controls.Add(this.leftListView);
            this.leftDataGroup.Location = new System.Drawing.Point(12, 36);
            this.leftDataGroup.Name = "leftDataGroup";
            this.leftDataGroup.Size = new System.Drawing.Size(200, 177);
            this.leftDataGroup.TabIndex = 13;
            this.leftDataGroup.TabStop = false;
            this.leftDataGroup.Text = "leftDataGroup";
            // 
            // leftListView
            // 
            this.leftListView.BackColor = System.Drawing.SystemColors.Control;
            this.leftListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leftListView.CheckBoxes = true;
            this.leftListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.leftListView.HideSelection = false;
            this.leftListView.Location = new System.Drawing.Point(6, 19);
            this.leftListView.Name = "leftListView";
            this.leftListView.Size = new System.Drawing.Size(188, 152);
            this.leftListView.TabIndex = 0;
            this.leftListView.UseCompatibleStateImageBehavior = false;
            this.leftListView.View = System.Windows.Forms.View.List;
            this.leftListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.leftListView_ItemChecked);
            // 
            // rightDataGroup
            // 
            this.rightDataGroup.Controls.Add(this.rightListView);
            this.rightDataGroup.Location = new System.Drawing.Point(247, 36);
            this.rightDataGroup.Name = "rightDataGroup";
            this.rightDataGroup.Size = new System.Drawing.Size(200, 177);
            this.rightDataGroup.TabIndex = 14;
            this.rightDataGroup.TabStop = false;
            this.rightDataGroup.Text = "rightDataGroup";
            // 
            // rightListView
            // 
            this.rightListView.BackColor = System.Drawing.SystemColors.Control;
            this.rightListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rightListView.CheckBoxes = true;
            this.rightListView.HideSelection = false;
            this.rightListView.Location = new System.Drawing.Point(6, 19);
            this.rightListView.Name = "rightListView";
            this.rightListView.Size = new System.Drawing.Size(188, 152);
            this.rightListView.TabIndex = 1;
            this.rightListView.UseCompatibleStateImageBehavior = false;
            this.rightListView.View = System.Windows.Forms.View.List;
            this.rightListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.rightListView_ItemChecked);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(47, 219);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // ProgressBarValue
            // 
            this.ProgressBarValue.Location = new System.Drawing.Point(12, 219);
            this.ProgressBarValue.Name = "ProgressBarValue";
            this.ProgressBarValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ProgressBarValue.Size = new System.Drawing.Size(33, 23);
            this.ProgressBarValue.TabIndex = 8;
            this.ProgressBarValue.Text = "0%";
            this.ProgressBarValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressBarValue.UseCompatibleTextRendering = true;
            // 
            // comboBoxVersion
            // 
            this.comboBoxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVersion.FormattingEnabled = true;
            this.comboBoxVersion.Location = new System.Drawing.Point(69, 248);
            this.comboBoxVersion.Name = "comboBoxVersion";
            this.comboBoxVersion.Size = new System.Drawing.Size(82, 21);
            this.comboBoxVersion.TabIndex = 15;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 277);
            this.Controls.Add(this.comboBoxVersion);
            this.Controls.Add(this.rightDataGroup);
            this.Controls.Add(this.leftDataGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEntity);
            this.Controls.Add(this.timeLeftLabel);
            this.Controls.Add(this.ProgressBarValue);
            this.Controls.Add(this.comboBoxLocale);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.comboBoxChoice);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.parseBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "Wowhead Parser";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.leftDataGroup.ResumeLayout(false);
            this.rightDataGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.ComboBox comboBoxChoice;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.ComboBox comboBoxLocale;
        private System.Windows.Forms.Label timeLeftLabel;
        private System.Windows.Forms.ComboBox comboBoxEntity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox leftDataGroup;
        private System.Windows.Forms.ListView leftListView;
        private System.Windows.Forms.GroupBox rightDataGroup;
        private System.Windows.Forms.ListView rightListView;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProgressBarValue;
        private System.Windows.Forms.ComboBox comboBoxVersion;
    }
}

