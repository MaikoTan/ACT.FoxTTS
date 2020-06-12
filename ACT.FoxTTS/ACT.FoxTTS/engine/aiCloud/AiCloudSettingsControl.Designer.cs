namespace ACT.FoxTTS.engine.ai_cloud
{
    partial class AiCloudSettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxAiCloudDetails = new System.Windows.Forms.GroupBox();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.labelPerson = new System.Windows.Forms.Label();
            this.labelVolumeValue = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelPitchValue = new System.Windows.Forms.Label();
            this.labelPitch = new System.Windows.Forms.Label();
            this.trackBarPitch = new System.Windows.Forms.TrackBar();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.txtBoxProxy = new System.Windows.Forms.TextBox();
            this.lblProxy = new System.Windows.Forms.Label();
            this.groupBoxAiCloudDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAiCloudDetails
            // 
            this.groupBoxAiCloudDetails.Controls.Add(this.lblProxy);
            this.groupBoxAiCloudDetails.Controls.Add(this.txtBoxProxy);
            this.groupBoxAiCloudDetails.Controls.Add(this.comboBoxPerson);
            this.groupBoxAiCloudDetails.Controls.Add(this.labelPerson);
            this.groupBoxAiCloudDetails.Controls.Add(this.labelVolumeValue);
            this.groupBoxAiCloudDetails.Controls.Add(this.labelVolume);
            this.groupBoxAiCloudDetails.Controls.Add(this.trackBarVolume);
            this.groupBoxAiCloudDetails.Controls.Add(this.labelPitchValue);
            this.groupBoxAiCloudDetails.Controls.Add(this.labelPitch);
            this.groupBoxAiCloudDetails.Controls.Add(this.trackBarPitch);
            this.groupBoxAiCloudDetails.Controls.Add(this.labelSpeedValue);
            this.groupBoxAiCloudDetails.Controls.Add(this.trackBarSpeed);
            this.groupBoxAiCloudDetails.Controls.Add(this.labelSpeed);
            this.groupBoxAiCloudDetails.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAiCloudDetails.Name = "groupBoxAiCloudDetails";
            this.groupBoxAiCloudDetails.Size = new System.Drawing.Size(514, 483);
            this.groupBoxAiCloudDetails.TabIndex = 0;
            this.groupBoxAiCloudDetails.TabStop = false;
            this.groupBoxAiCloudDetails.Text = "Engine Details";
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Items.AddRange(new object[] {
            "紲星 あかり",
            "結月 ゆかり",
            "桜乃 そら",
            "琴葉 茜",
            "琴葉 葵",
            "東北 イタコ",
            "東北 ずん子",
            "東北 きりたん",
            "京町 セイカ",
            "水奈瀬 コウ",
            "民安 ともえ",
            "月読 アイ",
            "月読 ショウタ",
            "鷹の爪 吉田くん",
            "ついなちゃん(標準語)",
            "ついなちゃん(関西弁)",
            "伊織弓鶴"});
            this.comboBoxPerson.Location = new System.Drawing.Point(72, 180);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(420, 21);
            this.comboBoxPerson.TabIndex = 10;
            // 
            // labelPerson
            // 
            this.labelPerson.AutoSize = true;
            this.labelPerson.Location = new System.Drawing.Point(4, 183);
            this.labelPerson.Name = "labelPerson";
            this.labelPerson.Size = new System.Drawing.Size(40, 13);
            this.labelPerson.TabIndex = 9;
            this.labelPerson.Text = "Person";
            // 
            // labelVolumeValue
            // 
            this.labelVolumeValue.AutoSize = true;
            this.labelVolumeValue.Location = new System.Drawing.Point(469, 128);
            this.labelVolumeValue.Name = "labelVolumeValue";
            this.labelVolumeValue.Size = new System.Drawing.Size(22, 13);
            this.labelVolumeValue.TabIndex = 8;
            this.labelVolumeValue.Text = "1.0";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(6, 128);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(42, 13);
            this.labelVolume.TabIndex = 7;
            this.labelVolume.Text = "Volume";
            this.labelVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(72, 123);
            this.trackBarVolume.Maximum = 25;
            this.trackBarVolume.Minimum = 5;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(391, 45);
            this.trackBarVolume.TabIndex = 6;
            this.trackBarVolume.Value = 10;
            // 
            // labelPitchValue
            // 
            this.labelPitchValue.AutoSize = true;
            this.labelPitchValue.Location = new System.Drawing.Point(470, 75);
            this.labelPitchValue.Name = "labelPitchValue";
            this.labelPitchValue.Size = new System.Drawing.Size(22, 13);
            this.labelPitchValue.TabIndex = 5;
            this.labelPitchValue.Text = "1.0";
            // 
            // labelPitch
            // 
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(6, 75);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(31, 13);
            this.labelPitch.TabIndex = 4;
            this.labelPitch.Text = "Pitch";
            this.labelPitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.Location = new System.Drawing.Point(72, 71);
            this.trackBarPitch.Maximum = 20;
            this.trackBarPitch.Minimum = 5;
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Size = new System.Drawing.Size(391, 45);
            this.trackBarPitch.TabIndex = 3;
            this.trackBarPitch.Value = 10;
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(470, 26);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Size = new System.Drawing.Size(22, 13);
            this.labelSpeedValue.TabIndex = 2;
            this.labelSpeedValue.Text = "1.0";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(72, 20);
            this.trackBarSpeed.Maximum = 30;
            this.trackBarSpeed.Minimum = 5;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(391, 45);
            this.trackBarSpeed.TabIndex = 1;
            this.trackBarSpeed.Value = 10;
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(6, 24);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(38, 13);
            this.labelSpeed.TabIndex = 0;
            this.labelSpeed.Text = "Speed";
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxProxy
            // 
            this.txtBoxProxy.Location = new System.Drawing.Point(72, 238);
            this.txtBoxProxy.Name = "txtBoxProxy";
            this.txtBoxProxy.Size = new System.Drawing.Size(420, 20);
            this.txtBoxProxy.TabIndex = 11;
            // 
            // lblProxy
            // 
            this.lblProxy.AutoSize = true;
            this.lblProxy.Location = new System.Drawing.Point(8, 241);
            this.lblProxy.Name = "lblProxy";
            this.lblProxy.Size = new System.Drawing.Size(33, 13);
            this.lblProxy.TabIndex = 12;
            this.lblProxy.Text = "Proxy";
            // 
            // AiCloudSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxAiCloudDetails);
            this.Name = "AiCloudSettingsControl";
            this.Size = new System.Drawing.Size(520, 489);
            this.groupBoxAiCloudDetails.ResumeLayout(false);
            this.groupBoxAiCloudDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAiCloudDetails;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelPitchValue;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.TrackBar trackBarPitch;
        private System.Windows.Forms.Label labelVolumeValue;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Label labelPerson;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.Label lblProxy;
        private System.Windows.Forms.TextBox txtBoxProxy;
    }
}
