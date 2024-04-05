/*****************************************************************************
*           Nome: ClienteBD
*      Descrição: Representa a classe que negocia com a Base de dados da 
*                 Entidade Cliente. A classe BD possui os metodos: Incluir,
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
    class ClienteBD
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~ClienteBD()
        {
        }

        /**********************************************************************
        *  Nome: Incluir
        *  Descrição: Responsável por incluir a TUPLA do Objeto Cliente na
        *             Tabela TB_CLIENTE
        *  Parametro: Cliente (Objeto da Classe)
        *  Retorna: Código da TUPLA incluída.
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração:
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public int Incluir(Cliente pobj_Cliente)
        {
            string s_varSql = "";
            int i_Cod = pobj_Cliente.Cod_Cliente;

            //Conexão

            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_CLIENTE " +
                       " ( " +
                       " S_NM_CLIENTE, " +
                       " S_TEL_CLIENTE, " +
                       " S_EMAIL_CLIENTE, " +
                       " S_CPF_CLIENTE " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @S_NM_CLIENTE, " +
                       " @S_TEL_CLIENTE, " +
                       " @S_EMAIL_CLIENTE, " +
                       " @S_CPF_CLIENTE " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_CLIENTE') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_TEL_CLIENTE", pobj_Cliente.Tel_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_EMAIL_CLIENTE", pobj_Cliente.Email_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_CPF_CLIENTE", pobj_Cliente.Cpf_Cliente);

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
        *  Descrição: Responsável por Alterar a TUPLA do Objeto Cliente na
        *             Tabela TB_CLIENTE
        *  Parametro: Cliente (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Alterar(Cliente pobj_Cliente)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " UPDATE TB_CLIENTE SET " +
                       " S_NM_CLIENTE = @S_NM_CLIENTE, " +
                       " S_TEL_CLIENTE = @S_TEL_CLIENTE, " +
                       " S_EMAIL_CLIENTE = @S_EMAIL_CLIENTE, " +
                       " S_CPF_CLIENTE = @S_CPF_CLIENTE " +
                       " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_TEL_CLIENTE", pobj_Cliente.Tel_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_EMAIL_CLIENTE", pobj_Cliente.Email_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_CPF_CLIENTE", pobj_Cliente.Cpf_Cliente);

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
        *  Descrição: Responsável por Excluir a TUPLA do Objeto Cliente na
        *             Tabela TB_CLIENTE
        *  Parametro: Cliente (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Excluir(Cliente pobj_Cliente)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " DELETE FROM TB_CLIENTE " +
                       " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);

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
        *  Descrição: Responsável por Selecionar a TUPLA do Objeto Cliente na
        *             Tabela TB_CLIENTE
        *  Parametro: Cliente (Objeto da Classe)
        *  Retorna: Cliente (Objeto da Classe) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public Cliente FindByCod(Cliente pobj_Cliente)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_CLIENTE " +
                       " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Cliente.Nm_Cliente = obj_Dtr["S_NM_CLIENTE"].ToString();
                    pobj_Cliente.Tel_Cliente = obj_Dtr["S_TEL_CLIENTE"].ToString();
                    pobj_Cliente.Email_Cliente = obj_Dtr["S_EMAIL_CLIENTE"].ToString();
                    pobj_Cliente.Cpf_Cliente = obj_Dtr["S_CPF_CLIENTE"].ToString();
                }
                else
                {
                    pobj_Cliente = new Cliente();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Cliente;
        }

        /**********************************************************************
        *  Nome: FindByNm
        *  Descrição: Responsável por Selecionar a TUPLA do Objeto Cliente na
        *             Tabela TB_CLIENTE
        *  Parametro: Cliente (Objeto da Classe)
        *  Retorna: Cliente (Objeto da Classe) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public Cliente FindByNm(Cliente pobj_Cliente)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_CLIENTE " +
                       " WHERE S_NM_CLIENTE = @S_NM_CLIENTE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Cliente.Cod_Cliente = Convert.ToInt16(obj_Dtr["I_COD_CLIENTE"].ToString());
                    pobj_Cliente.Nm_Cliente = obj_Dtr["S_NM_CLIENTE"].ToString();
                    pobj_Cliente.Tel_Cliente = obj_Dtr["S_TEL_CLIENTE"].ToString();
                    pobj_Cliente.Email_Cliente = obj_Dtr["S_EMAIL_CLIENTE"].ToString();
                    pobj_Cliente.Cpf_Cliente = obj_Dtr["S_CPF_CLIENTE"].ToString();
                }
                else
                {
                    pobj_Cliente = new Cliente();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Cliente;
        }

        /**********************************************************************
        *  Nome: FindAll
        *  Descrição: Responsável por Selecionar todas as TUPLAS dos Objetos Cliente na
        *             Tabela TB_CLIENTE
        *  Retorna: Uma Lista de objetos Cliente (List) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public List<Cliente> FindAll()
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_CLIENTE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            List<Cliente> Lista = new List<Cliente>();

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Cliente obj_Cliente = new Cliente();
                        obj_Cliente.Cod_Cliente = Convert.ToInt16(obj_Dtr["I_COD_CLIENTE"].ToString());
                        obj_Cliente.Nm_Cliente = obj_Dtr["S_NM_CLIENTE"].ToString();
                        obj_Cliente.Tel_Cliente = obj_Dtr["S_TEL_CLIENTE"].ToString();
                        obj_Cliente.Email_Cliente = obj_Dtr["S_EMAIL_CLIENTE"].ToString();
                        obj_Cliente.Cpf_Cliente = obj_Dtr["S_CPF_CLIENTE"].ToString();

                        Lista.Add(obj_Cliente);
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
