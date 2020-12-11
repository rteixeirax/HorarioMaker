namespace HorarioMaker
{
    partial class AdicionarSessoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarSessoes));
            this.comboBox_filmes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_inserir = new System.Windows.Forms.Button();
            this.maskedTextBox_sessao = new System.Windows.Forms.MaskedTextBox();
            this.listView_sessoes = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Limpar = new System.Windows.Forms.Button();
            this.button_sair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_filmes
            // 
            this.comboBox_filmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_filmes.FormattingEnabled = true;
            this.comboBox_filmes.Location = new System.Drawing.Point(59, 12);
            this.comboBox_filmes.Name = "comboBox_filmes";
            this.comboBox_filmes.Size = new System.Drawing.Size(182, 24);
            this.comboBox_filmes.TabIndex = 0;
            this.comboBox_filmes.SelectedIndexChanged += new System.EventHandler(this.comboBox_filmes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filme:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_inserir);
            this.groupBox1.Controls.Add(this.maskedTextBox_sessao);
            this.groupBox1.Location = new System.Drawing.Point(112, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 108);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inserir Sessão";
            // 
            // button_inserir
            // 
            this.button_inserir.Image = global::HorarioMaker.Properties.Resources.check;
            this.button_inserir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_inserir.Location = new System.Drawing.Point(27, 65);
            this.button_inserir.Name = "button_inserir";
            this.button_inserir.Size = new System.Drawing.Size(77, 27);
            this.button_inserir.TabIndex = 2;
            this.button_inserir.Text = "Inserir";
            this.button_inserir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_inserir.UseVisualStyleBackColor = true;
            this.button_inserir.Click += new System.EventHandler(this.button_inserir_Click);
            // 
            // maskedTextBox_sessao
            // 
            this.maskedTextBox_sessao.Location = new System.Drawing.Point(18, 33);
            this.maskedTextBox_sessao.Mask = "00:00";
            this.maskedTextBox_sessao.Name = "maskedTextBox_sessao";
            this.maskedTextBox_sessao.PromptChar = '-';
            this.maskedTextBox_sessao.Size = new System.Drawing.Size(93, 22);
            this.maskedTextBox_sessao.TabIndex = 1;
            this.maskedTextBox_sessao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_sessao.ValidatingType = typeof(System.DateTime);
            // 
            // listView_sessoes
            // 
            this.listView_sessoes.BackColor = System.Drawing.SystemColors.Menu;
            this.listView_sessoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_sessoes.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_sessoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_sessoes.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listView_sessoes.GridLines = true;
            this.listView_sessoes.Location = new System.Drawing.Point(14, 23);
            this.listView_sessoes.MultiSelect = false;
            this.listView_sessoes.Name = "listView_sessoes";
            this.listView_sessoes.Size = new System.Drawing.Size(46, 124);
            this.listView_sessoes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_sessoes.TabIndex = 3;
            this.listView_sessoes.TileSize = new System.Drawing.Size(50, 50);
            this.listView_sessoes.UseCompatibleStateImageBehavior = false;
            this.listView_sessoes.View = System.Windows.Forms.View.List;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = global::HorarioMaker.Properties.Resources.trash;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_sessoes);
            this.groupBox2.Controls.Add(this.button_Limpar);
            this.groupBox2.Location = new System.Drawing.Point(12, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(78, 185);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sessões";
            // 
            // button_Limpar
            // 
            this.button_Limpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Limpar.Image = global::HorarioMaker.Properties.Resources.clear;
            this.button_Limpar.Location = new System.Drawing.Point(14, 153);
            this.button_Limpar.Name = "button_Limpar";
            this.button_Limpar.Size = new System.Drawing.Size(46, 25);
            this.button_Limpar.TabIndex = 4;
            this.button_Limpar.UseVisualStyleBackColor = true;
            this.button_Limpar.Click += new System.EventHandler(this.button_Limpar_Click);
            // 
            // button_sair
            // 
            this.button_sair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sair.Image = global::HorarioMaker.Properties.Resources.cancel;
            this.button_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_sair.Location = new System.Drawing.Point(112, 200);
            this.button_sair.Name = "button_sair";
            this.button_sair.Size = new System.Drawing.Size(129, 29);
            this.button_sair.TabIndex = 5;
            this.button_sair.Text = "Fechar";
            this.button_sair.UseVisualStyleBackColor = true;
            this.button_sair.Click += new System.EventHandler(this.button_sair_Click);
            // 
            // AdicionarSessoes
            // 
            this.AcceptButton = this.button_inserir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_sair;
            this.ClientSize = new System.Drawing.Size(253, 240);
            this.Controls.Add(this.button_sair);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_filmes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdicionarSessoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Definir Sessões";
            this.Load += new System.EventHandler(this.AdicionarHorarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_filmes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_inserir;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_sessao;
        private System.Windows.Forms.ListView listView_sessoes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.Button button_Limpar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_sair;
    }
}