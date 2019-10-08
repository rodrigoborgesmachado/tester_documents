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
    /// [MAKCENARIOS] Classe que representa a tabela MAKCENARIOS
    /// </summary>
    public class MD_Cenario : MDN_Model
    {
        #region Atributos e Propriedades

        int codigo = 0;
        /// <summary>
        /// [CODIGOCEN] Código do cenário
        /// </summary>
        public int Codigo
        {
            get
            {
                return codigo;
            }
        }

        int codigo_projeto = 0;
        int numeroTarefa = 0;
        MD_Project project;
        /// <summary>
        /// [TAREFA] Código do projeto que o cenário está associado
        /// </summary>
        public MD_Project Project
        {
            get
            {
                if (project == null)
                    project = new MD_Project(codigo_projeto, numeroTarefa);
                return project;
            }
            set
            {
                project = value;
                codigo_projeto = project.Codigo;
                numeroTarefa = project.NumeroTarefa;
            }
        }

        Reparo reparo = Reparo.NAO;
        /// <summary>
        /// [REPARO] Identifica se o cenário é de reparo ou não
        /// </summary>
        public Reparo EhReparo
        {
            get
            {
                return reparo;
            }
            set
            {
                reparo = value;
            }
        }

        int tarefa = 0;
        /// <summary>
        /// [NUTAREFA] Número da tarefa
        /// </summary>
        public int Tarefa
        {
            get
            {
                return tarefa;
            }
            set
            {
                tarefa = value;
            }
        }

        string versao_sgbd = "0";
        /// <summary>
        /// [VERSAOSGBD] Versão do sgbd
        /// </summary>
        public string VersaoSgbd
        {
            get
            {
                return versao_sgbd;
            }
            set
            {
                versao_sgbd = value;
            }
        }

        Banco tipobanco = Banco.ORACLE;
        /// <summary>
        /// [TIPOBANCO] Tipo de banco de dados utilizado no cenário de testes
        /// </summary>
        public Banco TipoBanco
        {
            get
            {
                return tipobanco;
            }
            set
            {
                tipobanco = value;
            }
        }

        string bancoUtilizado = "-";
        /// <summary>
        /// [BANCOUTIL] Banco utilizado para o teste do cenário
        /// </summary>
        public string BancoUtilizado
        {
            get
            {
                return bancoUtilizado;
            }
            set
            {
                bancoUtilizado = value;
            }
        }

        string entrada = "";
        /// <summary>
        /// [ENTRADA] Entrada do cenário de teste
        /// </summary>
        public string Entrada
        {
            get
            {
                return entrada;
            }
            set
            {
                entrada = value;
            }
        }

        string saida = "";
        /// <summary>
        /// [SAIDA] Saída do cenário de teste
        /// </summary>
        public string Saida
        {
            get
            {
                return saida;
            }
            set
            {
                saida = value;
            }
        }

        string passos = "";
        /// <summary>
        /// [PASSOS] Passos do cenário de teste
        /// </summary>
        public string Passos
        {
            get
            {
                return passos;
            }
            set
            {
                passos = value;
            }
        }

        int status_code = 0;
        MD_Status status;
        /// <summary>
        /// [CODIGOSTAT] Código do status do teste
        /// </summary>
        public MD_Status Status
        {
            get
            {
                if (status == null)
                    status = new MD_Status(status_code);
                return status;
            }
            set
            {
                status = value;
            }
        }

        DateTime dataCriacao = DateTime.Now;
        /// <summary>
        /// [DATA_CRIACAO] Data de criação do cenário
        /// </summary>
        public DateTime DataCriacao
        {
            get
            {
                return dataCriacao;
            }
            set
            {
                dataCriacao = value;
            }
        }

        TipoSistema tipoSistema = TipoSistema.SSI;
        /// <summary>
        /// [SISTEMA] Sistema do cenário de testes
        /// </summary>
        public TipoSistema TipoDoSistema
        {
            get
            {
                return tipoSistema;
            }
            set
            {
                this.tipoSistema = value;
            }
        }

        #endregion Atributos e Propriedades

        #region Contrutores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        MD_Cenario() :
            base()
        {
            Util.CL_Files.WriteOnTheLog("MD_Estimativa.MD_Estimativa()", Util.Global.TipoLog.DETALHADO);
            base.table = new MDN_Table("MAKCENARIOS");
            this.table.Fields_Table.Add(new MDN_Campo("CODIGOCEN", true, Util.Enumerator.DataType.INT, null, true, true, 15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TAREFA", true, Util.Enumerator.DataType.INT, null, false, false, 15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("REPARO", true, Util.Enumerator.DataType.CHAR, "0", false, false, 1, 0));
            this.table.Fields_Table.Add(new MDN_Campo("NUTAREFA", true, Util.Enumerator.DataType.INT, null, false, false, 15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("VERSAOSGBD", true, Util.Enumerator.DataType.STRING, "0", false, false, 25, 0));
            this.table.Fields_Table.Add(new MDN_Campo("TIPOBANCO", true, Util.Enumerator.DataType.CHAR, "0", false, false, 1, 0));
            this.table.Fields_Table.Add(new MDN_Campo("BANCOUTIL", true, Util.Enumerator.DataType.STRING, "", false, false, 50, 0));
            this.table.Fields_Table.Add(new MDN_Campo("ENTRADA", true, Util.Enumerator.DataType.STRING, "", false, false, 3000, 0));
            this.table.Fields_Table.Add(new MDN_Campo("SAIDA", true, Util.Enumerator.DataType.STRING, "", false, false, 3000, 0));
            this.table.Fields_Table.Add(new MDN_Campo("PASSOS", true, Util.Enumerator.DataType.STRING, "", false, false, 3000, 0));
            this.table.Fields_Table.Add(new MDN_Campo("CODIGOSTAT", true, Util.Enumerator.DataType.CHAR, "0", false, false, 1, 0));
            this.table.Fields_Table.Add(new MDN_Campo("DATA_CRIACAO", true, Util.Enumerator.DataType.INT, null, false, false, 15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("SISTEMA", true, Util.Enumerator.DataType.INT, null, false, false, 15, 0));

            if (!base.table.ExistsTable())
                base.table.CreateTable(false);

            base.table.VerificaColunas();
        }

        /// <summary>
        /// Contrutor secundário da classe
        /// </summary>
        /// <param name="codigo">Código do cenário</param>
        /// <param name="project">Projeto ao qual o cenário faz parte</param>
        public MD_Cenario(int codigo, MD_Project project)
            :this()
        {
            Util.CL_Files.WriteOnTheLog("MD_Cenario.MD_Cenario()", Util.Global.TipoLog.DETALHADO);
            this.codigo = codigo;
            this.Project = project;
            Load();
        }


        #endregion Contrutores

        #region Métodos

        /// <summary>
        /// Método que faz o Load da classe
        /// </summary>
        public override void Load()
        {
            Util.CL_Files.WriteOnTheLog("MD_Cenario.Load()", Util.Global.TipoLog.DETALHADO);
            string sentenca = base.table.CreateCommandSQLTable() + " WHERE CODIGOCEN = " + this.codigo + " AND TAREFA = " + project.NumeroTarefa;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            if (reader == null)
                this.Empty = true;
            else if (reader.Read())
            {
                EhReparo = reader["REPARO"].ToString().Equals("0") ? Reparo.SIM : Reparo.NAO;
                Tarefa = int.Parse(reader["NUTAREFA"].ToString());
                VersaoSgbd = reader["VERSAOSGBD"].ToString();
                TipoBanco = reader["TIPOBANCO"].ToString().Equals(0) ? Banco.ORACLE : Banco.SQLSERVER;
                BancoUtilizado = reader["BANCOUTIL"].ToString();
                Entrada = reader["ENTRADA"].ToString();
                Saida = reader["SAIDA"].ToString();
                Passos = reader["PASSOS"].ToString();
                TipoDoSistema = (TipoSistema)int.Parse((reader["SISTEMA"].ToString()));
                Status = new MD_Status(int.Parse(reader["CODIGOSTAT"].ToString()));
                DataCriacao = Util.DataBase.Int_to_Date(int.Parse(reader["DATA_CRIACAO"].ToString()));

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
        /// Método que faz o delete do objeto da classe
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            Util.CL_Files.WriteOnTheLog("MD_Cenario.Delete()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "DELETE FROM " + this.table.Table_Name + " WHERE CODIGOCEN = " + this.codigo + " AND TAREFA = " + project.NumeroTarefa;
            return Util.DataBase.Delete(sentenca);
        }

        /// <summary>
        /// Método que faz o insert do objeto
        /// </summary>
        /// <returns></returns>
        public override bool Insert()
        {
            Util.CL_Files.WriteOnTheLog("MD_Cenario.Insert()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "INSERT INTO " + this.table.Table_Name + "(CODIGOCEN, TAREFA, REPARO, NUTAREFA, VERSAOSGBD, TIPOBANCO, BANCOUTIL, ENTRADA, SAIDA, PASSOS, CODIGOSTAT, DATA_CRIACAO, SISTEMA) VALUES (" 
                                + Codigo + ", " + Project.NumeroTarefa + ", '" + (EhReparo == Reparo.SIM ? "0" : "1") + "', " + Tarefa + ", '" + VersaoSgbd + "', '" + (TipoBanco == Banco.ORACLE ? "0" : "1") + 
                                "', '" + BancoUtilizado + "', '" + Entrada + "','" + Saida + "','" + Passos +"'," + Status.Codigo + ", " + Util.DataBase.Date_to_Int(DataCriacao) + ", "  + (int)tipoSistema + ")";
            return Util.DataBase.Insert(sentenca);
        }

        /// <summary>
        /// Método que faz o update to objeto
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            Util.CL_Files.WriteOnTheLog("MD_Cenario.Update()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "UPDATE " + this.table.Table_Name + " SET " +
                                " REPARO = '" + (EhReparo == Reparo.SIM ? "0" : "1") + "', " +
                                " NUTAREFA = " + Tarefa + ", " +
                                " VERSAOSGBD = '" + VersaoSgbd + "', " +
                                " TIPOBANCO = '" + (TipoBanco == Banco.ORACLE ? "0" : "1") + "', " +
                                " BANCOUTIL = '" + BancoUtilizado + "', " +
                                " ENTRADA = '" + Entrada + "', " +
                                " SAIDA = '" + Saida + "', " +
                                " PASSOS= '" + Passos + "', " +
                                " CODIGOSTAT = " + Status.Codigo + ", " +
                                " DATA_CRIACAO = " + Util.DataBase.Date_to_Int(dataCriacao) + ", " +
                                " SISTEMA = " + (int)tipoSistema +
                              " WHERE TAREFA = " + this.Codigo;
            return Util.DataBase.Insert(sentenca);
        }

        /// <summary>
        /// Método que copia o arquivo para a pasta de prints
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        public bool CopiaPrint(string caminho, ref string mensagemErro)
        {
            Util.CL_Files.WriteOnTheLog("MD_Cenario.CopiaPrint()", Util.Global.TipoLog.DETALHADO);
            mensagemErro = "";
            try
            {
                FileInfo info = new FileInfo(caminho);
                string diretorio = Util.Global.app_Prints_directory(project) +this.codigo+"\\";
                Directory.CreateDirectory(diretorio);

                File.Copy(caminho, diretorio + info.Name);
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
                Util.CL_Files.WriteOnTheLog("Erro ao anexar arquivo de print do cenário. Erro: " + e.Message, Util.Global.TipoLog.SIMPLES);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método que retorna todos os projetos
        /// </summary>
        /// <returns></returns>
        public SQLiteDataReader RetornaTodosCenarios()
        {
            Util.CL_Files.WriteOnTheLog("MD_Cenario.RetornaTodosCenarios()", Util.Global.TipoLog.DETALHADO);
            string sentenca = base.table.CreateCommandSQLTable() + " WHERE TAREFA = " + project.NumeroTarefa;
            return Util.DataBase.Select(sentenca);
        }

        #endregion Métodos
    }
}
