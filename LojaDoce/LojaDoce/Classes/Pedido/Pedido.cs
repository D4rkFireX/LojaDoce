/**********************************************************************************
 Nome da Classe: Pedido
    Dt. Criação: 05/04/2024
      Descrição: Esta classe é responsável pelo objeto Pedido.
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
    internal class Pedido
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~Pedido()
        {
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Pedido = -1;
        private int v_Cod_Itens = -1;
        private int v_Cod_Cliente = -1;
        private int v_VlrTot_Pedido = 0;
        #endregion

        #region Métodos
        //Métodos Públicos
        public int Cod_Pedido
        {
            get => v_Cod_Pedido;
            set => v_Cod_Pedido = value;
        }

        public int Cod_Itens
        {
            get => v_Cod_Itens;
            set => v_Cod_Itens = value;
        }

        public int Cod_Cliente
        {
            get => v_Cod_Cliente;
            set => v_Cod_Cliente = value;
        }

        public int VlrTot_Pedido
        {
            get => v_VlrTot_Pedido;
            set => v_VlrTot_Pedido = value;
        }
        #endregion
    }
}
