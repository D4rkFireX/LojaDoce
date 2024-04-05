/*****************************************************************************
*           Nome: PedidoBD
*      Descrição: Representa a classe que negocia com a Base de dados da 
*                 Entidade Pedido. A classe BD possui os metodos: Incluir,
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
    class PedidoBD
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~PedidoBD()
        {
        }

        /**********************************************************************
        *  Nome: Incluir
        *  Descrição: Responsável por incluir a TUPLA do Objeto Pedido na
        *             Tabela TB_PEDIDO
        *  Parametro: Pedido (Objeto da Classe)
        *  Retorna: Código da TUPLA incluída.
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração:
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public int Incluir(Pedido pobj_Pedido)
        {
            string s_varSql = "";
            int i_Cod = pobj_Pedido.Cod_Pedido;

            //Conexão

            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_PEDIDO " +
                       " ( " +
                       " I_COD_ITENS, " +
                       " I_COD_CLIENTE, " +
                       " I_VLRTOT_PEDIDO " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @I_COD_ITENS, " +
                       " @I_COD_CLIENTE, " +
                       " @I_VLRTOT_PEDIDO " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_PEDIDO') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ITENS", pobj_Pedido.Cod_Itens);
            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            obj_Cmd.Parameters.AddWithValue("@I_VLRTOT_PEDIDO", pobj_Pedido.VlrTot_Pedido);

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
        *  Descrição: Responsável por Alterar a TUPLA do Objeto Pedido na
        *             Tabela TB_PEDIDO
        *  Parametro: Pedido (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Alterar(Pedido pobj_Pedido)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " UPDATE TB_PEDIDO SET " +
                       " I_COD_ITENS = @I_COD_ITENS, " +
                       " I_COD_CLIENTE = @I_COD_CLIENTE, " +
                       " I_VLRTOT_PEDIDO = @I_VLRTOT_PEDIDO " +
                       " WHERE I_COD_PEDIDO = @I_COD_PEDIDO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            obj_Cmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ITENS", pobj_Pedido.Cod_Itens);
            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            obj_Cmd.Parameters.AddWithValue("@I_VLRTOT_PEDIDO", pobj_Pedido.VlrTot_Pedido);

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
        *  Descrição: Responsável por Excluir a TUPLA do Objeto Pedido na
        *             Tabela TB_PEDIDO
        *  Parametro: Pedido (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Excluir(Pedido pobj_Pedido)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " DELETE FROM TB_PEDIDO " +
                       " WHERE I_COD_PEDIDO = @I_COD_PEDIDO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);

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
        *  Descrição: Responsável por Selecionar a TUPLA do Objeto Pedido na
        *             Tabela TB_PEDIDO
        *  Parametro: Pedido (Objeto da Classe)
        *  Retorna: Pedido (Objeto da Classe) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public Pedido FindByCod(Pedido pobj_Pedido)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_PEDIDO " +
                       " WHERE I_COD_PEDIDO = @I_COD_PEDIDO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Pedido.Cod_Itens = Convert.ToInt16(obj_Dtr["I_COD_ITENS"].ToString());
                    pobj_Pedido.Cod_Cliente = Convert.ToInt16(obj_Dtr["I_COD_CLIENTE"].ToString());
                    pobj_Pedido.VlrTot_Pedido = Convert.ToInt16(obj_Dtr["I_VLRTOT_PEDIDO"].ToString());
                }
                else
                {
                    pobj_Pedido = new Pedido();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Pedido;
        }


        /**********************************************************************
        *  Nome: FindAll
        *  Descrição: Responsável por Selecionar todas as TUPLAS dos Objetos Pedido na
        *             Tabela TB_PEDIDO
        *  Retorna: Uma Lista de objetos Pedido (List) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public List<Pedido> FindAll()
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_PEDIDO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            List<Pedido> Lista = new List<Pedido>();

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Pedido obj_Pedido = new Pedido();
                        obj_Pedido.Cod_Pedido = Convert.ToInt16(obj_Dtr["I_COD_PEDIDO"].ToString());
                        obj_Pedido.Cod_Itens = Convert.ToInt16(obj_Dtr["I_COD_ITENS"].ToString());
                        obj_Pedido.Cod_Cliente = Convert.ToInt16(obj_Dtr["I_COD_CLIENTE"].ToString());
                        obj_Pedido.VlrTot_Pedido = Convert.ToInt16(obj_Dtr["I_VLRTOT_PEDIDO"].ToString());

                        Lista.Add(obj_Pedido);
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
