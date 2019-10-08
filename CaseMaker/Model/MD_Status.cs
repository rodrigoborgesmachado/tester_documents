using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CaseMaker.Util.Enumerator;

namespace CaseMaker.Model
{
    public class MD_Status : MDN_Model
    {
        /// <summary>
        /// [MAKSTATUS] Classe referente à tabela MAKSTATUS
        /// </summary>
        #region Atributos e Propriedades

        int codigo = 0;
        /// <summary>
        /// [CODIGOSTAT] Código do status
        /// </summary>
        public int Codigo
        {
            get
            {
                return codigo;
            }
        }

        string nome = "-";
        /// <summary>
        /// [NOMESTAT] Nome do status
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

        StatusErro status = StatusErro.SUCESSO;
        /// <summary>
        /// [ERRO] Identifica se é erro o novo status ou não
        /// </summary>
        public StatusErro Status_erro
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        #endregion Atributos e Propriedades

        #region Contrutores

        /// <summary>
        /// Construtor principal da classe
        /// </summary>
        MD_Status() :
            base()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.MD_Status()", Util.Global.TipoLog.DETALHADO);
            base.table = new MDN_Table("MAKSTATUS");
            this.table.Fields_Table.Add(new MDN_Campo("CODIGOSTAT", true, Util.Enumerator.DataType.INT,    null, true,  true,  15, 0));
            this.table.Fields_Table.Add(new MDN_Campo("NOMESTAT",   true, Util.Enumerator.DataType.STRING, "",   false, false, 50, 0));
            this.table.Fields_Table.Add(new MDN_Campo("ERRO",       true, Util.Enumerator.DataType.CHAR,   "0",  false, false, 1,  0));

            if (!base.table.ExistsTable())
                base.table.CreateTable(false);

            base.table.VerificaColunas();
            InserirPrincipais();
        }

        /// <summary>
        /// Construtor secudário da classe
        /// </summary>
        /// <param name="codigo"></param>
        public MD_Status(int codigo) :
            this()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.MD_Status()", Util.Global.TipoLog.DETALHADO);
            this.codigo = codigo;
            Load();
        }

        #endregion Contrutores

        #region Métodos

        /// <summary>
        /// Método que faz o Load da classe
        /// </summary>
        public override void Load()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.Load()", Util.Global.TipoLog.DETALHADO);
            string sentenca = base.table.CreateCommandSQLTable() + " WHERE CODIGOSTAT = " + Codigo;
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            if (reader == null)
                this.Empty = true;
            else if (reader.Read())
            {
                nome = reader["NOMESTAT"].ToString();
                status = reader["ERRO"].ToString().Equals("0") ? StatusErro.SUCESSO : StatusErro.ERRO;
                
                this.Empty = false;
                reader.Close();
            }
            else
                this.Empty = true;
        }

        /// <summary>
        /// Método que faz o delete do objeto
        /// </summary>
        /// <returns></returns>
        public override bool Delete()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.Delete()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "DELETE FROM " + this.table.Table_Name + " WHERE CODIGOSTAT = " + this.codigo;
            return Util.DataBase.Delete(sentenca);
        }

        /// <summary>
        /// Método que faz o insert do objeto
        /// </summary>
        /// <returns></returns>
        public override bool Insert()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.Insert()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "INSERT INTO " + this.table.Table_Name + " (CODIGOSTAT, NOMESTAT, ERRO) VALUES (" + Codigo + ", '" + Nome + "', '" + (Status_erro == StatusErro.SUCESSO ? "0" : "1") + "')";
            return Util.DataBase.Insert(sentenca);
        }

        /// <summary>
        /// Método que faz o update do objeto
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.Update()", Util.Global.TipoLog.DETALHADO);
            string sentenca = " UPDATE " + this.table.Table_Name + " SET " +
                              "   NOMESTAT = '" + Nome + "', " + 
                              "   ERRO = '" + (Status_erro == StatusErro.SUCESSO ? "0" : "1") + "'" +
                              " WHERE CODIGOSTAT = " + Codigo;
            return Util.DataBase.Update(sentenca);
        }

        /// <summary>
        /// Método que insere os status principais se eles não estiverem inseridos no banco
        /// </summary>
        public static void InserirPrincipais()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.InserirPrincipais()", Util.Global.TipoLog.DETALHADO);
            string sentenca = "SELECT 1 FROM MAKSTATUS WHERE CODIGOSTAT = 0";
            SQLiteDataReader reader = Util.DataBase.Select(sentenca);
            if (reader == null)
            {
                sentenca = "INSERT INTO MAKSTATUS (CODIGOSTAT, NOMESTAT, ERRO) VALUES (0, 'Sucesso', '0')";
                Util.DataBase.Insert(sentenca);
            }
            else if (!reader.HasRows)
            {
                sentenca = "INSERT INTO MAKSTATUS (CODIGOSTAT, NOMESTAT, ERRO) VALUES (0, 'Sucesso', '0')";
                Util.DataBase.Insert(sentenca);
            }
            else
                reader.Close();

            sentenca = "SELECT 1 FROM MAKSTATUS WHERE CODIGOSTAT = 1";
            reader = Util.DataBase.Select(sentenca);
            if (reader == null)
            {
                sentenca = "INSERT INTO MAKSTATUS (CODIGOSTAT, NOMESTAT, ERRO) VALUES (1, 'Erro', '1')";
                Util.DataBase.Insert(sentenca);
            }
            else if (!reader.HasRows)
            {
                sentenca = "INSERT INTO MAKSTATUS (CODIGOSTAT, NOMESTAT, ERRO) VALUES (1, 'Erro', '1')";
                Util.DataBase.Insert(sentenca);
            }
            else
                reader.Close();
        }

        /// <summary>
        /// Método que retorna todos status
        /// </summary>
        /// <returns>Comando</returns>
        public static string ComandoTodosStatus()
        {
            Util.CL_Files.WriteOnTheLog("MD_Status.ComandoTodosStatus()", Util.Global.TipoLog.DETALHADO);
            return "SELECT CODIGOSTAT, NOMESTAT, ERRO FROM MAKSTATUS";
        }

        #endregion Métodos
    }
}
