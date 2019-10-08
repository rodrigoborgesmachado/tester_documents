using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester_Documents.Util
{
    public static class Global
    {
        // Caminho principal da aplicação
        public static string app_main_directoty = System.IO.Directory.GetCurrentDirectory() + "\\";

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

        // Nome da imagem temporária 
        public static string app_temp_file_xml = app_temp_directory + "file_xml.xml";

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
