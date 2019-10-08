using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester_Documents
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Util.CL_Files.CreateMainDirectories();
            Util.CL_Files.WriteOnTheLog("", Util.Global.TipoLog.SIMPLES);
            Util.CL_Files.WriteOnTheLog("", Util.Global.TipoLog.SIMPLES);
            Util.CL_Files.WriteOnTheLog("----------------------------------------------------------------------------------------------------------------------", Util.Global.TipoLog.SIMPLES);
            Util.CL_Files.WriteOnTheLog("Iniciando Programa", Util.Global.TipoLog.SIMPLES);
            Util.CL_Files.WriteOnTheLog("Program.Main", Util.Global.TipoLog.DETALHADO);

            if (args.Length <= 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FO_Main());
            }
            else
            {
                try
                {
                    string file_in = "";
                    string directory_out = "";
                    string mensagemErro = "";

                    if (!CarregaParametros(args, out file_in, out directory_out, out mensagemErro))
                    {
                        Util.CL_Files.WriteOnTheLog(mensagemErro, Util.Global.TipoLog.SIMPLES);
                        Console.WriteLine(mensagemErro);
                        return;
                    }

                    System.IO.FileInfo arquivo = new System.IO.FileInfo(file_in);

                    if (Create(file_in, directory_out, out mensagemErro))
                    {
                        Console.WriteLine("Arquivo gerado com sucesso. " + directory_out + "\\" + arquivo.Name.Replace(arquivo.Extension, "") + ".pdf");
                        Util.Documento.CopiarLog();
                        Util.CL_Files.WriteOnTheLog("Arquivo gerado com sucesso. " + directory_out + "\\" + arquivo.Name.Replace(arquivo.Extension, "") + ".pdf", Util.Global.TipoLog.SIMPLES);
                    }
                    else
                    {
                        Console.WriteLine("Erro ao gerar o PDF! Verificar o log " + Util.Global.app_logs_directoty);
                        Util.CL_Files.WriteOnTheLog("Erro ao gerar o PDF! Erro: " + mensagemErro, Util.Global.TipoLog.SIMPLES);
                    }
                    arquivo = null;
                }
                catch(Exception e)
                {
                    Util.CL_Files.WriteOnTheLog("Erro: " + e.Message, Util.Global.TipoLog.SIMPLES);
                }

            }
            Util.CL_Files.WriteOnTheLog("Finalizando Programa", Util.Global.TipoLog.SIMPLES);
            Util.CL_Files.WriteOnTheLog("----------------------------------------------------------------------------------------------------------------------", Util.Global.TipoLog.SIMPLES);
        }

        /// <summary>
        /// Méotodo que carrega os parêmetros passados em referência caso os mesmos existam.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="file_in"></param>
        /// <param name="directory_out"></param>
        private static bool CarregaParametros(string[] args, out string file_in, out string directory_out, out string mensagemErro)
        {
            file_in = directory_out = mensagemErro = "";

            if (args.Length < 2)
            {
                Console.WriteLine("Não há argumentos suficientes");
                Util.CL_Files.WriteOnTheLog("Não há argumentos suficientes", Util.Global.TipoLog.SIMPLES);
                return false;
            }

            bool entrada, saida, log, configuracao;
            saida = entrada = log = configuracao = false;
            List<string> lista = args.ToList();
            string diretorio_configuracao = "";
            
            foreach(string linha in lista)
            {
                if (entrada)
                {
                    entrada = false;
                    file_in = linha;
                    Util.CL_Files.WriteOnTheLog("Arquivo de entrada: " + file_in, Util.Global.TipoLog.SIMPLES);
                    continue;
                }
                else if (saida)
                {
                    saida = false;
                    directory_out = linha;
                    Util.CL_Files.WriteOnTheLog("Diretório de saída: " + directory_out, Util.Global.TipoLog.SIMPLES);
                    continue;
                }
                else if (configuracao)
                {
                    configuracao = false;
                    diretorio_configuracao = linha;
                    Util.CL_Files.WriteOnTheLog("Configuracao: " + diretorio_configuracao, Util.Global.TipoLog.SIMPLES);
                    continue;
                }

                if (linha.ToLower().Equals("-i"))
                {
                    entrada = true;
                }
                else if (linha.ToLower().Equals("-o"))
                {
                    saida = true;
                }
                else if (linha.ToLower().Equals("-l"))
                {
                    log = true;
                }
                else if (linha.ToLower().Equals("-c"))
                {
                    configuracao = true;
                }
            }

            /// O log será ativado sempre que existir a tag -l no comando
            if (log)
            {
                log = false;
                Util.CL_Files.WriteOnTheLog("Log: Detalhado", Util.Global.TipoLog.SIMPLES);
                Util.Global.log_system = Util.Global.TipoLog.DETALHADO;
            }
            else
                Util.CL_Files.WriteOnTheLog("Log: Simples", Util.Global.TipoLog.SIMPLES);

            if (string.IsNullOrEmpty(file_in))
            {
                Console.WriteLine("Primeiro argumento deve ser de entrada: -i 'arquivo de entrada'");
                Util.CL_Files.WriteOnTheLog("Não há argumentos suficientes", Util.Global.TipoLog.SIMPLES);
                return false;
            }

            if (string.IsNullOrEmpty(directory_out))
            {
                directory_out = Util.Global.app_out_directory;
            }

            if (!string.IsNullOrEmpty(diretorio_configuracao))
            {
                CarregaConfiguracao(diretorio_configuracao, ref mensagemErro);
            }

            return true;
        }

        /// <summary>
        /// Método que cria o arquivo de saída
        /// </summary>
        public static bool Create(string file_in, string directory_out, out string menssagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Program.Create", Util.Global.TipoLog.DETALHADO);
            if (string.IsNullOrEmpty(file_in))
            {
                menssagemErro = "Arquivo de entrada não encontrado!";
                Util.CL_Files.WriteOnTheLog(menssagemErro, Util.Global.TipoLog.SIMPLES);
                return false;
            }
            if (string.IsNullOrEmpty(directory_out))
            {
                menssagemErro = "Diretório de saída não encontrado!";
                Util.CL_Files.WriteOnTheLog(menssagemErro, Util.Global.TipoLog.SIMPLES);
                return false;
            }

            System.IO.FileInfo arquivo = new System.IO.FileInfo(file_in);
            Tester_Documents.Util.Documento documento = new Util.Documento(arquivo);

            if (arquivo.Extension == ".csv")
                documento = new Util.Documento_From_CSV(arquivo);
            else if (arquivo.Extension == ".xml")
                documento = new Util.Documento_From_XML(arquivo);

            bool result = documento.GerarRelatorio(directory_out, out menssagemErro);

            return string.IsNullOrEmpty(menssagemErro);
        }

        /// <summary>
        /// Método que carrega o arquivo json de configuração
        /// </summary>
        /// <param name="caminho_arquivo">Caminho do arquivo json de configuração</param>
        /// <param name="mensagemErro">Variável para controle de mensagem de erro</param>
        /// <returns>True - Leitura das configurações efetuada com sucesso; False - erro ao ler o arquivo</returns>
        public static bool CarregaConfiguracao(string caminho_arquivo, ref string mensagemErro)
        {
            try
            {
                Util.CL_Files.WriteOnTheLog("Program.CarregaConfiguracao", Util.Global.TipoLog.DETALHADO);
                mensagemErro = "";
                if (!File.Exists(caminho_arquivo))
                {
                    mensagemErro = "O arquivo " + caminho_arquivo + " de configuração não existe!";
                    Util.CL_Files.WriteOnTheLog(mensagemErro, Util.Global.TipoLog.DETALHADO);
                    return false;
                }
                FileInfo file = new FileInfo(caminho_arquivo);
                if (!file.Extension.Equals(".json"))
                {
                    mensagemErro = "O arquivo de configuração não é um arquivo JSON!";
                    Util.CL_Files.WriteOnTheLog(mensagemErro, Util.Global.TipoLog.DETALHADO);
                    return false;
                }
                file = null;

                StreamReader stream = new StreamReader(caminho_arquivo);

                JObject response = JsonConvert.DeserializeObject<JObject>(stream.ReadToEnd());

                stream.Close();
                stream.Dispose();
                Model.MD_PDFInformations info = new Model.MD_PDFInformations(0);
                foreach (JToken o in response.PropertyValues())
                {
                    switch (o.Path.ToUpper())
                    {
                        case "AUTOR":
                            info.Author = o.ToString();
                            break;
                        case "CRIACAO":
                            if (string.IsNullOrEmpty(o.ToString()))
                                info.DataCriacaoPDF = DateTime.Now;
                            else
                                info.DataCriacaoPDF = DateTime.Parse(o.ToString());
                            break;
                        case "CRIADOR":
                            info.Creator = o.ToString();
                            break;
                        case "MODIFICACAO":
                            if (string.IsNullOrEmpty(o.ToString()))
                                info.DatamodificacaoPDF = DateTime.Now;
                            else
                                info.DatamodificacaoPDF = DateTime.Parse(o.ToString());
                            break;
                        case "ASSUNTO":
                            info.Subject = o.ToString();
                            break;
                        case "TITULO":
                            info.Title = o.ToString();
                            break;
                        case "LOG":
                            info.Dirlog = o.ToString();
                            break;
                    }
                }
                info.Insert();
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;

                Util.CL_Files.WriteOnTheLog("Houve erro na leitura do arquivo de configuração. Erro: " + mensagemErro, Util.Global.TipoLog.SIMPLES);
                Util.CL_Files.WriteOnTheLog("Configuração carregada com erro!", Util.Global.TipoLog.DETALHADO);
                return false;
            }
            Util.CL_Files.WriteOnTheLog("Configuração carregada com sucesso!", Util.Global.TipoLog.DETALHADO);
            return true;
        }
    }
}
