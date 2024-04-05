/**********************************************************************************
 Nome da Classe: Cliente
    Dt. Criação: 05/04/2024
      Descrição: Esta classe é responsável pelo objeto Cliente.
  Dt. Alteração: --/--/---- 
     Observação:
     Criado Por: D4rkFire
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoce
{
    internal class Cliente
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~Cliente() 
        { 
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Cliente = -1;
        private string v_Nm_Cliente = "";
        private string v_Tel_Cliente = "";
        private string v_Email_Cliente = "";
        private string v_Cpf_Cliente = "";
        #endregion

        #region Métodos
        //Métodos Públicos
        public int Cod_Cliente
        {
            get => v_Cod_Cliente;
            set => v_Cod_Cliente = value;
        }

        public string Nm_Cliente
        {
            get => v_Nm_Cliente;
            set => v_Nm_Cliente = value;
        }

        public string Tel_Cliente
        {
            get => v_Tel_Cliente;
            set => v_Tel_Cliente = value;
        }

        public string Email_Cliente
        {
            get => v_Email_Cliente;
            set => v_Email_Cliente = value;
        }

        public string Cpf_Cliente
        {
            get => v_Cpf_Cliente;
            set => v_Cpf_Cliente = value;
        }
        #endregion
    }
}
