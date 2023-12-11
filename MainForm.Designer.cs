namespace KR1VSSIT
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SelectFile_button = new Button();
            button3 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(193, 20);
            label1.TabIndex = 0;
            label1.Text = "Лабораторная работа №1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(302, 20);
            label2.TabIndex = 1;
            label2.Text = "Выполнил: Боковой Владислав Сергеевич";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 84);
            label3.Name = "label3";
            label3.Size = new Size(165, 20);
            label3.TabIndex = 2;
            label3.Text = "Студент 3го курса 415г";
            // 
            // SelectFile_button
            // 
            SelectFile_button.Location = new Point(12, 126);
            SelectFile_button.Name = "SelectFile_button";
            SelectFile_button.Size = new Size(165, 29);
            SelectFile_button.TabIndex = 3;
            SelectFile_button.Text = "Выбор файла";
            SelectFile_button.UseVisualStyleBackColor = true;
            SelectFile_button.Click += SelectFile_button_Click;
            // 
            // button3
            // 
            button3.Location = new Point(220, 18);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "Задание";
            button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(192, 126);
            button1.Name = "button1";
            button1.Size = new Size(122, 29);
            button1.TabIndex = 6;
            button1.Text = "Сравнить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 229);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(SelectFile_button);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button SelectFile_button;
        private Button button3;
        private Button button1;
    }
}