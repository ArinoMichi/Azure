namespace WinFormsApp1
{
    partial class Form2
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
            btnCargarAereopuertos = new Button();
            lstAereopuertos = new ListBox();
            SuspendLayout();
            // 
            // btnCargarAereopuertos
            // 
            btnCargarAereopuertos.Location = new Point(45, 65);
            btnCargarAereopuertos.Name = "btnCargarAereopuertos";
            btnCargarAereopuertos.Size = new Size(191, 57);
            btnCargarAereopuertos.TabIndex = 0;
            btnCargarAereopuertos.Text = "Cargar Aereopuertos";
            btnCargarAereopuertos.UseVisualStyleBackColor = true;
            btnCargarAereopuertos.Click += btnCargarAereopuertos_Click;
            // 
            // lstAereopuertos
            // 
            lstAereopuertos.FormattingEnabled = true;
            lstAereopuertos.ItemHeight = 15;
            lstAereopuertos.Location = new Point(325, 64);
            lstAereopuertos.Name = "lstAereopuertos";
            lstAereopuertos.Size = new Size(341, 289);
            lstAereopuertos.TabIndex = 1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstAereopuertos);
            Controls.Add(btnCargarAereopuertos);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCargarAereopuertos;
        private ListBox lstAereopuertos;
    }
}