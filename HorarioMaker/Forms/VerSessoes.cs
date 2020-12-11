using HorarioMaker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorarioMaker.Forms
{
    public partial class VerSessoes : Form
    {
        public VerSessoes()
        {
            InitializeComponent();
        }

        // Com este evento bloquea as colunas e nao deixa "alargar" as mesma.
        private void listView_sessoes_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_sessoes.Columns[e.ColumnIndex].Width;
        }

        public void ApresentarSessoes(int indice)
        {
            this.Text = "Filme:  " + Program.m_modelo.ListaDeFilmes[indice].Titulo;

            listView_sessoes.Items.Clear();

            foreach (Sessao sessao in Program.m_modelo.ListaDeFilmes[indice].ListaDeSessoes)
            {
                ListViewItem item = new ListViewItem(sessao.Inicio);
                item.SubItems.Add(sessao.Intervalo);
                item.SubItems.Add(sessao.Fim);

                item.Font = new Font(listView_sessoes.Font.ToString(), 9, FontStyle.Regular);

                listView_sessoes.Items.Add(item);
            }

            this.ShowDialog();
        }

        private void button_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
