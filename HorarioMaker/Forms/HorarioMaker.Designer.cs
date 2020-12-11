namespace HorarioMaker
{
    partial class HorarioMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HorarioMaker));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verSessõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader_nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_pub = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_intervalo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_creditos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_duracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_filmes = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button_opcoes = new System.Windows.Forms.Button();
            this.button_horario = new System.Windows.Forms.Button();
            this.button_defenirSessoes = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_sair = new System.Windows.Forms.Button();
            this.button_sessoes = new System.Windows.Forms.Button();
            this.button_remover = new System.Windows.Forms.Button();
            this.button_editar = new System.Windows.Forms.Button();
            this.button_adicionar = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verSessõesToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 70);
            // 
            // verSessõesToolStripMenuItem
            // 
            this.verSessõesToolStripMenuItem.Image = global::HorarioMaker.Properties.Resources.glasses;
            this.verSessõesToolStripMenuItem.Name = "verSessõesToolStripMenuItem";
            this.verSessõesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.verSessõesToolStripMenuItem.Text = "Ver Sessões";
            this.verSessõesToolStripMenuItem.Click += new System.EventHandler(this.button_sessoes_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::HorarioMaker.Properties.Resources.edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.button_editar_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = global::HorarioMaker.Properties.Resources.trash;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.button_remover_Click);
            // 
            // columnHeader_nome
            // 
            this.columnHeader_nome.Text = "Nome:";
            this.columnHeader_nome.Width = 320;
            // 
            // columnHeader_pub
            // 
            this.columnHeader_pub.Text = "Publicidade:";
            this.columnHeader_pub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_pub.Width = 110;
            // 
            // columnHeader_intervalo
            // 
            this.columnHeader_intervalo.Text = "Intervalo:";
            this.columnHeader_intervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_intervalo.Width = 101;
            // 
            // columnHeader_creditos
            // 
            this.columnHeader_creditos.Text = "Créditos:";
            this.columnHeader_creditos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_creditos.Width = 100;
            // 
            // columnHeader_duracao
            // 
            this.columnHeader_duracao.Text = "Duração:";
            this.columnHeader_duracao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_duracao.Width = 106;
            // 
            // listView_filmes
            // 
            this.listView_filmes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_nome,
            this.columnHeader_pub,
            this.columnHeader_intervalo,
            this.columnHeader_creditos,
            this.columnHeader_duracao});
            this.listView_filmes.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_filmes.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView_filmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_filmes.FullRowSelect = true;
            this.listView_filmes.GridLines = true;
            this.listView_filmes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_filmes.Location = new System.Drawing.Point(121, 0);
            this.listView_filmes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listView_filmes.MultiSelect = false;
            this.listView_filmes.Name = "listView_filmes";
            this.listView_filmes.Size = new System.Drawing.Size(743, 425);
            this.listView_filmes.TabIndex = 1;
            this.listView_filmes.UseCompatibleStateImageBehavior = false;
            this.listView_filmes.View = System.Windows.Forms.View.Details;
            this.listView_filmes.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_filmes_ColumnWidthChanging);
            this.listView_filmes.DoubleClick += new System.EventHandler(this.button_editar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Developed by\r\nRicardo Teixeira";
            // 
            // button_opcoes
            // 
            this.button_opcoes.Image = global::HorarioMaker.Properties.Resources.options_icon;
            this.button_opcoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_opcoes.Location = new System.Drawing.Point(3, 292);
            this.button_opcoes.Name = "button_opcoes";
            this.button_opcoes.Size = new System.Drawing.Size(113, 36);
            this.button_opcoes.TabIndex = 11;
            this.button_opcoes.Text = "Opções";
            this.button_opcoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_opcoes.UseVisualStyleBackColor = true;
            this.button_opcoes.Click += new System.EventHandler(this.button_opcoes_Click);
            // 
            // button_horario
            // 
            this.button_horario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_horario.Image = ((System.Drawing.Image)(resources.GetObject("button_horario.Image")));
            this.button_horario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_horario.Location = new System.Drawing.Point(3, 173);
            this.button_horario.Name = "button_horario";
            this.button_horario.Size = new System.Drawing.Size(113, 36);
            this.button_horario.TabIndex = 9;
            this.button_horario.Text = "Horário/Salas";
            this.button_horario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_horario.UseVisualStyleBackColor = true;
            this.button_horario.Click += new System.EventHandler(this.button_horario_Click);
            // 
            // button_defenirSessoes
            // 
            this.button_defenirSessoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_defenirSessoes.Image = ((System.Drawing.Image)(resources.GetObject("button_defenirSessoes.Image")));
            this.button_defenirSessoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_defenirSessoes.Location = new System.Drawing.Point(3, 92);
            this.button_defenirSessoes.Name = "button_defenirSessoes";
            this.button_defenirSessoes.Size = new System.Drawing.Size(113, 36);
            this.button_defenirSessoes.TabIndex = 8;
            this.button_defenirSessoes.Text = "Definir Sessões";
            this.button_defenirSessoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_defenirSessoes.UseVisualStyleBackColor = true;
            this.button_defenirSessoes.Click += new System.EventHandler(this.button_defenirSessoes_Click);
            // 
            // button_guardar
            // 
            this.button_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_guardar.Image = ((System.Drawing.Image)(resources.GetObject("button_guardar.Image")));
            this.button_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_guardar.Location = new System.Drawing.Point(3, 252);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(113, 36);
            this.button_guardar.TabIndex = 7;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_sair
            // 
            this.button_sair.Image = global::HorarioMaker.Properties.Resources.logout;
            this.button_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_sair.Location = new System.Drawing.Point(3, 333);
            this.button_sair.Name = "button_sair";
            this.button_sair.Size = new System.Drawing.Size(113, 36);
            this.button_sair.TabIndex = 6;
            this.button_sair.Text = "Sair";
            this.button_sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_sair.UseVisualStyleBackColor = true;
            this.button_sair.Click += new System.EventHandler(this.button_sair_Click);
            // 
            // button_sessoes
            // 
            this.button_sessoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sessoes.Image = global::HorarioMaker.Properties.Resources.glasses;
            this.button_sessoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_sessoes.Location = new System.Drawing.Point(3, 133);
            this.button_sessoes.Name = "button_sessoes";
            this.button_sessoes.Size = new System.Drawing.Size(113, 36);
            this.button_sessoes.TabIndex = 5;
            this.button_sessoes.Text = "Ver Sessões";
            this.button_sessoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_sessoes.UseVisualStyleBackColor = true;
            this.button_sessoes.Click += new System.EventHandler(this.button_sessoes_Click);
            // 
            // button_remover
            // 
            this.button_remover.Image = global::HorarioMaker.Properties.Resources.trash;
            this.button_remover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_remover.Location = new System.Drawing.Point(3, 212);
            this.button_remover.Name = "button_remover";
            this.button_remover.Size = new System.Drawing.Size(113, 36);
            this.button_remover.TabIndex = 4;
            this.button_remover.Text = "Remover";
            this.button_remover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_remover.UseVisualStyleBackColor = true;
            this.button_remover.Click += new System.EventHandler(this.button_remover_Click);
            // 
            // button_editar
            // 
            this.button_editar.Image = global::HorarioMaker.Properties.Resources.edit;
            this.button_editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_editar.Location = new System.Drawing.Point(3, 52);
            this.button_editar.Name = "button_editar";
            this.button_editar.Size = new System.Drawing.Size(113, 36);
            this.button_editar.TabIndex = 3;
            this.button_editar.Text = "Editar";
            this.button_editar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_editar.UseVisualStyleBackColor = true;
            this.button_editar.Click += new System.EventHandler(this.button_editar_Click);
            // 
            // button_adicionar
            // 
            this.button_adicionar.Image = global::HorarioMaker.Properties.Resources.add;
            this.button_adicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_adicionar.Location = new System.Drawing.Point(3, 10);
            this.button_adicionar.Name = "button_adicionar";
            this.button_adicionar.Size = new System.Drawing.Size(113, 36);
            this.button_adicionar.TabIndex = 2;
            this.button_adicionar.Text = "Adicionar";
            this.button_adicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_adicionar.UseVisualStyleBackColor = true;
            this.button_adicionar.Click += new System.EventHandler(this.button_adicionar_Click);
            // 
            // HorarioMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 425);
            this.Controls.Add(this.button_opcoes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_horario);
            this.Controls.Add(this.button_defenirSessoes);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.button_sair);
            this.Controls.Add(this.button_sessoes);
            this.Controls.Add(this.button_remover);
            this.Controls.Add(this.button_editar);
            this.Controls.Add(this.button_adicionar);
            this.Controls.Add(this.listView_filmes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "HorarioMaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horário Maker  v1.0 - Software developed for NOS Lusomundo D.V.Douro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HorarioMaker_FormClosing);
            this.Load += new System.EventHandler(this.HorarioMaker_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verSessõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.Button button_adicionar;
        private System.Windows.Forms.Button button_editar;
        private System.Windows.Forms.Button button_remover;
        private System.Windows.Forms.Button button_sessoes;
        private System.Windows.Forms.Button button_sair;
        private System.Windows.Forms.ColumnHeader columnHeader_nome;
        private System.Windows.Forms.ColumnHeader columnHeader_pub;
        private System.Windows.Forms.ColumnHeader columnHeader_intervalo;
        private System.Windows.Forms.ColumnHeader columnHeader_creditos;
        private System.Windows.Forms.ColumnHeader columnHeader_duracao;
        private System.Windows.Forms.ListView listView_filmes;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_defenirSessoes;
        private System.Windows.Forms.Button button_horario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_opcoes;
    }
}

