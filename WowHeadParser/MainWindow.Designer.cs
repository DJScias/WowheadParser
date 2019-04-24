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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.comboBoxChoice = new System.Windows.Forms.ComboBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxLocale = new System.Windows.Forms.ComboBox();
            this.ProgressBarValue = new System.Windows.Forms.Label();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.comboBoxEntity = new System.Windows.Forms.ComboBox();
            this.selectList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(47, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(367, 10);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(80, 20);
            this.textBoxTo.TabIndex = 4;
            this.textBoxTo.Text = "0";
            // 
            // comboBoxChoice
            // 
            this.comboBoxChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChoice.FormattingEnabled = true;
            this.comboBoxChoice.Location = new System.Drawing.Point(12, 10);
            this.comboBoxChoice.Name = "comboBoxChoice";
            this.comboBoxChoice.Size = new System.Drawing.Size(100, 21);
            this.comboBoxChoice.TabIndex = 1;
            this.comboBoxChoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoice_SelectedIndexChanged);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(256, 10);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(80, 20);
            this.textBoxFrom.TabIndex = 3;
            this.textBoxFrom.Text = "1";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(223, 13);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(33, 13);
            this.labelFrom.TabIndex = 5;
            this.labelFrom.Text = "From:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(342, 13);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(23, 13);
            this.labelTo.TabIndex = 6;
            this.labelTo.Text = "To:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Parse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxLocale
            // 
            this.comboBoxLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocale.FormattingEnabled = true;
            this.comboBoxLocale.Location = new System.Drawing.Point(12, 169);
            this.comboBoxLocale.Name = "comboBoxLocale";
            this.comboBoxLocale.Size = new System.Drawing.Size(80, 21);
            this.comboBoxLocale.TabIndex = 6;
            // 
            // ProgressBarValue
            // 
            this.ProgressBarValue.AutoSize = true;
            this.ProgressBarValue.Location = new System.Drawing.Point(9, 47);
            this.ProgressBarValue.Name = "ProgressBarValue";
            this.ProgressBarValue.Size = new System.Drawing.Size(21, 13);
            this.ProgressBarValue.TabIndex = 8;
            this.ProgressBarValue.Text = "0%";
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Location = new System.Drawing.Point(185, 176);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(62, 13);
            this.timeLeftLabel.TabIndex = 9;
            this.timeLeftLabel.Text = "00h00m00s";
            // 
            // comboBoxEntity
            // 
            this.comboBoxEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEntity.FormattingEnabled = true;
            this.comboBoxEntity.Location = new System.Drawing.Point(118, 10);
            this.comboBoxEntity.Name = "comboBoxEntity";
            this.comboBoxEntity.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEntity.TabIndex = 2;
            this.comboBoxEntity.SelectedIndexChanged += new System.EventHandler(this.comboBoxEntity_SelectedIndexChanged);
            // 
            // selectList
            // 
            this.selectList.CheckBoxes = true;
            this.selectList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.selectList.Location = new System.Drawing.Point(12, 66);
            this.selectList.Name = "selectList";
            this.selectList.Size = new System.Drawing.Size(435, 97);
            this.selectList.TabIndex = 5;
            this.selectList.UseCompatibleStateImageBehavior = false;
            this.selectList.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Time remaining:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 198);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectList);
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
            this.Controls.Add(this.button1);
            this.Name = "MainWindow";
            this.Text = "Wowhead Parser";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.ComboBox comboBoxChoice;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxLocale;
        private System.Windows.Forms.Label ProgressBarValue;
        private System.Windows.Forms.Label timeLeftLabel;
        private System.Windows.Forms.ComboBox comboBoxEntity;
        private System.Windows.Forms.ListView selectList;
        private System.Windows.Forms.Label label1;
    }
}

