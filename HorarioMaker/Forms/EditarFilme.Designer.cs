namespace HorarioMaker.Forms
{
    partial class EditarFilme
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarFilme));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_pub = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_creditos = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_intervalo = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limparSessõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Publicidade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Intervalo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Créditos:";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Location = new System.Drawing.Point(66, 6);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(230, 22);
            this.textBox_titulo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBox_pub);
            this.groupBox1.Controls.Add(this.maskedTextBox_creditos);
            this.groupBox1.Controls.Add(this.maskedTextBox_intervalo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(17, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 87);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tempos:";
            // 
            // maskedTextBox_pub
            // 
            this.maskedTextBox_pub.Location = new System.Drawing.Point(5, 50);
            this.maskedTextBox_pub.Mask = "00";
            this.maskedTextBox_pub.Name = "maskedTextBox_pub";
            this.maskedTextBox_pub.PromptChar = '-';
            this.maskedTextBox_pub.Size = new System.Drawing.Size(68, 22);
            this.maskedTextBox_pub.TabIndex = 1;
            this.maskedTextBox_pub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox_creditos
            // 
            this.maskedTextBox_creditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_creditos.Location = new System.Drawing.Point(192, 49);
            this.maskedTextBox_creditos.Mask = "00:00:00";
            this.maskedTextBox_creditos.Name = "maskedTextBox_creditos";
            this.maskedTextBox_creditos.PromptChar = '-';
            this.maskedTextBox_creditos.Size = new System.Drawing.Size(70, 22);
            this.maskedTextBox_creditos.TabIndex = 3;
            this.maskedTextBox_creditos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextBox_intervalo
            // 
            this.maskedTextBox_intervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_intervalo.Location = new System.Drawing.Point(98, 49);
            this.maskedTextBox_intervalo.Mask = "00:00:00";
            this.maskedTextBox_intervalo.Name = "maskedTextBox_intervalo";
            this.maskedTextBox_intervalo.PromptChar = '-';
            this.maskedTextBox_intervalo.Size = new System.Drawing.Size(70, 22);
            this.maskedTextBox_intervalo.TabIndex = 2;
            this.maskedTextBox_intervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem,
            this.limparSessõesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 48);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // limparSessõesToolStripMenuItem
            // 
            this.limparSessõesToolStripMenuItem.Name = "limparSessõesToolStripMenuItem";
            this.limparSessõesToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.limparSessõesToolStripMenuItem.Text = "Limpar";
            // 
            // button_confirmar
            // 
            this.button_confirmar.Image = global::HorarioMaker.Properties.Resources.check;
            this.button_confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_confirmar.Location = new System.Drawing.Point(14, 133);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(130, 30);
            this.button_confirmar.TabIndex = 4;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = true;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancelar.Image = global::HorarioMaker.Properties.Resources.cancel;
            this.button_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cancelar.Location = new System.Drawing.Point(167, 133);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(130, 30);
            this.button_cancelar.TabIndex = 9;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // EditarFilme
            // 
            this.AcceptButton = this.button_confirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancelar;
            this.ClientSize = new System.Drawing.Size(319, 175);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_confirmar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_titulo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarFilme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Filme";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limparSessõesToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_intervalo;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_creditos;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_pub;
        private System.Windows.Forms.Button button_cancelar;
    }
}