namespace Calculator
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actionList = new System.Windows.Forms.ComboBox();
            this.number2Field = new System.Windows.Forms.TextBox();
            this.number1Field = new System.Windows.Forms.TextBox();
            this.calculateBTN = new System.Windows.Forms.Button();
            this.answerLabel = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.answerLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.actionList);
            this.panel1.Controls.Add(this.number2Field);
            this.panel1.Controls.Add(this.number1Field);
            this.panel1.Controls.Add(this.calculateBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(747, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "-";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(773, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "x";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "второе число";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "первое число";
            // 
            // actionList
            // 
            this.actionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.actionList.FormattingEnabled = true;
            this.actionList.Location = new System.Drawing.Point(84, 128);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(201, 28);
            this.actionList.TabIndex = 3;
            // 
            // number2Field
            // 
            this.number2Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number2Field.Location = new System.Drawing.Point(84, 179);
            this.number2Field.Multiline = true;
            this.number2Field.Name = "number2Field";
            this.number2Field.Size = new System.Drawing.Size(518, 65);
            this.number2Field.TabIndex = 2;
            // 
            // number1Field
            // 
            this.number1Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number1Field.Location = new System.Drawing.Point(84, 57);
            this.number1Field.Multiline = true;
            this.number1Field.Name = "number1Field";
            this.number1Field.Size = new System.Drawing.Size(518, 65);
            this.number1Field.TabIndex = 1;
            // 
            // calculateBTN
            // 
            this.calculateBTN.Location = new System.Drawing.Point(639, 205);
            this.calculateBTN.Name = "calculateBTN";
            this.calculateBTN.Size = new System.Drawing.Size(111, 39);
            this.calculateBTN.TabIndex = 0;
            this.calculateBTN.Text = "подсчёт";
            this.calculateBTN.UseVisualStyleBackColor = true;
            this.calculateBTN.Click += new System.EventHandler(this.calculateBTN_Click);
            // 
            // answerLabel
            // 
            this.answerLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.answerLabel.Location = new System.Drawing.Point(84, 260);
            this.answerLabel.Multiline = true;
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.ReadOnly = true;
            this.answerLabel.Size = new System.Drawing.Size(666, 166);
            this.answerLabel.TabIndex = 9;
            this.answerLabel.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox number2Field;
        private System.Windows.Forms.TextBox number1Field;
        private System.Windows.Forms.Button calculateBTN;
        private System.Windows.Forms.ComboBox actionList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox answerLabel;
    }
}