using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMaker.Util
{
    public static class Global
    {
        // Caminho principal da aplicação
        public static string app_main_directoty = System.IO.Directory.GetCurrentDirectory() + "\\";

        public static string app_teste_document_file = app_main_directoty + "Tester_Documents";

        // Caminho da pasta de arquivos do sistema
        public static string app_files_directory = app_main_directoty + "Files\\";

        // Caminho da pasta de projetos
        public static string app_proj_directory(Model.MD_Project project)
        {
            return app_files_directory + "Projects\\" + project.NumeroTarefa + "\\";
        }

        // Caminho da pasta de RRM do sistema
        public static string app_RRM_directory(Model.MD_Project project)
        {
            return app_proj_directory(project) + "RRM\\";
        }

        // Caminho da pasta de RRM do sistema
        public static string app_Prints_directory(Model.MD_Project project)
        {
            return app_proj_directory(project) + "PRINTS\\";
        }

        // Caminho da pasta de logs do sistema
        public static string app_logs_directoty = app_main_directoty + "Log\\";

        // Caminho da pasta de arquivos temporários
        public static string app_temp_directory = app_main_directoty + "TEMP\\";

        // Nome do diretório de saída
        public static string app_out_directory = app_main_directoty + "OUT\\";

        // Nome do diretório de configuração
        public static string app_conf_directory = app_main_directoty + "CONF\\";
        
        // Nome do diretório do banco de dados
        public static string app_base_directory = app_main_directoty + "BASE\\";

        // Nome do arquivo sqlite de configuração
        public static string app_base_file = app_base_directory + "pckdb.db3";

        // Nome do arquivo html temporário
        public static string app_conf_file = app_conf_directory + "config.xml";

        // Nome do arquivo html temporário
        public static string app_temp_html_file = app_temp_directory + "file_html.html";

        // Nome da imagem temporária 
        public static string app_temp_image_file = app_temp_directory + "file_png.png";

        // Nome do arquivo json temporário
        public static string app_temp_file_json = app_temp_directory + "file_json.json";

        // Nome do arquivo csv temporário
        private static string app_empty_file_csv = app_temp_directory + "empty.csv";

        // Diretório de backup
        public static string app_backup_directory = app_main_directoty + "Backup\\";

        // Nome do arquivo de backup a ser gerado
        public static string nome_arquivo_backup = app_backup_directory + "backup_file.bkp";

        

        public static string App_empty_file_csv
        {
            get
            {
                if (!File.Exists(app_empty_file_csv))
                {
                    File.AppendAllText(app_empty_file_csv, "");
                }
                return app_empty_file_csv;
            }
        }

        // Nome do arquivo csv temporário
        public static string app_temp_file_csv = app_temp_directory + "saida.csv";

        // Nome do arquivo xml temporário
        public static string app_temp_file_xml = app_temp_directory + "saida.xml";

        // Tamanho da imagem
        public static int width_ImagemA4 = 794;
        public static int height_ImagemA4 = 1158;

        /// <summary>
        /// Enumerador referente ao tipo de log que o sistema irá persistir
        /// </summary>
        public enum TipoLog
        {
            DETALHADO = 0,
            SIMPLES = 1
        }

        public static TipoLog log_system = TipoLog.SIMPLES;
    }
}
