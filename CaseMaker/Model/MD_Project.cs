using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CaseMaker.Util.Enumerator;

namespace CaseMaker.Model
{
    /// <summary>
    /// [MAKDOCUMENTS] Classe referente à tabela MAKDOCUMENTS
    /// </summary>
    public class MD_Project : MDN_Model
    {
        #region Atributos e Propriedades

        int codigo = 0;
        /// <summary>
        /// [CODIGOPROJ] Código do projeto
        /// </summary>
        public int Codigo
        {
            get
            {
                return codigo;
            }
        }

        string nome = "";
        /// <summary>
        /// [NOMEPROJ] Nome do relatório
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

        string descricao = "";
        /// <summary>
        /// [DESCRICAOPROJ] Descrição do relatório
        /// </summary>
        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }

        DateTime data_ciracao = DateTime.Now;
        /// <summary>
        /// [DATA_CRIACAO] Data de criação do relatório
        /// </summary>
        public DateTime DataCriacao
        {
            get
            {
                return data_ciracao;
            }
            set
            {
                data_ciracao = value;
            }
        }

        int numero_tarefa = 0;
        /// <summary>
        /// [TAREFA] Número da tarefa correspondente à tarefa
        /// </summary>
        public int NumeroTarefa
        {
            get
            {
                return numero_tarefa;
            }
            set
            {
                numero_tarefa = value;
            }
        }

        string dir_rrm = "";
        /// <summary>
        /// [DIR_RRM] Diretório do RRM para ser salvo
        /// </summary>
        public string Diretorio_RRM
        {
            get
            {
                return dir_rrm;
            }
            set
            {
                dir_rrm = value;
            }
        }

        string nome_programador = "";
        /// <summary>
        /// [NOME_PROGRAMADOR] Nome do programador que desenvolveu a regra
        /// </summary>
        public string NomeProgramador
        {
            get
            {
                return nome_programador;
            }
            set
            {
                nome_programador = value;
            }
        }

        string nome_analista= "";
        /// <summary>
        /// [NOME_PROGRAMADOR] Nome do analista que analisou a regra
        /// </summary>
        public string NomeAnalista
        {
            get
            {
                return nome_analista;
            }
            set
            {
                nome_analista = value;
            }
        }

        string nome_tester = "";
        /// <summary>
        /// [NOME_TESTER] Nome do tester que testará a regra
        /// </summary>
        public string NomeTester
        {
            get
            {
                return nome_tester;
            }
            set
            {
                nome_tester = value;
            }
        }

        ProjType tipo = ProjType.MUDANCA;
        /// <summary>
        /// [TIPOPROJ] Tipo do projeto
        /// </summary>
        public ProjType Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        string versao_sistema = "00.00.00";
        /// <summary>
        /// [VERSAOSYSTEM]Versão que o RRM será lançado (previsão)
        /// </summary>
        public string VersaoSistema
        {
            get
            {
                return versao_sistema;
            }
            set
            {
                versao_sistema = value;
            }
        }

        Sistema sistema = Sistema.SFV;
        /// <summary>
        /// [PRODUTO] Produto o qual o projeto está associado
        /// </summary>
        public Sistema Produto
        {
            get
            {
                return sistema;
            }
            set
            {
                sistema = value;
            }
        }

        #endregion Atributos e Propriedades

        #region Construtores

        /// <summary>
        /// Construtor base da classe
        /// </summary>
        MD_Project()
            : base()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.MD_Project()", Util.Global.TipoLog.DETALHADO);
            base.table = new MDN_Table("MAKDOCUMENTS");
            this.table.Fields_Table.Add(new MDN_Campo("CODIGOPROJ",       true, Util.Enumerator.DataType.INT,    null,       true,  true,  15,   0));
            this.table.Fields_Table.Add(new MDN_Campo("NOMEPROJ",         true, Util.Enumerator.DataType.STRING, "",         false, false, 50,   0));
            this.table.Fields_Table.Add(new MDN_Campo("DESCRICAOPROJ",    true, Util.Enumerator.DataType.STRING, "",         false, false, 5000, 0));
            this.table.Fields_Table.Add(new MDN_Campo("DATA_CRIACAO",     true, Util.Enumerator.DataType.INT,    null,       false, false, 0,    0));
            this.table.Fields_Table.Add(new MDN_Campo("TAREFA",           true, Util.Enumerator.DataType.INT,    null,       true,  false, 0,    0));
            this.table.Fields_Table.Add(new MDN_Campo("DIR_RRM",          true, Util.Enumerator.DataType.STRING, "",         false, false, 300,  0));
            this.table.Fields_Table.Add(new MDN_Campo("NOME_PROGRAMADOR", true, Util.Enumerator.DataType.STRING, "",         false, false, 100,  0));
            this.table.Fields_Table.Add(new MDN_Campo("NOME_ANALISTA",    true, Util.Enumerator.DataType.STRING, "",         false, false, 100,  0));
            this.table.Fields_Table.Add(new MDN_Campo("NOME_TESTER",      true, Util.Enumerator.DataType.STRING, "",         false, false, 100,  0));
            this.table.Fields_Table.Add(new MDN_Campo("TIPOPROJ",         true, Util.Enumerator.DataType.CHAR,   "0",        false, false, 1,    0));
            this.table.Fields_Table.Add(new MDN_Campo("VERSAOSYSTEM",     true, Util.Enumerator.DataType.STRING, "00.00.00", false, false, 100,  0));
            this.table.Fields_Table.Add(new MDN_Campo("PRODUTO",          true, Util.Enumerator.DataType.CHAR,   "0",        false, false, 1,    0));

            if (!base.table.ExistsTable())
                base.table.CreateTable(false);

            base.table.VerificaColunas();
        }

        /// <summary>
        /// Construtor para a classe 
        /// </summary>
        /// <param name="nome_vacina">Nome da Vacina.</param>
        public MD_Project(int codigo, int nutarefa)
            : this()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.MD_Project(codigo)", Util.Global.TipoLog.DETALHADO);
            this.codigo = codigo;
            this.numero_tarefa = nutarefa;
            this.Load();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método que faz o load da classe
        /// </summary>
        public override void Load()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.Load()", Util.Global.TipoLog.DETALHADO);
            string sentenca = base.table.CreateCommandSQLTable() + " WHERE CODIGOPROJ = " + this.codigo + " AND TAREFA = " + this.numero_tarefa;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            if (reader == null)
                this.Empty = true;
            else if (reader.Read())
            {
                Nome = reader["NOMEPROJ"].ToString();
                Descricao = reader["DESCRICAOPROJ"].ToString();
                DataCriacao = Util.DataBase.Int_to_Date(int.Parse(reader["DATA_CRIACAO"].ToString()));
                Diretorio_RRM = reader["DIR_RRM"].ToString();
                NomeProgramador = reader["NOME_PROGRAMADOR"].ToString();
                NomeAnalista = reader["NOME_ANALISTA"].ToString();
                NomeTester = reader["NOME_TESTER"].ToString();
                Tipo = (reader["TIPOPROJ"].ToString().Equals("0") ? ProjType.MUDANCA : ProjType.CORRECAO);
                VersaoSistema = reader["VERSAOSYSTEM"].ToString();
                Produto = reader["PRODUTO"].ToString().Equals("0") ? Sistema.SFV : Sistema.FLEX;
                
                this.Empty = false;
                reader.Close();
            }
            else
            {
                this.Empty = true;
                reader.Close();
            }
                
        }

        /// <summary>
        /// Método que deleta o objeto
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.Delete()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "DELETE FROM " + this.table.Table_Name + " WHERE CODIGOPROJ = " + this.Codigo + " AND TAREFA = " + this.NumeroTarefa;
            return Util.DataBase.Delete(sentenca);
        }

        /// <summary>
        /// Método que faz o insert do objeto
        /// </summary>
        /// <returns>True - Insert efetuado com sucesso; False - Erro ao inserir</returns>
        public override bool Insert()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.Insert()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "INSERT INTO " + this.table.Table_Name + " (CODIGOPROJ, NOMEPROJ, DESCRICAOPROJ, DATA_CRIACAO, TAREFA, DIR_RRM, NOME_PROGRAMADOR, NOME_ANALISTA, NOME_TESTER, TIPOPROJ, VERSAOSYSTEM, PRODUTO) VALUES (" +
                              Codigo + ", '" +
                              Nome + "', '" + 
                              Descricao + "', " +
                              Util.DataBase.Date_to_Int(DataCriacao) +" , " +
                              NumeroTarefa + ", '" + 
                              Diretorio_RRM + "', '" +
                              NomeProgramador + "', '" +
                              NomeAnalista + "', '" +
                              NomeTester + "', '" +
                              (Tipo == ProjType.MUDANCA ? "0" : "1") + "', '" +
                              VersaoSistema + "', '" +
                              (Produto == Sistema.SFV ? "0" : "1") + "'" +
                              ")";
            if (Util.DataBase.Insert(sentenca))
            {
                MD_Estimativa estimativa = new MD_Estimativa(Util.DataBase.GetIncrement("MAKDOCUMENTS"), this);
                estimativa.Insert();
                Empty = false;
                return true;
            }
            else 
                return false;
        }

        /// <summary>
        /// Método que faz o update do objeto
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.Update()", Util.Global.TipoLog.DETALHADO);

            string sentenca = "UPDATE " + table.Table_Name + " SET " +
                              "  NOMEPROJ =  '" + Nome + "', " +
                              "  DESCRICAOPROJ =  '" + Descricao + "', " +
                              "  DATA_CRIACAO =  " + Util.DataBase.Date_to_Int(DataCriacao) + ", " +
                              "  DIR_RRM =  '" + Diretorio_RRM + "', " +
                              "  NOME_PROGRAMADOR =  '" + NomeProgramador + "', " +
                              "  NOME_ANALISTA =  '" + NomeAnalista + "', " +
                              "  NOME_TESTER =  '" + NomeTester + "', " +
                              "  TIPOPROJ =  '" + (Tipo == ProjType.MUDANCA ? "0" : "1") + "', " +
                              "  VERSAOSYSTEM = '" + VersaoSistema + "', " +
                              "  PRODUTO = '" + (Produto == Sistema.SFV ? "0" : "1") + "'" +
                              " WHERE CODIGOPROJ = " + Codigo;

            return Util.DataBase.Update(sentenca);
        }

        /// <summary>
        /// Método que copia o arquivo selecionado para a pasta do sistema e retorna o novo caminho do arquivo
        /// </summary>
        /// <returns>Novo arquivo do caminho</returns>
        public string CopiaArquivo(string diretorio)
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.CopiaArquivo()", Util.Global.TipoLog.DETALHADO);
            string caminho = Util.Global.app_RRM_directory(this);

            try
            {
                if (string.IsNullOrEmpty(diretorio))
                    return "";
                
                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                FileInfo info = new FileInfo(diretorio);
                caminho += info.Name.Split('.')[0] + "_" + Codigo + info.Extension;
                if (File.Exists(caminho))
                    File.Delete(caminho);
                File.Copy(diretorio, caminho);
            }
            catch(Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Erro: " + e.Message, Util.Global.TipoLog.SIMPLES);
            }
            return caminho;
        }

        /// <summary>
        /// Método que retorna todos os projetos
        /// </summary>
        /// <returns></returns>
        public SQLiteDataReader RetornaTodosProjetos()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.RetornaTodosProjetos()", Util.Global.TipoLog.DETALHADO);
            string sentenca = base.table.CreateCommandSQLTable();
            return Util.DataBase.Select(sentenca);
        }

        /// <summary>
        /// Método que retorna a estimativa vinculada ao projeto
        /// </summary>
        /// <returns></returns>
        public MD_Estimativa GetEstimativa()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.GetEstimativa()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "SELECT CODIGOEST FROM MAKESTIMATIVAS WHERE TAREFA = " + this.NumeroTarefa;
            int codigo = -1;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            if (reader == null)
                return null;
            else if (reader.Read())
            {
                codigo = int.Parse(reader["CODIGOEST"].ToString());
                reader.Close();
            }
            return new MD_Estimativa(codigo, this);
        }

        /// <summary>
        /// Método que retorna os cenários vinculados ao projeto
        /// </summary>
        /// <returns></returns>
        public List<MD_Cenario> GetCenarios()
        {
            Util.CL_Files.WriteOnTheLog("MD_Project.GetCenarios()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "SELECT CODIGOCEN FROM MAKCENARIOS WHERE TAREFA = " + this.NumeroTarefa;
            int codigo = -1;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);

            List<MD_Cenario> cenarios = new List<MD_Cenario>();
            if (reader == null)
                return null;
            else while (reader.Read())
            {
                    cenarios.Add(new MD_Cenario(int.Parse(reader["CODIGOCEN"].ToString()), this));
            }
            reader.Close();
            return cenarios;
        }

        #endregion Métodos
    }
}
