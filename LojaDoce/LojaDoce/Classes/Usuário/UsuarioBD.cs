/*****************************************************************************
*           Nome: UsuarioBD
*      Descrição: Representa a classe que negocia com a Base de dados da 
*                 Entidade Usuario. A classe BD possui os metodos: Incluir,
*                 Alterar, Excluir, FindByCod e FindAll (Publicas)
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
    class UsuarioBD
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~UsuarioBD()
        {
        }

        /**********************************************************************
        *  Nome: Incluir
        *  Descrição: Responsável por incluir a TUPLA do Objeto Usuario na
        *             Tabela TB_USUARIO
        *  Parametro: Usuario (Objeto da Classe)
        *  Retorna: Código da TUPLA incluída.
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração:
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public int Incluir(Usuario pobj_Usuario)
        {
            string s_varSql = "";
            int i_Cod = pobj_Usuario.Cod_Usuario;

            //Conexão

            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_USUARIO " +
                       " ( " +
                       " S_NM_USUARIO, " +
                       " S_UNM_USUARIO, " +
                       " S_PW_USUARIO " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @S_NM_USUARIO, " +
                       " @S_UNM_USUARIO, " +
                       " @S_PW_USUARIO " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_USUARIO') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@S_NM_USUARIO", pobj_Usuario.Nm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.UNm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_PW_USUARIO", pobj_Usuario.PW_Usuario);

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
        *  Descrição: Responsável por Alterar a TUPLA do Objeto Usuario na
        *             Tabela TB_USUARIO
        *  Parametro: Usuario (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Alterar(Usuario pobj_Usuario)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " UPDATE TB_USUARIO SET " +
                       " S_NM_USUARIO = @S_NM_USUARIO, " +
                       " S_UNM_USUARIO = @S_UNM_USUARIO, " +
                       " S_PW_USUARIO = @S_PW_USUARIO " +
                       " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_NM_USUARIO", pobj_Usuario.Nm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.UNm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_PW_USUARIO", pobj_Usuario.PW_Usuario);

            try
            {
                obj_Conn.Open();
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
        *  Descrição: Responsável por Excluir a TUPLA do Objeto Usuario na
        *             Tabela TB_USUARIO
        *  Parametro: Usuario (Objeto da Classe)
        *  Retorna: Boleano (bool)
        *  Dt. Criação:
        *  DT. Alteração: 05/04/2024
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public bool Excluir(Usuario pobj_Usuario)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " DELETE FROM TB_USUARIO " +
                       " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);

            try
            {
                obj_Conn.Open();
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
        *  Descrição: Responsável por Selecionar a TUPLA do Objeto Usuario na
        *             Tabela TB_USUARIO
        *  Parametro: Usuario (Objeto da Classe)
        *  Retorna: Usuario (Objeto da Classe) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public Usuario FindByCod(Usuario pobj_Usuario)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_USUARIO " +
                       " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Usuario.Nm_Usuario = obj_Dtr["S_NM_USUARIO"].ToString();
                    pobj_Usuario.UNm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                    pobj_Usuario.PW_Usuario = obj_Dtr["S_PW_USUARIO"].ToString();
                }
                else
                {
                    pobj_Usuario = new Usuario();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Usuario;
        }

        /**********************************************************************
        *  Nome: FindByUNm
        *  Descrição: Responsável por Selecionar a TUPLA do Objeto Usuario na
        *             Tabela TB_USUARIO
        *  Parametro: Usuario (Objeto da Classe)
        *  Retorna: Usuario (Objeto da Classe) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public Usuario FindByUNm(Usuario pobj_Usuario)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_USUARIO " +
                       " WHERE S_UNM_USUARIO = @S_UNM_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.UNm_Usuario);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Usuario.Cod_Usuario = Convert.ToInt16(obj_Dtr["I_COD_USUARIO"].ToString());
                    pobj_Usuario.Nm_Usuario = obj_Dtr["S_NM_USUARIO"].ToString();
                    pobj_Usuario.UNm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                    pobj_Usuario.PW_Usuario = obj_Dtr["S_PW_USUARIO"].ToString();
                }
                else
                {
                    pobj_Usuario = new Usuario();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Usuario;
        }

        /**********************************************************************
        *  Nome: FindAll
        *  Descrição: Responsável por Selecionar todas as TUPLAS dos Objetos Usuario na
        *             Tabela TB_USUARIO
        *  Retorna: Uma Lista de objetos Usuario (List) 
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public List<Usuario> FindAll()
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            List<Usuario> Lista = new List<Usuario>();

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {

                    while (obj_Dtr.Read())
                    {
                        Usuario obj_Usuario = new Usuario();
                        obj_Usuario.Cod_Usuario = Convert.ToInt16(obj_Dtr["I_COD_USUARIO"].ToString());
                        obj_Usuario.Nm_Usuario = obj_Dtr["S_NM_USUARIO"].ToString();
                        obj_Usuario.UNm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                        obj_Usuario.PW_Usuario = obj_Dtr["S_PW_USUARIO"].ToString();

                        Lista.Add(obj_Usuario);
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
