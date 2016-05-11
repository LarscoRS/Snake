namespace ServerSnake
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelSetting = new System.Windows.Forms.Label();
            this.labelCountPlayerSetting = new System.Windows.Forms.Label();
            this.domainUpDownCountPlayer = new System.Windows.Forms.DomainUpDown();
            this.checkBoxBots = new System.Windows.Forms.CheckBox();
            this.domainUpDownCountBots = new System.Windows.Forms.DomainUpDown();
            this.labelCountBots = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(13, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(340, 410);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // labelSetting
            // 
            this.labelSetting.AutoSize = true;
            this.labelSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSetting.Location = new System.Drawing.Point(12, 464);
            this.labelSetting.Name = "labelSetting";
            this.labelSetting.Size = new System.Drawing.Size(91, 20);
            this.labelSetting.TabIndex = 3;
            this.labelSetting.Text = "Настройки";
            // 
            // labelCountPlayerSetting
            // 
            this.labelCountPlayerSetting.AutoSize = true;
            this.labelCountPlayerSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountPlayerSetting.Location = new System.Drawing.Point(13, 484);
            this.labelCountPlayerSetting.Name = "labelCountPlayerSetting";
            this.labelCountPlayerSetting.Size = new System.Drawing.Size(142, 16);
            this.labelCountPlayerSetting.TabIndex = 4;
            this.labelCountPlayerSetting.Text = "Количество игроков";
            // 
            // domainUpDownCountPlayer
            // 
            this.domainUpDownCountPlayer.Items.Add("4");
            this.domainUpDownCountPlayer.Items.Add("3");
            this.domainUpDownCountPlayer.Items.Add("2");
            this.domainUpDownCountPlayer.Items.Add("1");
            this.domainUpDownCountPlayer.Location = new System.Drawing.Point(161, 480);
            this.domainUpDownCountPlayer.Name = "domainUpDownCountPlayer";
            this.domainUpDownCountPlayer.Size = new System.Drawing.Size(40, 20);
            this.domainUpDownCountPlayer.TabIndex = 7;
            this.domainUpDownCountPlayer.Text = "1";
            // 
            // checkBoxBots
            // 
            this.checkBoxBots.AutoSize = true;
            this.checkBoxBots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxBots.Location = new System.Drawing.Point(16, 506);
            this.checkBoxBots.Name = "checkBoxBots";
            this.checkBoxBots.Size = new System.Drawing.Size(60, 20);
            this.checkBoxBots.TabIndex = 6;
            this.checkBoxBots.Text = "Боты";
            this.checkBoxBots.UseVisualStyleBackColor = true;
            this.checkBoxBots.CheckedChanged += new System.EventHandler(this.checkBoxBots_CheckedChanged);
            // 
            // domainUpDownCountBots
            // 
            this.domainUpDownCountBots.Items.Add("4");
            this.domainUpDownCountBots.Items.Add("3");
            this.domainUpDownCountBots.Items.Add("2");
            this.domainUpDownCountBots.Items.Add("1");
            this.domainUpDownCountBots.Items.Add("0");
            this.domainUpDownCountBots.Location = new System.Drawing.Point(214, 506);
            this.domainUpDownCountBots.Name = "domainUpDownCountBots";
            this.domainUpDownCountBots.Size = new System.Drawing.Size(40, 20);
            this.domainUpDownCountBots.TabIndex = 9;
            this.domainUpDownCountBots.Text = "0";
            this.domainUpDownCountBots.Visible = false;
            // 
            // labelCountBots
            // 
            this.labelCountBots.AutoSize = true;
            this.labelCountBots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountBots.Location = new System.Drawing.Point(80, 507);
            this.labelCountBots.Name = "labelCountBots";
            this.labelCountBots.Size = new System.Drawing.Size(128, 16);
            this.labelCountBots.TabIndex = 8;
            this.labelCountBots.Text = "Количество ботов";
            this.labelCountBots.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 578);
            this.Controls.Add(this.domainUpDownCountBots);
            this.Controls.Add(this.labelCountBots);
            this.Controls.Add(this.domainUpDownCountPlayer);
            this.Controls.Add(this.checkBoxBots);
            this.Controls.Add(this.labelCountPlayerSetting);
            this.Controls.Add(this.labelSetting);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormMain";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelSetting;
        private System.Windows.Forms.Label labelCountPlayerSetting;
        private System.Windows.Forms.DomainUpDown domainUpDownCountPlayer;
        private System.Windows.Forms.CheckBox checkBoxBots;
        private System.Windows.Forms.DomainUpDown domainUpDownCountBots;
        private System.Windows.Forms.Label labelCountBots;
    }
}

