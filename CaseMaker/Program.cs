using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseMaker
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Util.CL_Files.CreateMainDirectories();
            Util.DataBase.OpenConnection();
            Util.Global.log_system = Util.DataBase.GetLog();
            Util.CL_Files.WriteOnTheLog("--------------------------------------Iniciando sistema", Util.Global.TipoLog.SIMPLES);

            // Chamadas das classes modelo para criação das tabelas
            Model.MD_Status status = new Model.MD_Status(0);
            Model.MD_Project project = new Model.MD_Project(0, 0);
            Model.MD_Estimativa estimativa = new Model.MD_Estimativa(0, project);
            Model.MD_Cenario cenario = new Model.MD_Cenario(0, project);
            Model.MD_Anexos a = new Model.MD_Anexos(0, cenario);

            Model.MD_Status.InserirPrincipais();

            Application.Run(new FO_Principal());

            Util.DataBase.CloseConnection();
            Util.CL_Files.WriteOnTheLog("--------------------------------------Finalizando sistema", Util.Global.TipoLog.SIMPLES);
        }
    }
}
