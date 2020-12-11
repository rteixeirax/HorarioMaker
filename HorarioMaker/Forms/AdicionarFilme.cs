using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorarioMaker
{
    public partial class AdicionarFilme : Form
    {
        public AdicionarFilme()
        {
            InitializeComponent();
        }

        //Cada vez que é feito o load da Form os campos são colocados a "Zero".
        private void AdicionarFilme_Load(object sender, EventArgs e)
        {
            textBox_titulo.Text = "";
            maskedTextBox_pub.Text = "00:00:00";
            maskedTextBox_intervalo.Text = "00:00:00";
            maskedTextBox_creditos.Text = "00:00:00";           
        }

        private void button_adicionar_Click(object sender, EventArgs e)
        {
            bool flag = false; // false -> nao existe, true -> existe.
             
            if (textBox_titulo.Text.Length != 0) 
            {             
                string [] intervalo = maskedTextBox_intervalo.Text.Split(':');
                string [] creditos = maskedTextBox_creditos.Text.Split(':');

                //try -> catch para alertar o utilizador que os valores inseridos estão incompletos, por exemplo [00:--:--].
                //Se os valores estiverem incompletos dá erro na conversão para inteiro. Com esta ciclo evitamos que o programa "crash".
                try
                {
                    //Limita a inserção dos valores dentro dos valores horários. [23:59:59]
                    if (int.Parse(intervalo[0]) >= 0 && int.Parse(intervalo[0]) <= 23
                        && int.Parse(intervalo[1]) >= 0 && int.Parse(intervalo[1]) <= 59
                        && int.Parse(intervalo[2]) >= 0 && int.Parse(intervalo[2]) <= 59

                        && int.Parse(creditos[0]) >= 0 && int.Parse(creditos[0]) <= 23
                        && int.Parse(creditos[1]) >= 0 && int.Parse(creditos[1]) <= 59
                        && int.Parse(creditos[2]) >= 0 && int.Parse(creditos[2]) <= 59
                        && int.Parse(maskedTextBox_pub.Text) >= 0 && int.Parse(maskedTextBox_pub.Text) <= 59) // Não era necessário verificar a publicidade, verifico para o Try -> catch apanhar os valores incompletos.
                    {

                        for (int i = 0; i < Program.m_modelo.ListaDeFilmes.Count; i++)
                        {
                            if (textBox_titulo.Text == Program.m_modelo.ListaDeFilmes[i].Titulo)
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag == true)
                        {
                            MessageBox.Show("Já existe um filme com o mesmo título na lista de filmes.",
                                   "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Program.m_modelo.AdicionarFilme(textBox_titulo.Text, maskedTextBox_pub.Text,
                                              maskedTextBox_intervalo.Text, maskedTextBox_creditos.Text,
                                              Program.m_modelo.CalcularDuracao(maskedTextBox_pub.Text, maskedTextBox_creditos.Text));

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tempos inseridos não se encontram dentro dos limites horários. [23:59:59]", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Os valores inseridos estão incompletos.\nErro comum, deixar espaços vazios -> [ 00:--:-- ].", "Alerta",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }               
            }
            else
            {
                MessageBox.Show("Necessita definir o título do filme!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {           
            this.Close();
        }
    }
}
