/**********************************************************************************
 Nome da Classe: Usuario
    Dt. Criação: 05/04/2024
      Descrição: Esta classe é responsável pelo objeto Usuario.
  Dt. Alteração: --/--/---- 
     Observação:
     Criado Por: D4rkFire
***********************************************************************************/
namespace LojaDoce
{
    public class Usuario
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~Usuario()
        {
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Usuario = -1;
        private string v_Nm_Usuario = "";
        private string v_UNm_Usuario = "";
        private string v_PW_Usuario = "";
        #endregion

        #region Métodos
        //Métodos Públicos
        public int    Cod_Usuario 
        { 
            get => v_Cod_Usuario; 
            set => v_Cod_Usuario = value; 
        }

        public string Nm_Usuario 
        { 
            get => v_Nm_Usuario; 
            set => v_Nm_Usuario = value; 
        }

        public string UNm_Usuario 
        { 
            get => v_UNm_Usuario; 
            set => v_UNm_Usuario = value; 
        }

        public string PW_Usuario 
        { 
            get => v_PW_Usuario; 
            set => v_PW_Usuario = value; 
        }
        #endregion
    }
}
