namespace WinFormsApp1
{
    partial class Form1
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
            btnCargarCustomers = new Button();
            label1 = new Label();
            lstCustomers = new ListBox();
            SuspendLayout();
            // 
            // btnCargarCustomers
            // 
            btnCargarCustomers.Location = new Point(47, 100);
            btnCargarCustomers.Margin = new Padding(5, 6, 5, 6);
            btnCargarCustomers.Name = "btnCargarCustomers";
            btnCargarCustomers.Size = new Size(157, 77);
            btnCargarCustomers.TabIndex = 0;
            btnCargarCustomers.Text = "Cargar Customers";
            btnCargarCustomers.UseVisualStyleBackColor = true;
            btnCargarCustomers.Click += btnCargarCustomers_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 40);
            label1.Name = "label1";
            label1.Size = new Size(104, 28);
            label1.TabIndex = 1;
            label1.Text = "Customers";
            // 
            // lstCustomers
            // 
            lstCustomers.FormattingEnabled = true;
            lstCustomers.ItemHeight = 28;
            lstCustomers.Location = new Point(274, 85);
            lstCustomers.Name = "lstCustomers";
            lstCustomers.Size = new Size(338, 284);
            lstCustomers.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 446);
            Controls.Add(lstCustomers);
            Controls.Add(label1);
            Controls.Add(btnCargarCustomers);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargarCustomers;
        private Label label1;
        private ListBox lstCustomers;
    }
}