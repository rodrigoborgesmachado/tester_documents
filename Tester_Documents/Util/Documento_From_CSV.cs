using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester_Documents.Util
{
    public class Documento_From_CSV : Documento
    {
        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="file">Arquivo para se gerar o relatório</param>
        public Documento_From_CSV(FileInfo file)
            : base(file)
        {

        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que gera o relátorio a partir do arquivo instanciado na classe
        /// </summary>
        /// <param name="caminho_saida"></param>
        /// <param name="mensagemErro"></param>
        /// <returns></returns>
        public override bool GerarRelatorio(string caminho_saida, out string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Documento_From_CSV.GerarRelatorio", Global.TipoLog.DETALHADO);
            mensagemErro = "";
            bool sucesso = true;

            try
            {
                if (!base.VerificaExisteFile(file_selected.FullName))
                {
                    mensagemErro = "File " + file_selected.FullName + " do not exists";
                    return false;
                }
                if (!VerificaExisteDirectory(caminho_saida))
                    Directory.CreateDirectory(caminho_saida);
                if (!VerificaExisteDirectory(Global.app_main_directoty))
                    Directory.CreateDirectory(Global.app_main_directoty);
                if (!VerificaExisteDirectory(Global.app_temp_directory))
                    Directory.CreateDirectory(Global.app_temp_directory);

                Model.MD_PDFInformations informations = new Model.MD_PDFInformations(0);

                Info_principaisTexto info = new Info_principaisTexto();
                info.TITULO = informations.Title;
                info.INFORMACOES = "";
                info.paginacao = false;

                StreamReader streamReader = new StreamReader(file_selected.FullName);
                List<string> arquivo = new List<string>();
                bool acabei_entrar = false;
                int cont = 0;
                List<string> imagens = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    try
                    {
                        string linha = streamReader.ReadLine();
                        arquivo.Add(linha);
                        acabei_entrar = false;
                        if ((arquivo.Count >= 24 && sucesso))
                        {

                            acabei_entrar = true;
                            if (MontaHTML(arquivo, Global.app_temp_html_file, out mensagemErro, info))
                            {
                                imagens.Add(Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg");
                                if (MontaImagemFromHtml(Global.app_temp_html_file, Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg", out mensagemErro))
                                {
                                    sucesso = true;
                                }
                                else
                                {
                                    sucesso = false;
                                }
                            }
                            else
                            {
                                sucesso = false;
                            }

                            arquivo = new List<string>();
                            cont++;
                        }
                    }
                    catch (Exception e)
                    {
                        mensagemErro = "Error: " + e.Message;
                        return false;
                    }
                }
                if (!acabei_entrar)
                {
                    if (MontaHTML(arquivo, Global.app_temp_html_file, out mensagemErro, info))
                    {
                        imagens.Add(Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg");
                        if (MontaImagemFromHtml(Global.app_temp_html_file, Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg", out mensagemErro))
                        {
                            sucesso = true;
                        }
                        else
                        {
                            sucesso = false;
                        }
                    }
                    else
                    {
                        sucesso = false;
                    }
                }
                if (sucesso)
                {
                    Info_PDF_file info2 = GetInfo();

                    sucesso = MontaPDFFromImages(imagens, caminho_saida + "\\" + file_selected.Name.Split('.')[0] + ".pdf", info2, out mensagemErro);

                    foreach (string cam in imagens)
                    {
                        File.Delete(cam);
                    }
                }

                streamReader.Close();
                streamReader.Dispose();
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Erro ao gerar o relatório. Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }

            return sucesso;
        }

        #endregion Métodos
    }
}
