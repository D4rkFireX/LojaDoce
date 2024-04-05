/*****************************************************************************
*           Nome: ItensBD
*      Descrição: Representa a classe que negocia com a Base de dados da 
*                 Entidade Itens. A classe BD possui os metodos: Incluir,
*                 Alterar, Excluir, FindByCod, FindByNm e FindAll (Publicas)
*    Dt. Criação: 05/04/2024
*  Dt. Alteração: --/--/----
* Obs. Alteração: -------------------
*     Criada por: D4rkFire
******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaDoce
{
    class ItensBD
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~ItensBD()
        {
        }

        /**********************************************************************
        *  Nome: Incluir
        *  Descrição: Responsável por incluir a TUPLA do Objeto Itens na
        *             Tabela TB_ITENS
        *  Parametro: Itens (Objeto da Classe)
        *  Retorna: Código da TUPLA incluída.
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração:
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public int Incluir(Itens pobj_Itens)
        {
            string s_varSql = "";
            int i_Cod = pobj_Itens.Cod_Itens;

            //Conexão

            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_ITENS " +
                       " ( " +
                       " I_COD_PRODUTO, " +
                       " I_QTDE_ITENS, " +
                       " D_VLRSUB_ITENS " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @I_COD_PRODUTO, " +
                       " @I_QTDE_ITENS, " +
                       " @D_VLRSUB_ITENS " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_ITENS') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Itens.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_QTDE_ITENS", pobj_Itens.Qtde_Itens);
            obj_Cmd.Parameters.AddWithValue("@D_VLRSUB_ITENS", pobj_Itens.VlrSub_Itens);

            try
            {
                obj_Conn.Open();
                i_Cod = Convert.ToInt16(obj_Cmd.ExecuteScalar());
                obj_Conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return i_Cod;
        }

        /**********************************************************************
        *  Nome: Alterar
        *  Descrição: Responsável por Alterar a TUPLA do Objeto Itens na
        *             Tabela TB_ITENS
        *  Parametro: Itens (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Alterar(Itens pobj_Itens)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " UPDATE TB_ITENS SET " +
                       " I_COD_PRODUTO = @I_COD_PRODUTO, " +
                       " I_QTDE_ITENS = @I_QTDE_ITENS, " +
                       " D_VLRSUB_ITENS = @D_VLRSUB_ITENS " +
                       " WHERE I_COD_ITENS = @I_COD_ITENS ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            obj_Cmd.Parameters.AddWithValue("@I_COD_ITENS", pobj_Itens.Cod_Itens);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Itens.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_QTDE_ITENS", pobj_Itens.Qtde_Itens);
            obj_Cmd.Parameters.AddWithValue("@D_VLRSUB_ITENS", pobj_Itens.VlrSub_Itens);

            try
            {
                obj_Conn.Open();
                //Executa um comando que não traz uma relação de linhas e colunas
                obj_Cmd.ExecuteNonQuery();
                obj_Conn.Close();
                b_valida = true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return b_valida;
        }


        /**********************************************************************
        *  Nome: Excluir
        *  Descrição: Responsável por Excluir a TUPLA do Objeto Itens na
        *             Tabela TB_ITENS
        *  Parametro: Itens (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Excluir(Itens pobj_Itens)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " DELETE FROM TB_ITENS " +
                       " WHERE I_COD_ITENS = @I_COD_ITENS ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ITENS", pobj_Itens.Cod_Itens);

            try
            {
                obj_Conn.Open();
                //Executa um comando que não traz uma relação de linhas e colunas
                obj_Cmd.ExecuteNonQuery();
                obj_Conn.Close();
                b_valida = true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return b_valida;
        }




        /**********************************************************************
        *  Nome: FindByCod
        *  Descrição: Responsável por Selecionar a TUPLA do Objeto Itens na
        *             Tabela TB_ITENS
        *  Parametro: Itens (Objeto da Classe)
        *  Retorna: Itens (Objeto da Classe) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public Itens FindByCod(Itens pobj_Itens)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_ITENS " +
                       " WHERE I_COD_ITENS = @I_COD_ITENS ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ITENS", pobj_Itens.Cod_Itens);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Itens.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"].ToString());
                    pobj_Itens.Qtde_Itens = Convert.ToInt16(obj_Dtr["I_QTDE_ITENS"].ToString());
                    pobj_Itens.VlrSub_Itens = Convert.ToDecimal(obj_Dtr["D_VLRSUB_ITENS"].ToString());
                }
                else
                {
                    pobj_Itens = new Itens();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Itens;
        }

        
        /**********************************************************************
        *  Nome: FindAll
        *  Descrição: Responsável por Selecionar todas as TUPLAS dos Objetos Itens na
        *             Tabela TB_ITENS
        *  Retorna: Uma Lista de objetos Itens (List) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public List<Itens> FindAll()
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_ITENS ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            List<Itens> Lista = new List<Itens>();

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Itens obj_Itens = new Itens();
                        obj_Itens.Cod_Itens = Convert.ToInt16(obj_Dtr["I_COD_ITENS"].ToString());
                        obj_Itens.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"].ToString());
                        obj_Itens.Qtde_Itens = Convert.ToInt16(obj_Dtr["I_QTDE_ITENS"].ToString());
                        obj_Itens.VlrSub_Itens = Convert.ToDecimal(obj_Dtr["D_VLRSUB_ITENS"].ToString());

                        Lista.Add(obj_Itens);
                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Lista;
        }
    }
}
