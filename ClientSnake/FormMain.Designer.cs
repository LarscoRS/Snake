namespace ClientSnake
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxMes = new System.Windows.Forms.TextBox();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.buttonSearchGame = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBoxSnake = new System.Windows.Forms.PictureBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnake)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(203, 6);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(84, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Соединиться";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(185, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Text = "UserName";
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(12, 177);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxMes
            // 
            this.textBoxMes.Location = new System.Drawing.Point(93, 177);
            this.textBoxMes.Name = "textBoxMes";
            this.textBoxMes.Size = new System.Drawing.Size(193, 20);
            this.textBoxMes.TabIndex = 4;
            this.textBoxMes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMes_KeyDown);
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Location = new System.Drawing.Point(12, 36);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.Size = new System.Drawing.Size(275, 132);
            this.richTextBoxChat.TabIndex = 5;
            this.richTextBoxChat.Text = "";
            this.richTextBoxChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxChat_KeyDown);
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.BackColor = System.Drawing.Color.GreenYellow;
            this.pictureBoxMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxMap.Location = new System.Drawing.Point(293, 9);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(515, 515);
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            // 
            // buttonSearchGame
            // 
            this.buttonSearchGame.Enabled = false;
            this.buttonSearchGame.Location = new System.Drawing.Point(12, 206);
            this.buttonSearchGame.Name = "buttonSearchGame";
            this.buttonSearchGame.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchGame.TabIndex = 7;
            this.buttonSearchGame.Text = "Найти игру";
            this.buttonSearchGame.UseVisualStyleBackColor = true;
            this.buttonSearchGame.Click += new System.EventHandler(this.buttonSearchGame_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(815, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(550, 515);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // pictureBoxSnake
            // 
            this.pictureBoxSnake.Location = new System.Drawing.Point(186, 206);
            this.pictureBoxSnake.Name = "pictureBoxSnake";
            this.pictureBoxSnake.Size = new System.Drawing.Size(100, 23);
            this.pictureBoxSnake.TabIndex = 9;
            this.pictureBoxSnake.TabStop = false;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(186, 235);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxTime.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 529);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.pictureBoxSnake);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonSearchGame);
            this.Controls.Add(this.pictureBoxMap);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxMes);
            this.Controls.Add(this.richTextBoxChat);
            this.Name = "FormMain";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMes;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        public System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.Button buttonSearchGame;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBoxSnake;
        private System.Windows.Forms.TextBox textBoxTime;
    }
}

