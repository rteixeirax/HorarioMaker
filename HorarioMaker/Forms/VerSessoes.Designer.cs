namespace HorarioMaker.Forms
{
    partial class VerSessoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerSessoes));
            this.listView_sessoes = new System.Windows.Forms.ListView();
            this.columnHeader_inicio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_intervalo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_fim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_fechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_sessoes
            // 
            this.listView_sessoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_sessoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_inicio,
            this.columnHeader_intervalo,
            this.columnHeader_fim});
            this.listView_sessoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_sessoes.FullRowSelect = true;
            this.listView_sessoes.GridLines = true;
            this.listView_sessoes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_sessoes.Location = new System.Drawing.Point(16, 15);
            this.listView_sessoes.Margin = new System.Windows.Forms.Padding(4);
            this.listView_sessoes.MultiSelect = false;
            this.listView_sessoes.Name = "listView_sessoes";
            this.listView_sessoes.Size = new System.Drawing.Size(239, 167);
            this.listView_sessoes.TabIndex = 0;
            this.listView_sessoes.UseCompatibleStateImageBehavior = false;
            this.listView_sessoes.View = System.Windows.Forms.View.Details;
            this.listView_sessoes.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_sessoes_ColumnWidthChanging);
            // 
            // columnHeader_inicio
            // 
            this.columnHeader_inicio.Text = "Inicio";
            this.columnHeader_inicio.Width = 75;
            // 
            // columnHeader_intervalo
            // 
            this.columnHeader_intervalo.Text = "Intervalo";
            this.columnHeader_intervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_intervalo.Width = 80;
            // 
            // columnHeader_fim
            // 
            this.columnHeader_fim.Text = "Fim";
            this.columnHeader_fim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_fim.Width = 76;
            // 
            // button_fechar
            // 
            this.button_fechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fechar.Image = global::HorarioMaker.Properties.Resources.cancel;
            this.button_fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_fechar.Location = new System.Drawing.Point(91, 190);
            this.button_fechar.Margin = new System.Windows.Forms.Padding(4);
            this.button_fechar.Name = "button_fechar";
            this.button_fechar.Size = new System.Drawing.Size(85, 28);
            this.button_fechar.TabIndex = 1;
            this.button_fechar.Text = "Fechar";
            this.button_fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_fechar.UseVisualStyleBackColor = true;
            this.button_fechar.Click += new System.EventHandler(this.button_fechar_Click);
            // 
            // VerSessoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_fechar;
            this.ClientSize = new System.Drawing.Size(270, 225);
            this.Controls.Add(this.button_fechar);
            this.Controls.Add(this.listView_sessoes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerSessoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sessões";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView_sessoes;
        private System.Windows.Forms.Button button_fechar;
        private System.Windows.Forms.ColumnHeader columnHeader_inicio;
        private System.Windows.Forms.ColumnHeader columnHeader_intervalo;
        private System.Windows.Forms.ColumnHeader columnHeader_fim;
    }
}