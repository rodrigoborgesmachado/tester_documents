using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PdfSharp.Drawing;
using System.Xml;
using Tester_Documents.Model;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Tester_Documents.Util
{
    public class Documento
    {
        #region Estruturas

        /// <summary>
        /// Estrutura referente às infromações principais presentes na saída do documento
        /// </summary>
        public struct Info_principaisTexto
        {
            public string TITULO;
            public string INFORMACOES;
            public string DADOS_INFO;
            public bool paginacao;
            public int numero_pagina;
            public int numero_linhas;
            public FileInfo csv_file;
        }

        /// <summary>
        /// Estrutura referente às informações do PDF
        /// </summary>
        public struct Info_PDF_file
        {
            public string AUTHOR;
            public DateTime CREATION_DATE;
            public string CREATOR; // application that creates the file
            public DateTime MODIFICATIONDATE;
            public string SUBJECT;
            public string TITLE;
            public string KEYWORDS;
        }

        #endregion Estruturas

        #region Atributos e Propriedades

        protected FileInfo file_selected;
        /// <summary>
        /// Arquivo de leitura para geração do relatório
        /// </summary>
        public FileInfo FileInfo
        {
            get
            {
                return file_selected;
            }
            set
            {
                this.file_selected = value;
            }
        }

        string nome = "";
        /// <summary>
        /// Nome do arquivo de saída
        /// </summary>
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

       

        #endregion Atributos e Propriedades

        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="file_in"></param>
        public Documento(FileInfo file_in)
        {
            this.file_selected = file_in;
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que verifica se o diretório existe
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        protected bool VerificaExisteDirectory(string caminho)
        {
            Util.CL_Files.WriteOnTheLog("Documento.VerificaExisteDirectory", Global.TipoLog.DETALHADO);
            return Directory.Exists(caminho);
        }

        /// <summary>
        /// Método que verifica se o arquivo existe
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        protected bool VerificaExisteFile(string caminho)
        {
            Util.CL_Files.WriteOnTheLog("Documento.VerificaExisteFile", Global.TipoLog.DETALHADO);
            return File.Exists(caminho);
        }

        /// <summary>
        /// Método que monta o arquivo html. O arquivo é gerado de forma tabulada, então as linhas do arquivo de importação se~rão referentes a: primeria serão os nomes das colunas e demais as outras linhas da tabela
        /// </summary>
        /// <param name="linhas_arquivo">linhas que estão no arquivo para plotagem do html</param>
        /// <param name="nome_arquivoSaida">Nome do arquivo de saída</param>
        /// <param name="mensagemErro">Controle da mensagem caso haja algum erro</param>
        /// <returns></returns>
        protected bool MontaHTML(List<string> linhas_arquivo, string nome_arquivoSaida, out string mensagemErro, Info_principaisTexto text_info)
        {
            Util.CL_Files.WriteOnTheLog("Documento.MontaHTML", Global.TipoLog.DETALHADO);

            mensagemErro = "";
            try
            {
                string html_start = "<!DOCTYPE html><html lang=\"pt-br\">";
                string head =   "<head> " +
                                "  <title></title> " +
                                "  <meta charset=\"UTF-8\"> " +
                                "  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> " +
                                "  <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css\"> " +
                                "  <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js\"></script> " +
                                "  <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js\"></script> " +
                                "</head> ";
                string styles = @"<style>
                                        .titulo{
                                        	margin-bottom: 20px;
                                        	text-align: left;
                                        	float: left;
                                        }
                                        .informacoes{
                                        	text-align: right;
                                        	float: right;
                                        }
                                  </style>";

                string body = html_start + head + styles +
                              "<body>" +
                              " <div class=\"container\">" +
                              "  <div id=\"menu\"> " +
                              "     <div> " +
                              "	        <h1 class=\"titulo\"> " + text_info.TITULO + "  </h1> " +
                              "	        <h4 class=\"informacoes\"> " + text_info.INFORMACOES + "</h4>  " +
                              "     </div>";
                body +=       "     <table class=\"table table-striped\">";
                
                bool first = true;
                foreach (string text in linhas_arquivo)
                {
                    if (first)
                    {
                        body += "<thead>" +
                                "       <tr>";
                    }
                    else
                    {
                        body += "   <tr>";
                    }

                    List<string> texto_completo = text.Split(';').ToList();
                    foreach(string conteudo in texto_completo)
                    {
                        if (first)
                        {
                            body += "   <th scope=\"col\">" + conteudo + "</th>";                                  
                        }
                        else
                        {
                            body += "   <td>" + conteudo + "</td>";
                        }
                    }

                    if (first)
                    {
                        body +=   "     </tr>" +
                                  "</thead>";
                        body +=   "<tbody>";
                    }
                    else
                    {
                        body += "</tr>";
                    }

                    first = false;
                }

                body +=       "         </tbody>" +
                              "     </table>" +
                              (
                              text_info.paginacao ?
                              "     <div class=\"form - group\">" +
                              "         <div class=\"col-sm-offset-11 col-sm-10\">" + 
                              "             Page " +   text_info.numero_pagina +
                              "         </div>" +
                              "     </div>"
                              :
                              "") +
                              "   </div>" +
                              "</div>" +
                              "</body>" +
                              "</html>";

                if (File.Exists(nome_arquivoSaida))
                    File.Delete(nome_arquivoSaida);

                File.AppendAllText(nome_arquivoSaida, body);

                return true;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
        }

        /// <summary>
        /// Método que gera o relátorio a partir do arquivo instanciado na classe
        /// </summary>
        /// <param name="caminho_saida"></param>
        /// <param name="mensagemErro"></param>
        /// <returns></returns>
        public virtual bool GerarRelatorio(string caminho_saida, out string mensagemErro) { mensagemErro = ""; return false; }

        /// <summary>
        /// Método que monta o arquivo html. O arquivo é gerado de forma tabulada, então as linhas do arquivo de importação se~rão referentes a: primeria serão os nomes das colunas e demais as outras linhas da tabela
        /// </summary>
        /// <param name="linhas_arquivo">linhas que estão no arquivo para plotagem do html</param>
        /// <param name="nome_arquivoSaida">Nome do arquivo de saída</param>
        /// <param name="mensagemErro">Controle da mensagem caso haja algum erro</param>
        /// <returns></returns>
        protected bool MontaHTMLTabulado(List<string> linhas_arquivo, string nome_arquivoSaida, out string mensagemErro, Info_principaisTexto text_info)
        {
            Util.CL_Files.WriteOnTheLog("Documento.MontaHTMLTabulado", Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                string html_start = "<!DOCTYPE html><html lang=\"pt-br\">";
                string head = "<head> " +
                                "  <title></title> " +
                                "  <meta charset=\"UTF-8\"> " +
                                "  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> " +
                                "  <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css\"> " +
                                "  <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js\"></script> " +
                                "  <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js\"></script> " +
                                "</head> ";
                string styles = @"<style>
                                        .titulo{
                                        	margin-bottom: 20px;
                                        	text-align: left;
                                        	float: left;
                                        }
                                        .informacoes{
                                        	text-align: right;
                                        	float: right;
                                        }
                                        table
	                                    {
	                                    	table-layout: fixed;
                                            float: center;
	                                    }
                                        .img
										{
											padding-left: 20px;
										}
                                        body
										{
											text-align: justify;
                                            -webkit-hyphens: auto;
                                            -moz-hyphens: auto;
                                            -ms-hyphens: auto;
                                            hyphens: auto;
										}
                                  </style>";

                string body = html_start + head + styles +
                              "<body>" +
                              " <div class=\"container-fluid\">" +
                              "  <div id=\"menu\" class=\"container-fluid\"> " +
                              "     <table> " +
                              "         <tr>" +
                              "             <td>" +
                              "                 <div class=\"container-fluid\"> " +
                              "	                    <h1 class=\"titulo\"> " + text_info.TITULO + "  </h1> " +
                              "	                    <h4 class=\"informacoes\"> " + text_info.INFORMACOES + "</h4>  " +
                              "                 </div>" +
                              "             </td>" +
                              "         </tr>";

                if (!string.IsNullOrEmpty(text_info.DADOS_INFO))
                {
                    body += "     <tr><td><div class=\"container-fluid\"><br> " + text_info.DADOS_INFO.Replace("\\tabelatitulos", "<thead>").Replace("\\etabelatitulos", "</thead>").Replace("\\tabelacorpo", "<tbody>").Replace("\\etabelacorpo", "</tbody>").Replace("\\tabela", "<table class=\"table table-striped\">").Replace("\\etabela", "</table>").Replace("\\linha", "<tr>").Replace("\\elinha", "</tr>").Replace("\\coluna","<td>").Replace("\\ecoluna", "</td>").Replace("\t", "<p>").Replace("\n","</p><br>").Replace("\\t", "<b>").Replace("\\et","</b>").Replace("\\i", "<i>").Replace("\\ei","</i>").Replace("\\center", "<center>").Replace("\\ecenter", "</center>").Replace("\\u", "<u>").Replace("\\eu", "</u>") + "</div></td></tr>";
                }
                else
                    body += "     <tr><td><div class=\"container-fluid\"><br></div></td></tr>";

                if(linhas_arquivo.Count > 0)
                {
                    body += " <tr><td><div class=\"container-fluid\">" +
                        "     <table class=\"img\">";

                    bool first = true;
                    foreach (string text in linhas_arquivo)
                    {
                        body += "   <tr>";

                        List<string> texto_completo = text.Split(';').ToList();
                        foreach (string conteudo in texto_completo)
                        {
                            if (first)
                                body += "   <th scope=\"col\">" + conteudo + "</th>";
                            else if (conteudo.Contains("<img"))
                                body += "   <td width=\"700px\" height=\"700px\">" + conteudo + "</td>";
                            else
                                body += "   <td><p style=\"margin-right: 10px;\">" + conteudo + "</p></td>";
                        }

                        body += "</tr>";

                        first = false;
                    }

                    body += " " +
                                  "     </table>" +
                                  "   </div></td></tr>   " +
                                  (
                                  text_info.paginacao ?
                                  "     <tr><td><div class=\"form-group\">" +
                                  "         <div class=\"col-sm-offset-11 col-sm-10\">" +
                                  "             Page " + text_info.numero_pagina +
                                  "         </div>" +
                                  "     </div></td></tr>"
                                  :
                                  "") +
                                  "     </table>" +
                                  "   </div>";
                }
                body+=        "     </div>" +
                              " </body>" +
                              "</html>";

                if (File.Exists(nome_arquivoSaida))
                    File.Delete(nome_arquivoSaida);

                File.AppendAllText(nome_arquivoSaida, body);

                return true;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
        }

        /// <summary>
        /// Sobrescreção do método que cria a imagem, mas cria apenas imagens jpeg
        /// </summary>
        /// <param name="caminhoHTML"></param>
        /// <param name="nome_arquivoSaida"></param>
        /// <param name="mensagemErro"></param>
        /// <returns></returns>
        protected bool MontaImagemFromHtml(string caminhoHTML, string nome_arquivoSaida, out string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Documento.MontaImagemFromHtml", Global.TipoLog.DETALHADO);
            return MontaImagemFromHtml(caminhoHTML, nome_arquivoSaida, out mensagemErro, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        /// <summary>
        /// Método que cria uma imagem a partir do arquivo html. Essa imagem terá os tamanhos padrão de uma folha A4: 794x1158
        /// </summary>
        /// <param name="caminhoHTML">Caminho onde está o html para criação da imagem</param>
        /// <param name="nome_arquivoSaida"></param>
        /// <param name="mensagemErro"></param>
        /// <returns></returns>
        protected bool MontaImagemFromHtml(string caminhoHTML, string nome_arquivoSaida, out string mensagemErro, System.Drawing.Imaging.ImageFormat format)
        {
            Util.CL_Files.WriteOnTheLog("Documento.MontaImagemFromHtml", Global.TipoLog.DETALHADO);

            mensagemErro = "";
            try
            {
                // Verifica se o arquivo html para ser criada a imagem existe
                if (!VerificaExisteFile(caminhoHTML))
                {
                    mensagemErro = "Arquivo " + caminhoHTML + " não existe!";
                    return false;
                }

                //Monta imagem
                WebBrowser web = new WebBrowser();

                web.ScrollBarsEnabled = false; // we don't want scrollbars on our image
                web.ScriptErrorsSuppressed = true; // don't let any errors shine through
                web.Size = new Size(Global.width_ImagemA4, Global.height_ImagemA4);

                web.Navigate(caminhoHTML);

                while (web.ReadyState != WebBrowserReadyState.Complete)
                    Application.DoEvents();

                web.Width = Global.width_ImagemA4;
                web.Height = Global.height_ImagemA4;

                Bitmap bmp = new System.Drawing.Bitmap(Global.width_ImagemA4, Global.height_ImagemA4);

                web.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, Global.width_ImagemA4, Global.height_ImagemA4));
                web.Dispose();

                if (File.Exists(nome_arquivoSaida))
                    File.Delete(nome_arquivoSaida);

                bmp.Save(nome_arquivoSaida, format);
                bmp.Dispose();
                return true;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
        }

        /// <summary>
        /// Método que monta um arquivo pdf a partir de imagens. O método cria um arquivo pdf a partir de uma imagem com a página no tamanho de uma página A4 comum
        /// </summary>
        /// <param name="caminhoImagem">Diretório das imagens a serem tratada</param>
        /// <param name="nome_arquivoSaida">Diretório de saída do arquivo pdf</param>
        /// <param name="mensagemErro">String que controla a mensagem caso exista algum erro</param>
        /// <returns>True o arquivo PDF foi gerado com sucesso</returns>
        public bool MontaPDFFromImages(List<string> caminhoImagem, string nome_arquivoSaida, Info_PDF_file info, out string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Documento.MontaPDFFromImages", Global.TipoLog.DETALHADO);

            mensagemErro = "";
            try
            {
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                document.Info.Author = info.AUTHOR;
                document.Info.CreationDate = info.CREATION_DATE;
                document.Info.Creator = info.CREATOR;
                document.Info.Title = info.TITLE;
                document.Info.Keywords = info.KEYWORDS;
                
                PdfSharp.Pdf.PdfPage page;
                XGraphics gfx;

                foreach(string caminho in caminhoImagem)
                {
                    if (!VerificaExisteFile(caminho))
                    {
                        mensagemErro = "A imagem " + caminho + " não existe!";
                        return false;
                    }

                    XImage image = XImage.FromFile(caminho);

                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    gfx.DrawImage(image, 0, 0);
                    gfx.Save();
                    page.Close();

                    page = null;
                    image.Dispose();
                    gfx.Dispose();
                }

                document.Save(nome_arquivoSaida);
                document.Close();
                document.Dispose();

                return true;
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
        }

        /// <summary>
        /// Método que monta um arquivo pdf a partir de uma imagem. O método cria um arquivo pdf a partir de uma imagem com a página no tamanho de uma página A4 comum
        /// </summary>
        /// <param name="caminhoImagem">Diretório da imagem a ser tratada</param>
        /// <param name="nome_arquivoSaida">Diretório de saída do arquivo pdf</param>
        /// <param name="mensagemErro">String que controla a mensagem caso exista algum erro</param>
        /// <returns>True o arquivo PDF foi gerado com sucesso</returns>
        public bool MontaPDFFromImage(string caminhoImagem, string nome_arquivoSaida, Info_PDF_file info, out string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("Documento.MontaPDFFromImage", Global.TipoLog.DETALHADO);

            mensagemErro = "";
            try
            {
                if (!VerificaExisteFile(caminhoImagem))
                {
                    mensagemErro = "Arquivo de imagem " + caminhoImagem + " não existe!";
                    return false;
                }

                XImage image = XImage.FromFile(caminhoImagem);
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

                document.Info.Author = info.AUTHOR;
                document.Info.CreationDate = info.CREATION_DATE;
                document.Info.Creator = info.CREATOR;
                document.Info.Title = info.TITLE;

                PdfSharp.Pdf.PdfPage page;
                XGraphics gfx;

                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                gfx.DrawImage(image, 0, 0);
                gfx.Save();
                page.Close();

                page = null;
                image.Dispose();
                gfx.Dispose();

                document.Save(nome_arquivoSaida);
                document.Close();
                document.Dispose();

                return true;
            }
            catch(Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog(mensagemErro, Global.TipoLog.SIMPLES);
                return false;
            }
        }

        /// <summary>
        /// Método que retorna as informações do arquivo a ser gerado
        /// </summary>
        /// <returns>Estrutura com as informações do arquivo a ser gerado</returns>
        public Info_PDF_file GetInfo()
        {
            MD_PDFInformations informacoes = new MD_PDFInformations(0);
            if (informacoes.Empty)
                informacoes.Insert();

            Info_PDF_file info = new Info_PDF_file();
            info.AUTHOR = informacoes.Author ;
            info.CREATION_DATE = informacoes.DataCriacaoPDF;
            info.CREATOR = informacoes.Creator;
            info.MODIFICATIONDATE = informacoes.DatamodificacaoPDF;
            info.SUBJECT = informacoes.Subject;
            info.TITLE = informacoes.Title;
            info.KEYWORDS = informacoes.KeyWords;

            return info;
        }

        /// <summary>
        /// Método que copia o arquivo de log
        /// </summary>
        public static void CopiarLog()
        {
            try
            {
                string file = "";
                string[] files = Directory.GetFiles(Util.Global.app_logs_directoty);
                DateTime maior_data = DateTime.Now;

                for (int i = 0; i < files.Count(); i++)
                {
                    FileInfo info = new FileInfo(files[i]);
                    if (i == 0 || maior_data < info.CreationTime)
                    {
                        file = files[i];
                        maior_data = info.CreationTime;
                    }
                    info = null;
                }

                MD_PDFInformations model = new Model.MD_PDFInformations(0);

                if (File.Exists(model.Dirlog))
                    File.Delete(model.Dirlog);

                if (files.Count() > 0)
                    File.Copy(file, model.Dirlog);
            }
            catch(Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Erro ao copiar o log. Erro: " + e.Message, Global.TipoLog.SIMPLES);
            }
        }

        #endregion Métodos
    }
}
