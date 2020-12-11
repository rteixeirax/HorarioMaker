namespace HorarioMaker
{
    partial class AdicionarFilme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarFilme));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_pub = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_creditos = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_intervalo = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_adicionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título:";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_titulo.Location = new System.Drawing.Point(77, 22);
            this.textBox_titulo.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(356, 22);
            this.textBox_titulo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBox_pub);
            this.groupBox1.Controls.Add(this.maskedTextBox_creditos);
            this.groupBox1.Controls.Add(this.maskedTextBox_intervalo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(420, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inserir Tempos: ";
            // 
            // maskedTextBox_pub
            // 
            this.maskedTextBox_pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_pub.Location = new System.Drawing.Point(47, 53);
            this.maskedTextBox_pub.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox_pub.Mask = "00";
            this.maskedTextBox_pub.Name = "maskedTextBox_pub";
            this.maskedTextBox_pub.PromptChar = '-';
            this.maskedTextBox_pub.Size = new System.Drawing.Size(79, 22);
            this.maskedTextBox_pub.TabIndex = 1;
            this.maskedTextBox_pub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox_creditos
            // 
            this.maskedTextBox_creditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_creditos.Location = new System.Drawing.Point(303, 53);
            this.maskedTextBox_creditos.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox_creditos.Mask = "00:00:00";
            this.maskedTextBox_creditos.Name = "maskedTextBox_creditos";
            this.maskedTextBox_creditos.PromptChar = '-';
            this.maskedTextBox_creditos.Size = new System.Drawing.Size(79, 22);
            this.maskedTextBox_creditos.TabIndex = 3;
            this.maskedTextBox_creditos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox_intervalo
            // 
            this.maskedTextBox_intervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_intervalo.Location = new System.Drawing.Point(169, 53);
            this.maskedTextBox_intervalo.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox_intervalo.Mask = "00:00:00";
            this.maskedTextBox_intervalo.Name = "maskedTextBox_intervalo";
            this.maskedTextBox_intervalo.PromptChar = '-';
            this.maskedTextBox_intervalo.Size = new System.Drawing.Size(79, 22);
            this.maskedTextBox_intervalo.TabIndex = 2;
            this.maskedTextBox_intervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Créditos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Intervalo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Publicidade:";
            // 
            // button_cancelar
            // 
            this.button_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancelar.Image = global::HorarioMaker.Properties.Resources.cancel;
            this.button_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cancelar.Location = new System.Drawing.Point(250, 176);
            this.button_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(173, 36);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_adicionar
            // 
            this.button_adicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_adicionar.Image = global::HorarioMaker.Properties.Resources.check;
            this.button_adicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_adicionar.Location = new System.Drawing.Point(27, 176);
            this.button_adicionar.Margin = new System.Windows.Forms.Padding(4);
            this.button_adicionar.Name = "button_adicionar";
            this.button_adicionar.Size = new System.Drawing.Size(183, 36);
            this.button_adicionar.TabIndex = 4;
            this.button_adicionar.Text = "Adicionar";
            this.button_adicionar.UseVisualStyleBackColor = true;
            this.button_adicionar.Click += new System.EventHandler(this.button_adicionar_Click);
            // 
            // AdicionarFilme
            // 
            this.AcceptButton = this.button_adicionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancelar;
            this.ClientSize = new System.Drawing.Size(456, 219);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_adicionar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_titulo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdicionarFilme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Filme";
            this.Load += new System.EventHandler(this.AdicionarFilme_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_adicionar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_pub;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_creditos;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_intervalo;
    }
}