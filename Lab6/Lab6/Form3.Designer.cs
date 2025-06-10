namespace Lab6
{
    partial class Form3
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label6 = new Label();
            textBox5 = new TextBox();
            button1 = new Button();
            textBox6 = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 119);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 0;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 148);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 1;
            label2.Text = "Y";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 116);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "3";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(144, 145);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(259, 119);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 5;
            label4.Text = "Dydelfy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 151);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 6;
            label5.Text = "Krokodyle";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(312, 148);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            textBox3.Text = "0";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(312, 116);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 8;
            textBox4.Text = "3";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(108, 176);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 9;
            label6.Text = "Czas";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(144, 173);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 10;
            textBox5.Text = "30";
            // 
            // button1
            // 
            button1.Location = new Point(222, 215);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(312, 177);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 12;
            textBox6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(268, 180);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 13;
            label7.Text = "Szopy";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 263);
            Controls.Add(label7);
            Controls.Add(textBox6);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private TextBox textBox5;
        private Button button1;
        private TextBox textBox6;
        private Label label7;
    }
}