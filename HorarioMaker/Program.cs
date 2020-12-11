using HorarioMaker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorarioMaker
{
    static class Program
    {
        public static Model m_modelo { get; private set; }
        public static HorarioMaker v_horarioMaker { get; private set; }
        public static AdicionarFilme v_adicionarFilme { get; private set; }
        public static AdicionarSessoes v_adicionarSessoes { get; private set; }
        public static EditarFilme v_editarFilme { get; private set; }
        public static VerSessoes v_verSessoes { get; private set; }        
        public static CriarHorario v_criarHorario { get; private set; }
        public static EscolherFilme v_escolherFilme { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            m_modelo = new Model();
            v_horarioMaker = new HorarioMaker();
            v_adicionarFilme = new AdicionarFilme();
            v_adicionarSessoes = new AdicionarSessoes();
            v_editarFilme = new EditarFilme();
            v_verSessoes = new VerSessoes();           ;
            v_criarHorario = new CriarHorario();
            v_escolherFilme = new EscolherFilme();
        
            Application.Run(v_horarioMaker);
        }
    }
}
