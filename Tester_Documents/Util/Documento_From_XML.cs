using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tester_Documents.Util
{
    public class Documento_From_XML : Documento
    {
        #region Construtores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        /// <param name="file">Arquivo para se gerar o relatório</param>
        public Documento_From_XML(FileInfo file)
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
            Util.CL_Files.WriteOnTheLog("Documento_From_XML.GerarRelatorio", Global.TipoLog.DETALHADO);
            mensagemErro = "";
            bool sucesso = true;

            try
            {
                if (!VerificaExisteFile(file_selected.FullName))
                {
                    mensagemErro = "File " + file_selected.FullName + " do not exists";
                    return false;
                }
                if (!VerificaExisteDirectory(caminho_saida))
                    Directory.CreateDirectory(caminho_saida);

                List<Info_principaisTexto> informacoes = new List<Info_principaisTexto>();

                Info_principaisTexto info = new Info_principaisTexto();
                info.paginacao = false;

                XmlTextReader xml_file = new XmlTextReader(file_selected.FullName);

                bool element = false, text = false, endelement = false;
                string tag = "";

                while (xml_file.Read())
                {
                    switch (xml_file.NodeType)
                    {
                        case XmlNodeType.Element:
                            text = false;
                            element = true;
                            endelement = false;
                            break;
                        case XmlNodeType.EndElement:
                            text = false;
                            element = false;
                            endelement = true;
                            break;
                        case XmlNodeType.Text:
                            text = true;
                            endelement = false;
                            break;
                    }

                    if (text)
                    {
                        if (tag.Equals("title"))
                        {
                            info.TITULO = xml_file.Value;
                        }
                        else if (tag.Equals("informacoes"))
                        {
                            info.INFORMACOES = xml_file.Value;
                        }
                        else if (tag.Equals("text"))
                        {
                            info.DADOS_INFO = xml_file.Value;
                        }
                        else if (tag.Equals("table_lines"))
                        {
                            info.numero_linhas = int.Parse(xml_file.Value);
                        }
                        else if (tag.Equals("csv_file"))
                        {
                            info.csv_file = new FileInfo(xml_file.Value);
                        }
                        element = text = false;
                    }

                    if (element)
                    {
                        tag = xml_file.LocalName;
                        element = false;
                    }
                        

                    if (endelement)
                    {
                        tag = xml_file.LocalName;

                        if (tag.Equals("page"))
                        {
                            int totalPossible = 5391;
                            List<Info_principaisTexto> lista = new List<Info_principaisTexto>();

                            string texto = info.DADOS_INFO;
                            if (!string.IsNullOrEmpty(texto))
                            {
                                List<string> mensagens = texto.Split('|').ToList();
                                bool entrei = false;

                                foreach(string t in mensagens)
                                {
                                    if (entrei)
                                        info.TITULO = "";

                                    entrei = true;

                                    info.DADOS_INFO = t;

                                    int numero_quebralinha = info.DADOS_INFO.Substring(0, info.DADOS_INFO.Length < totalPossible ? info.DADOS_INFO.Length : totalPossible).Split('\n').Count();
                                    totalPossible -= (numero_quebralinha * 200);
                                    if (totalPossible < 0) totalPossible = 2300;

                                    if (info.DADOS_INFO.Count() > totalPossible)
                                    {
                                        string dados = info.DADOS_INFO;
                                        int pos_ponto, pos_excla, pos_inte, pos_doisp, pos_pontov;
                                        pos_ponto = pos_excla = pos_inte = pos_doisp = pos_pontov = 0;

                                        info.DADOS_INFO = dados.Substring(0, dados.Length < totalPossible ? dados.Length : totalPossible);
                                        pos_ponto = info.DADOS_INFO.LastIndexOf('.');
                                        pos_excla = info.DADOS_INFO.LastIndexOf('!');
                                        pos_inte = info.DADOS_INFO.LastIndexOf('?');
                                        pos_doisp = info.DADOS_INFO.LastIndexOf(':');
                                        pos_pontov = info.DADOS_INFO.LastIndexOf(';');
                                        int maior = Maior(pos_ponto, pos_excla, pos_inte, pos_doisp, pos_pontov);

                                        // mais um porque o ponto entra
                                        info.DADOS_INFO = dados.Substring(0, maior + 1);

                                        dados = dados.Remove(0, info.DADOS_INFO.Count());
                                        lista.Add(info);

                                        while (!string.IsNullOrEmpty(dados))
                                        {
                                            totalPossible = 5391;
                                            numero_quebralinha = dados.Substring(0, (dados.Count() >= totalPossible ? totalPossible : dados.Count())).Split('\n').Count();
                                            totalPossible -= (numero_quebralinha * 200);
                                            if (totalPossible < 0) totalPossible = 2300;

                                            Info_principaisTexto info2 = new Info_principaisTexto();
                                            info2.INFORMACOES = "";
                                            info2.TITULO = "";

                                            info2.DADOS_INFO = dados.Substring(0, (dados.Count() >= totalPossible ? totalPossible : dados.Count()));
                                            pos_ponto = pos_excla = pos_inte = pos_doisp = pos_pontov = 0;
                                            pos_ponto = info2.DADOS_INFO.LastIndexOf('.');
                                            pos_excla = info2.DADOS_INFO.LastIndexOf('!');
                                            pos_inte = info2.DADOS_INFO.LastIndexOf('?');
                                            pos_doisp = info2.DADOS_INFO.LastIndexOf(':');
                                            pos_pontov = info2.DADOS_INFO.LastIndexOf(';');
                                            maior = Maior(pos_ponto, pos_excla, pos_inte, pos_doisp, pos_pontov);
                                            info2.DADOS_INFO = dados.Substring(0, (maior == 0 ? dados.Count() + 1 : maior + 1));

                                            dados = dados.Remove(0, info2.DADOS_INFO.Count());
                                            if (string.IsNullOrEmpty(info2.DADOS_INFO)) break;
                                            lista.Add(info2);
                                        }
                                    }
                                    else
                                    {
                                        lista.Add(info);
                                    }
                                }
                            }
                            else
                            {
                                lista.Add(info);
                            }

                            foreach(Info_principaisTexto i in lista)
                                informacoes.Add(i);

                            info = new Info_principaisTexto();
                        }
                        endelement = false;
                    }
                }

                xml_file.Close();
                xml_file.Dispose();
                List<string> arquivo = new List<string>();
                List<string> imagens = new List<string>();
                int cont = 0;
                foreach (Info_principaisTexto inf in informacoes)
                {
                    info = inf;
                    if (info.csv_file != null)
                    {
                        if (!info.csv_file.Exists)
                        {
                            mensagemErro = "Arquivo csv " + info.csv_file.FullName + " não existe!";
                            return false;
                        }
                    }

                    if(info.csv_file != null)
                    {
                        StreamReader streamReader = new StreamReader(info.csv_file.FullName);
                        bool acabei_entrar = false;

                        while (!streamReader.EndOfStream)
                        {
                            try
                            {
                                string linha = streamReader.ReadLine();
                                arquivo.Add(linha);
                                acabei_entrar = false;
                                if ((arquivo.Count >= info.numero_linhas && sucesso))
                                {

                                    acabei_entrar = true;
                                    if (MontaHTMLTabulado(arquivo, Global.app_temp_html_file, out mensagemErro, info))
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
                                        info.DADOS_INFO = "";
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
                            if (MontaHTMLTabulado(arquivo, Global.app_temp_html_file, out mensagemErro, info))
                            {
                                imagens.Add(Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg");
                                if (MontaImagemFromHtml(Global.app_temp_html_file, Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg", out mensagemErro))
                                {
                                    cont++;
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

                        streamReader.Close();
                        streamReader.Dispose();
                    }
                    else
                    {
                        arquivo = new List<string>();
                        if (MontaHTMLTabulado(arquivo, Global.app_temp_html_file, out mensagemErro, info))
                        {
                            imagens.Add(Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg");
                            if (MontaImagemFromHtml(Global.app_temp_html_file, Global.app_temp_image_file.Split('.')[0] + cont + ".jpeg", out mensagemErro))
                            {
                                cont++;
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
            }
            catch(Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Erro ao gerar o relatório. Erro: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
            return sucesso;
        }

        /// <summary>
        /// Método que retorna o maior valos entre as variáveis
        /// </summary>
        /// <param name="pos_ponto"></param>
        /// <param name="pos_excla"></param>
        /// <param name="pos_inte"></param>
        /// <param name="pos_doisp"></param>
        /// <param name="pos_pontov"></param>
        /// <returns></returns>
        private int Maior(int pos_ponto,int pos_excla,int pos_inte,int pos_doisp,int pos_pontov)
        {
            int maior = pos_ponto;
            if (pos_excla > maior)
                maior = pos_excla;
            else if (pos_inte > maior)
                maior = pos_inte;
            else if (pos_doisp > maior)
                maior = pos_doisp;
            else if (pos_pontov > maior)
                maior = pos_pontov;

            return maior;
        }

        #endregion Métodos
    }
}


