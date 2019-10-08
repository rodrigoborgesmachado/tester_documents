using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester_Documents.Model
{
    /// <summary>
    /// [PDFINFO] Classe que define a vacina
    /// </summary>
    public class MD_PDFInformations : MDN_Model
    {
        #region Atributes and Properties

        int codigo= 0;
        /// <summary>
        /// [CODIGO] Código da informação do PDF.
        /// </summary>
        public int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        string author = "";
        /// <summary>
        /// [AUTHOR] Autor do pdf
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }

        DateTime dataCriacaoPDF = DateTime.Now;
        /// <summary>
        /// [DATA_CRIACAO] Data da criação do arquivo pdf.
        /// </summary>
        public DateTime DataCriacaoPDF
        {
            get
            {
                return dataCriacaoPDF;
            }
            set
            {
                dataCriacaoPDF = value;
            }
        }

        string creator = "";
        /// <summary>
        /// [CREATOR] Aplicativo que criou o pdf
        /// </summary>
        public string Creator
        {
            get
            {
                return creator;
            }
            set
            {
                creator = value;
            }
        }

        DateTime datamodificacaoPDF = DateTime.Now;
        /// <summary>
        /// [DATA_MODIFICACAO] Data de modificação do arquivo pdf.
        /// </summary>
        public DateTime DatamodificacaoPDF
        {
            get
            {
                return datamodificacaoPDF;
            }
            set
            {
                datamodificacaoPDF = value;
            }
        }

        string subject = "";
        /// <summary>
        /// [SUBJECT] Assunto do pdf
        /// </summary>
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        string title = "";
        /// <summary>
        /// [TITLE] Título do pdf
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        string keywords = "";
        /// <summary>
        /// [KEYWORDS] Título do pdf
        /// </summary>
        public string KeyWords
        {
            get
            {
                return keywords;
            }
            set
            {
                keywords = value;
            }
        }

        string dirlog = Util.Global.app_logs_directoty + "log.log";
        /// <summary>
        /// [DIRLOG] Diretório de logs
        /// </summary>
        public string Dirlog
        {
            get
            {
                return dirlog;
            }
            set
            {
                dirlog = value;
            }
        }

        #endregion Atributes and Properties

        #region Constructors

        /// <summary>
        /// Construtor base da classe
        /// </summary>
        MD_PDFInformations()
            : base()
        {
            Util.CL_Files.WriteOnTheLog("MD_PDFInformations.MD_PDFInformations()", Util.Global.TipoLog.DETALHADO);
            base.table = new MDN_Table("PDFINFO");
            this.table.Fields_Table.Add(new MDN_Campo("CODIGO",           true, Util.Enumerator.DataType.INT,    null, true,  true,  15,  0));
            this.table.Fields_Table.Add(new MDN_Campo("AUTHOR",           true, Util.Enumerator.DataType.STRING, null, false, false, 100, 0));
            this.table.Fields_Table.Add(new MDN_Campo("DATA_CRIACAO",     true, Util.Enumerator.DataType.INT,   null, false, false, 0,   0));
            this.table.Fields_Table.Add(new MDN_Campo("CREATOR",          true, Util.Enumerator.DataType.STRING, null, false, false, 100, 0));
            this.table.Fields_Table.Add(new MDN_Campo("DATA_MODIFICACAO", true, Util.Enumerator.DataType.INT,   null, false, false, 0,   0));
            this.table.Fields_Table.Add(new MDN_Campo("SUBJECT",          true, Util.Enumerator.DataType.STRING, null, false, false, 100, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TITLE",            true, Util.Enumerator.DataType.STRING, null, false, false, 100, 0));
            this.table.Fields_Table.Add(new MDN_Campo("KEYWORDS",         true, Util.Enumerator.DataType.STRING, null, false, false, 100, 0));
            this.table.Fields_Table.Add(new MDN_Campo("DIRLOG",           true, Util.Enumerator.DataType.STRING, null, false, false, 100, 0));

            if (!base.table.ExistsTable())
                base.table.CreateTable(false);

            base.table.VerificaColunas();
        }

        /// <summary>
        /// Construtor para a classe vacina.
        /// </summary>
        /// <param name="nome_vacina">Nome da Vacina.</param>
        public MD_PDFInformations(int codigo)
            : this()
        {
            Util.CL_Files.WriteOnTheLog("MD_PDFInformations.MD_PDFInformations(codigo)", Util.Global.TipoLog.DETALHADO);
            this.codigo = codigo;
            this.Load();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Método que deleta a informação
        /// </summary>
        /// <returns>True - excluído com sucesso; False - Erro</returns>
        public override bool Delete()
        {
            Util.CL_Files.WriteOnTheLog("MD_PDFInformations.Delete()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "DELETE FROM " + base.table.Table_Name + " WHERE CODIGO = '" + codigo + "'";
            return Util.DataBase.Delete(sentenca);
        }

        /// <summary>
        /// Método que verifica se a configuração
        /// </summary>
        /// <returns></returns>
        public bool VerificaExiste()
        {
            Util.CL_Files.WriteOnTheLog("MD_PDFInformations.VerificaExiste()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "SELECT 1 FROM " + base.table.Table_Name + " WHERE CODIGO = '" + codigo + "'";
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);

            return reader.Read();
        }

        /// <summary>
        /// Método que faz o insert no banco da configuração
        /// </summary>
        /// <returns></returns>
        public override bool Insert()
        {
            Util.CL_Files.WriteOnTheLog("MD_PDFInformations.Insert()", Util.Global.TipoLog.DETALHADO);
            if (VerificaExiste())
                return Update();

            string sentenca = " INSERT INTO " + base.table.Table_Name + " ( CODIGO, AUTHOR, DATA_CRIACAO, CREATOR, DATA_MODIFICACAO, SUBJECT, TITLE, KEYWORDS, DIRLOG) " +
                              " VALUES (" + Codigo +", '" + Author + "', " + Util.DataBase.Date_to_Int(DataCriacaoPDF) + ", '" + Creator + "', " + Util.DataBase.Date_to_Int(DatamodificacaoPDF) + ", '" + Subject + "', '" + Title + "', '" + KeyWords + "','" + Dirlog +"')";

            return Util.DataBase.Insert(sentenca);
        }

        /// <summary>
        /// Método que faz o load da classe
        /// </summary>
        public override void Load()
        {
            Util.CL_Files.WriteOnTheLog("MD_PDFInformations.Load()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "SELECT  AUTHOR, DATA_CRIACAO, CREATOR, DATA_MODIFICACAO, SUBJECT, TITLE, KEYWORDS, DIRLOG FROM " + base.table.Table_Name + " WHERE CODIGO = '" + codigo + "'";
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);

            if (reader.Read())
            {
                Author = reader["AUTHOR"].ToString();
                DataCriacaoPDF = Util.DataBase.Int_to_Date(int.Parse(reader["DATA_CRIACAO"].ToString()));
                Creator = reader["CREATOR"].ToString();
                DatamodificacaoPDF = Util.DataBase.Int_to_Date(int.Parse(reader["DATA_MODIFICACAO"].ToString()));
                Subject = reader["SUBJECT"].ToString();
                Title = reader["TITLE"].ToString();
                keywords = reader["KEYWORDS"].ToString();
                Dirlog = reader["DIRLOG"].ToString();
                reader.Close();

                Empty = false;
            }
            else
                Empty = true;
        }

        /// <summary>
        /// Método que faz update da classe
        /// </summary>
        /// <returns>True - update executado com sucesso; False - erro</returns>
        public override bool Update()
        {
            Util.CL_Files.WriteOnTheLog("MD_PDFInformations.Update()", Util.Global.TipoLog.DETALHADO);
            string sentenca = " UPDATE " + base.table.Table_Name + " SET " +
                                " AUTHOR =            '" + Author + "'" +
                                " ,DATA_CRIACAO =      " + Util.DataBase.Date_to_Int(DataCriacaoPDF) +
                                " ,CREATOR =           '" + Creator + "'" +
                                " ,DATA_MODIFICACAO =  " + Util.DataBase.Date_to_Int(DatamodificacaoPDF)+
                                " ,SUBJECT =           '" + Subject + "'" +
                                " ,TITLE =             '" + Title + "'" +
                                " ,KEYWORDS =          '" + KeyWords + "'" +
                                " ,DIRLOG =            '" + dirlog + "'" +
                                " WHERE CODIGO = " + codigo;

            return Util.DataBase.Update(sentenca);
        }

        #endregion Methods
    }
}
