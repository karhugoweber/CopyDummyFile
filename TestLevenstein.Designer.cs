namespace LevensteinMatrix
{
    partial class TestLevenstein
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.InText_Path2learnfrom = new System.Windows.Forms.TextBox();
            this.Lab_Path2LearnFrom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InText_Path2learnfrom
            // 
            this.InText_Path2learnfrom.Location = new System.Drawing.Point(165, 12);
            this.InText_Path2learnfrom.Name = "InText_Path2learnfrom";
            this.InText_Path2learnfrom.Size = new System.Drawing.Size(200, 20);
            this.InText_Path2learnfrom.TabIndex = 0;
            this.InText_Path2learnfrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InText_Path2learnfrom_KeyPress);
            // 
            // Lab_Path2LearnFrom
            // 
            this.Lab_Path2LearnFrom.AutoSize = true;
            this.Lab_Path2LearnFrom.Location = new System.Drawing.Point(13, 18);
            this.Lab_Path2LearnFrom.Name = "Lab_Path2LearnFrom";
            this.Lab_Path2LearnFrom.Size = new System.Drawing.Size(95, 13);
            this.Lab_Path2LearnFrom.TabIndex = 1;
            this.Lab_Path2LearnFrom.Text = "Pfad zum Lerntext:";
            // 
            // TestLevenstein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lab_Path2LearnFrom);
            this.Controls.Add(this.InText_Path2learnfrom);
            this.Name = "TestLevenstein";
            this.Text = "Teste die Levenstein-Matrix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InText_Path2learnfrom;
        private System.Windows.Forms.Label Lab_Path2LearnFrom;
    }
}

