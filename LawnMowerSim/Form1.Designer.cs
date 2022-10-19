namespace LawnMowerSim
{
    partial class LawnMowerSim
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gardenGeneratorBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.algoSelLabel = new System.Windows.Forms.Label();
            this.algoSelComboBox = new System.Windows.Forms.ComboBox();
            this.gardenLabel = new System.Windows.Forms.Label();
            this.checkResBtn = new System.Windows.Forms.Button();
            this.selectSpeedLabel = new System.Windows.Forms.Label();
            this.selSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.gardenSet1Btn = new System.Windows.Forms.Button();
            this.gardenSet2Btn = new System.Windows.Forms.Button();
            this.obstChanceComboBox = new System.Windows.Forms.ComboBox();
            this.obstChanceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gardenGeneratorBtn
            // 
            this.gardenGeneratorBtn.Location = new System.Drawing.Point(911, 277);
            this.gardenGeneratorBtn.Name = "gardenGeneratorBtn";
            this.gardenGeneratorBtn.Size = new System.Drawing.Size(117, 23);
            this.gardenGeneratorBtn.TabIndex = 0;
            this.gardenGeneratorBtn.Text = "Generate Garden";
            this.gardenGeneratorBtn.UseVisualStyleBackColor = true;
            this.gardenGeneratorBtn.Click += new System.EventHandler(this.gardenGeneratorBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(933, 452);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(1004, 598);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // algoSelLabel
            // 
            this.algoSelLabel.AutoSize = true;
            this.algoSelLabel.Location = new System.Drawing.Point(912, 387);
            this.algoSelLabel.Name = "algoSelLabel";
            this.algoSelLabel.Size = new System.Drawing.Size(85, 13);
            this.algoSelLabel.TabIndex = 4;
            this.algoSelLabel.Text = "Select algorithm:";
            // 
            // algoSelComboBox
            // 
            this.algoSelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algoSelComboBox.FormattingEnabled = true;
            this.algoSelComboBox.Location = new System.Drawing.Point(915, 403);
            this.algoSelComboBox.Name = "algoSelComboBox";
            this.algoSelComboBox.Size = new System.Drawing.Size(121, 21);
            this.algoSelComboBox.TabIndex = 5;
            // 
            // gardenLabel
            // 
            this.gardenLabel.AutoSize = true;
            this.gardenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gardenLabel.Location = new System.Drawing.Point(420, 30);
            this.gardenLabel.Name = "gardenLabel";
            this.gardenLabel.Size = new System.Drawing.Size(69, 20);
            this.gardenLabel.TabIndex = 7;
            this.gardenLabel.Text = "Garden";
            // 
            // checkResBtn
            // 
            this.checkResBtn.Location = new System.Drawing.Point(933, 452);
            this.checkResBtn.Name = "checkResBtn";
            this.checkResBtn.Size = new System.Drawing.Size(75, 23);
            this.checkResBtn.TabIndex = 9;
            this.checkResBtn.Text = "Check result";
            this.checkResBtn.UseVisualStyleBackColor = true;
            this.checkResBtn.Click += new System.EventHandler(this.checkResBtn_Click);
            // 
            // selectSpeedLabel
            // 
            this.selectSpeedLabel.AutoSize = true;
            this.selectSpeedLabel.Location = new System.Drawing.Point(908, 332);
            this.selectSpeedLabel.Name = "selectSpeedLabel";
            this.selectSpeedLabel.Size = new System.Drawing.Size(72, 13);
            this.selectSpeedLabel.TabIndex = 10;
            this.selectSpeedLabel.Text = "Select speed:";
            // 
            // selSpeedComboBox
            // 
            this.selSpeedComboBox.FormattingEnabled = true;
            this.selSpeedComboBox.Location = new System.Drawing.Point(911, 348);
            this.selSpeedComboBox.Name = "selSpeedComboBox";
            this.selSpeedComboBox.Size = new System.Drawing.Size(121, 21);
            this.selSpeedComboBox.TabIndex = 11;
            // 
            // gardenSet1Btn
            // 
            this.gardenSet1Btn.Location = new System.Drawing.Point(911, 79);
            this.gardenSet1Btn.Name = "gardenSet1Btn";
            this.gardenSet1Btn.Size = new System.Drawing.Size(75, 23);
            this.gardenSet1Btn.TabIndex = 12;
            this.gardenSet1Btn.Text = "Garden 1";
            this.gardenSet1Btn.UseVisualStyleBackColor = true;
            this.gardenSet1Btn.Click += new System.EventHandler(this.gardenSet1Btn_Click);
            // 
            // gardenSet2Btn
            // 
            this.gardenSet2Btn.Location = new System.Drawing.Point(911, 124);
            this.gardenSet2Btn.Name = "gardenSet2Btn";
            this.gardenSet2Btn.Size = new System.Drawing.Size(75, 23);
            this.gardenSet2Btn.TabIndex = 13;
            this.gardenSet2Btn.Text = "Garden 2";
            this.gardenSet2Btn.UseVisualStyleBackColor = true;
            this.gardenSet2Btn.Click += new System.EventHandler(this.gardenSet2Btn_Click);
            // 
            // obstChanceComboBox
            // 
            this.obstChanceComboBox.FormattingEnabled = true;
            this.obstChanceComboBox.Location = new System.Drawing.Point(911, 183);
            this.obstChanceComboBox.Name = "obstChanceComboBox";
            this.obstChanceComboBox.Size = new System.Drawing.Size(121, 21);
            this.obstChanceComboBox.TabIndex = 14;
            // 
            // obstChanceLabel
            // 
            this.obstChanceLabel.AutoSize = true;
            this.obstChanceLabel.Location = new System.Drawing.Point(912, 167);
            this.obstChanceLabel.Name = "obstChanceLabel";
            this.obstChanceLabel.Size = new System.Drawing.Size(89, 13);
            this.obstChanceLabel.TabIndex = 15;
            this.obstChanceLabel.Text = "Obstacle Chance";
            // 
            // LawnMowerSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 633);
            this.Controls.Add(this.obstChanceLabel);
            this.Controls.Add(this.obstChanceComboBox);
            this.Controls.Add(this.gardenSet2Btn);
            this.Controls.Add(this.gardenSet1Btn);
            this.Controls.Add(this.selSpeedComboBox);
            this.Controls.Add(this.selectSpeedLabel);
            this.Controls.Add(this.checkResBtn);
            this.Controls.Add(this.gardenLabel);
            this.Controls.Add(this.algoSelComboBox);
            this.Controls.Add(this.algoSelLabel);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.gardenGeneratorBtn);
            this.Name = "LawnMowerSim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LawnMowerSim";
            this.Load += new System.EventHandler(this.LawnMoverSim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gardenGeneratorBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label algoSelLabel;
        private System.Windows.Forms.ComboBox algoSelComboBox;
        private System.Windows.Forms.Label gardenLabel;
        private System.Windows.Forms.Button checkResBtn;
        private System.Windows.Forms.Label selectSpeedLabel;
        private System.Windows.Forms.ComboBox selSpeedComboBox;
        private System.Windows.Forms.Button gardenSet1Btn;
        private System.Windows.Forms.Button gardenSet2Btn;
        private System.Windows.Forms.ComboBox obstChanceComboBox;
        private System.Windows.Forms.Label obstChanceLabel;
    }
}

