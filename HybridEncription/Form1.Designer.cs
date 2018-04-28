namespace HybridEncription
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEncKey = new System.Windows.Forms.Label();
            this.labelSessionKey = new System.Windows.Forms.Label();
            this.buttonSendKeyMessage = new System.Windows.Forms.Button();
            this.buttonEncryptKeyRSA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEncryptedMessageAlice = new System.Windows.Forms.TextBox();
            this.buttonEncryptAes = new System.Windows.Forms.Button();
            this.buttonGenKey = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.textBoxPlainTextAlice = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDecryptedMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDecryptedKey = new System.Windows.Forms.Label();
            this.buttonDecryptMessageAes = new System.Windows.Forms.Button();
            this.buttonDecryptSeessionKey = new System.Windows.Forms.Button();
            this.textBoxBobPrivateKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBobOpenKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelEncKey);
            this.groupBox1.Controls.Add(this.labelSessionKey);
            this.groupBox1.Controls.Add(this.buttonSendKeyMessage);
            this.groupBox1.Controls.Add(this.buttonEncryptKeyRSA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxEncryptedMessageAlice);
            this.groupBox1.Controls.Add(this.buttonEncryptAes);
            this.groupBox1.Controls.Add(this.buttonGenKey);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.textBoxPlainTextAlice);
            this.groupBox1.Location = new System.Drawing.Point(13, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 371);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Алиса";
            // 
            // labelEncKey
            // 
            this.labelEncKey.AutoSize = true;
            this.labelEncKey.Location = new System.Drawing.Point(14, 294);
            this.labelEncKey.Name = "labelEncKey";
            this.labelEncKey.Size = new System.Drawing.Size(112, 13);
            this.labelEncKey.TabIndex = 9;
            this.labelEncKey.Text = "encrypted session key";
            // 
            // labelSessionKey
            // 
            this.labelSessionKey.AutoSize = true;
            this.labelSessionKey.Location = new System.Drawing.Point(11, 128);
            this.labelSessionKey.Name = "labelSessionKey";
            this.labelSessionKey.Size = new System.Drawing.Size(67, 13);
            this.labelSessionKey.TabIndex = 8;
            this.labelSessionKey.Text = "Session key:";
            // 
            // buttonSendKeyMessage
            // 
            this.buttonSendKeyMessage.Location = new System.Drawing.Point(13, 330);
            this.buttonSendKeyMessage.Name = "buttonSendKeyMessage";
            this.buttonSendKeyMessage.Size = new System.Drawing.Size(231, 23);
            this.buttonSendKeyMessage.TabIndex = 7;
            this.buttonSendKeyMessage.Text = "4.Send key and message to Bob";
            this.buttonSendKeyMessage.UseVisualStyleBackColor = true;
            this.buttonSendKeyMessage.Click += new System.EventHandler(this.buttonSendKeyMessage_Click);
            // 
            // buttonEncryptKeyRSA
            // 
            this.buttonEncryptKeyRSA.Location = new System.Drawing.Point(14, 263);
            this.buttonEncryptKeyRSA.Name = "buttonEncryptKeyRSA";
            this.buttonEncryptKeyRSA.Size = new System.Drawing.Size(231, 23);
            this.buttonEncryptKeyRSA.TabIndex = 6;
            this.buttonEncryptKeyRSA.Text = "3.Encrypt session key RSA";
            this.buttonEncryptKeyRSA.UseVisualStyleBackColor = true;
            this.buttonEncryptKeyRSA.Click += new System.EventHandler(this.buttonEncryptKeyRSA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Зашифрованное сообщение:";
            // 
            // textBoxEncryptedMessageAlice
            // 
            this.textBoxEncryptedMessageAlice.Location = new System.Drawing.Point(10, 204);
            this.textBoxEncryptedMessageAlice.Multiline = true;
            this.textBoxEncryptedMessageAlice.Name = "textBoxEncryptedMessageAlice";
            this.textBoxEncryptedMessageAlice.Size = new System.Drawing.Size(235, 52);
            this.textBoxEncryptedMessageAlice.TabIndex = 4;
            // 
            // buttonEncryptAes
            // 
            this.buttonEncryptAes.Location = new System.Drawing.Point(11, 157);
            this.buttonEncryptAes.Name = "buttonEncryptAes";
            this.buttonEncryptAes.Size = new System.Drawing.Size(234, 23);
            this.buttonEncryptAes.TabIndex = 3;
            this.buttonEncryptAes.Text = "2.Encrypt message AES";
            this.buttonEncryptAes.UseVisualStyleBackColor = true;
            this.buttonEncryptAes.Click += new System.EventHandler(this.buttonEncryptAes_Click);
            // 
            // buttonGenKey
            // 
            this.buttonGenKey.Location = new System.Drawing.Point(10, 95);
            this.buttonGenKey.Name = "buttonGenKey";
            this.buttonGenKey.Size = new System.Drawing.Size(234, 23);
            this.buttonGenKey.TabIndex = 2;
            this.buttonGenKey.Text = "1.Generate session key";
            this.buttonGenKey.UseVisualStyleBackColor = true;
            this.buttonGenKey.Click += new System.EventHandler(this.buttonGenKey_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(7, 18);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(68, 13);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Сообщение:";
            // 
            // textBoxPlainTextAlice
            // 
            this.textBoxPlainTextAlice.Location = new System.Drawing.Point(6, 37);
            this.textBoxPlainTextAlice.Multiline = true;
            this.textBoxPlainTextAlice.Name = "textBoxPlainTextAlice";
            this.textBoxPlainTextAlice.Size = new System.Drawing.Size(239, 52);
            this.textBoxPlainTextAlice.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDecryptedMessage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelDecryptedKey);
            this.groupBox2.Controls.Add(this.buttonDecryptMessageAes);
            this.groupBox2.Controls.Add(this.buttonDecryptSeessionKey);
            this.groupBox2.Controls.Add(this.textBoxBobPrivateKey);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxBobOpenKey);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(348, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 371);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Боб";
            // 
            // textBoxDecryptedMessage
            // 
            this.textBoxDecryptedMessage.Location = new System.Drawing.Point(24, 244);
            this.textBoxDecryptedMessage.Multiline = true;
            this.textBoxDecryptedMessage.Name = "textBoxDecryptedMessage";
            this.textBoxDecryptedMessage.Size = new System.Drawing.Size(311, 66);
            this.textBoxDecryptedMessage.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Расшифрованное сообщение";
            // 
            // labelDecryptedKey
            // 
            this.labelDecryptedKey.AutoSize = true;
            this.labelDecryptedKey.Location = new System.Drawing.Point(21, 158);
            this.labelDecryptedKey.Name = "labelDecryptedKey";
            this.labelDecryptedKey.Size = new System.Drawing.Size(79, 13);
            this.labelDecryptedKey.TabIndex = 6;
            this.labelDecryptedKey.Text = "Decrypted key:";
            // 
            // buttonDecryptMessageAes
            // 
            this.buttonDecryptMessageAes.Location = new System.Drawing.Point(21, 177);
            this.buttonDecryptMessageAes.Name = "buttonDecryptMessageAes";
            this.buttonDecryptMessageAes.Size = new System.Drawing.Size(314, 23);
            this.buttonDecryptMessageAes.TabIndex = 5;
            this.buttonDecryptMessageAes.Text = "6. Decrypt message AES";
            this.buttonDecryptMessageAes.UseVisualStyleBackColor = true;
            this.buttonDecryptMessageAes.Click += new System.EventHandler(this.buttonDecryptMessageAes_Click);
            // 
            // buttonDecryptSeessionKey
            // 
            this.buttonDecryptSeessionKey.Location = new System.Drawing.Point(21, 127);
            this.buttonDecryptSeessionKey.Name = "buttonDecryptSeessionKey";
            this.buttonDecryptSeessionKey.Size = new System.Drawing.Size(314, 23);
            this.buttonDecryptSeessionKey.TabIndex = 4;
            this.buttonDecryptSeessionKey.Text = "5. Decrypt session key RSA";
            this.buttonDecryptSeessionKey.UseVisualStyleBackColor = true;
            this.buttonDecryptSeessionKey.Click += new System.EventHandler(this.buttonDecryptSeessionKey_Click);
            // 
            // textBoxBobPrivateKey
            // 
            this.textBoxBobPrivateKey.Location = new System.Drawing.Point(21, 93);
            this.textBoxBobPrivateKey.Name = "textBoxBobPrivateKey";
            this.textBoxBobPrivateKey.ReadOnly = true;
            this.textBoxBobPrivateKey.Size = new System.Drawing.Size(314, 20);
            this.textBoxBobPrivateKey.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Закрытый ключ";
            // 
            // textBoxBobOpenKey
            // 
            this.textBoxBobOpenKey.Location = new System.Drawing.Point(21, 35);
            this.textBoxBobOpenKey.Name = "textBoxBobOpenKey";
            this.textBoxBobOpenKey.ReadOnly = true;
            this.textBoxBobOpenKey.Size = new System.Drawing.Size(314, 20);
            this.textBoxBobOpenKey.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Открытый ключ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Use BouncyCastle RSA";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "CBC",
            "OFB",
            "CFB"});
            this.comboBoxMode.Location = new System.Drawing.Point(348, 5);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMode.TabIndex = 3;
            this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "AES MODE:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 426);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Гибридное шифрование AES/RSA в режимах CBC/OFB/CFB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxEncryptedMessageAlice;
        private System.Windows.Forms.Button buttonEncryptAes;
        private System.Windows.Forms.Button buttonGenKey;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox textBoxPlainTextAlice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBobOpenKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEncryptKeyRSA;
        private System.Windows.Forms.Button buttonSendKeyMessage;
        private System.Windows.Forms.Button buttonDecryptSeessionKey;
        private System.Windows.Forms.TextBox textBoxBobPrivateKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSessionKey;
        private System.Windows.Forms.Label labelDecryptedKey;
        private System.Windows.Forms.Button buttonDecryptMessageAes;
        private System.Windows.Forms.TextBox textBoxDecryptedMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelEncKey;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label5;
    }
}

