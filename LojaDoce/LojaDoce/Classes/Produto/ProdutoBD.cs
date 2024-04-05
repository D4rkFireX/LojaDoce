/*****************************************************************************
*           Nome: ProdutoBD
*      Descrição: Representa a classe que negocia com a Base de dados da 
*                 Entidade Produto. A classe BD possui os metodos: Incluir,
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
    class ProdutoBD
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~ProdutoBD()
        {
        }

        /**********************************************************************
        *  Nome: Incluir
        *  Descrição: Responsável por incluir a TUPLA do Objeto Produto na
        *             Tabela TB_PRODUTO
        *  Parametro: Produto (Objeto da Classe)
        *  Retorna: Código da TUPLA incluída.
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração:
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public int Incluir(Produto pobj_Produto)
        {
            string s_varSql = "";
            int i_Cod = pobj_Produto.Cod_Produto;

            //Conexão

            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_PRODUTO " +
                       " ( " +
                       " I_COD_PRODUTO, " +
                       " I_QTDE_PRODUTO, " +
                       " D_VLRSUB_PRODUTO " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @I_COD_PRODUTO, " +
                       " @I_QTDE_PRODUTO, " +
                       " @D_VLRSUB_PRODUTO " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_PRODUTO') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_QTDE_PRODUTO", pobj_Produto.Qtde_Produto);
            obj_Cmd.Parameters.AddWithValue("@D_VLRSUB_PRODUTO", pobj_Produto.VlrSub_Produto);

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
        *  Descrição: Responsável por Alterar a TUPLA do Objeto Produto na
        *             Tabela TB_PRODUTO
        *  Parametro: Produto (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Alterar(Produto pobj_Produto)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " UPDATE TB_PRODUTO SET " +
                       " I_COD_PRODUTO = @I_COD_PRODUTO, " +
                       " I_QTDE_PRODUTO = @I_QTDE_PRODUTO, " +
                       " D_VLRSUB_PRODUTO = @D_VLRSUB_PRODUTO " +
                       " WHERE I_COD_PRODUTO = @I_COD_PRODUTO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_QTDE_PRODUTO", pobj_Produto.Qtde_Produto);
            obj_Cmd.Parameters.AddWithValue("@D_VLRSUB_PRODUTO", pobj_Produto.VlrSub_Produto);

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
        *  Descrição: Responsável por Excluir a TUPLA do Objeto Produto na
        *             Tabela TB_PRODUTO
        *  Parametro: Produto (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Excluir(Produto pobj_Produto)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " DELETE FROM TB_PRODUTO " +
                       " WHERE I_COD_PRODUTO = @I_COD_PRODUTO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);

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
        *  Descrição: Responsável por Selecionar a TUPLA do Objeto Produto na
        *             Tabela TB_PRODUTO
        *  Parametro: Produto (Objeto da Classe)
        *  Retorna: Produto (Objeto da Classe) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public Produto FindByCod(Produto pobj_Produto)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_PRODUTO " +
                       " WHERE I_COD_PRODUTO = @I_COD_PRODUTO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"].ToString());
                    pobj_Produto.Qtde_Produto = Convert.ToInt16(obj_Dtr["I_QTDE_PRODUTO"].ToString());
                    pobj_Produto.VlrSub_Produto = Convert.ToDecimal(obj_Dtr["D_VLRSUB_PRODUTO"].ToString());
                }
                else
                {
                    pobj_Produto = new Produto();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Produto;
        }


        /**********************************************************************
        *  Nome: FindAll
        *  Descrição: Responsável por Selecionar todas as TUPLAS dos Objetos Produto na
        *             Tabela TB_PRODUTO
        *  Retorna: Uma Lista de objetos Produto (List) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public List<Produto> FindAll()
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_PRODUTO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            List<Produto> Lista = new List<Produto>();

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Produto obj_Produto = new Produto();
                        obj_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"].ToString());
                        obj_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"].ToString());
                        obj_Produto.Qtde_Produto = Convert.ToInt16(obj_Dtr["I_QTDE_PRODUTO"].ToString());
                        obj_Produto.VlrSub_Produto = Convert.ToDecimal(obj_Dtr["D_VLRSUB_PRODUTO"].ToString());

                        Lista.Add(obj_Produto);
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
