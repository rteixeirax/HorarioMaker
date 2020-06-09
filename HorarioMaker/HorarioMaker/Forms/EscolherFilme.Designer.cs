namespace HorarioMaker.Forms
{
    partial class EscolherFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscolherFilme));
            this.comboBox_filme = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_inserir = new System.Windows.Forms.Button();
            this.button_fechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_filme
            // 
            this.comboBox_filme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filme.FormattingEnabled = true;
            this.comboBox_filme.Location = new System.Drawing.Point(13, 27);
            this.comboBox_filme.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_filme.Name = "comboBox_filme";
            this.comboBox_filme.Size = new System.Drawing.Size(208, 24);
            this.comboBox_filme.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecione o Filme:";
            // 
            // button_inserir
            // 
            this.button_inserir.Image = global::HorarioMaker.Properties.Resources.check;
            this.button_inserir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_inserir.Location = new System.Drawing.Point(13, 89);
            this.button_inserir.Name = "button_inserir";
            this.button_inserir.Size = new System.Drawing.Size(97, 34);
            this.button_inserir.TabIndex = 2;
            this.button_inserir.Text = "      Inserir";
            this.button_inserir.UseVisualStyleBackColor = true;
            this.button_inserir.Click += new System.EventHandler(this.button_inserir_Click);
            // 
            // button_fechar
            // 
            this.button_fechar.Image = global::HorarioMaker.Properties.Resources.cancel;
            this.button_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_fechar.Location = new System.Drawing.Point(124, 89);
            this.button_fechar.Name = "button_fechar";
            this.button_fechar.Size = new System.Drawing.Size(97, 34);
            this.button_fechar.TabIndex = 3;
            this.button_fechar.Text = "       Fechar";
            this.button_fechar.UseVisualStyleBackColor = true;
            this.button_fechar.Click += new System.EventHandler(this.button_fechar_Click);
            // 
            // EscolherFilme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 135);
            this.Controls.Add(this.button_fechar);
            this.Controls.Add(this.button_inserir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_filme);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EscolherFilme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_filme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_inserir;
        private System.Windows.Forms.Button button_fechar;
    }
}