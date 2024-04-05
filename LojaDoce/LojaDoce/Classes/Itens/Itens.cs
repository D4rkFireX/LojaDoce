/**********************************************************************************
 Nome da Classe: Itens
    Dt. Criação: 05/04/2024
      Descrição: Esta classe é responsável pelo objeto Itens.
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
    internal class Itens
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~Itens()
        {
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Itens = -1;
        private int v_Cod_Produto = -1;
        private int v_Qtde_Itens = 0;
        private decimal v_VlrSub_Itens = 0;
        #endregion

        #region Métodos
        //Métodos Públicos
        public int Cod_Itens
        {
            get => v_Cod_Itens;
            set => v_Cod_Itens = value;
        }

        public int Cod_Produto
        {
            get => v_Cod_Produto;
            set => v_Cod_Produto = value;
        }

        public int Qtde_Itens
        {
            get => v_Qtde_Itens;
            set => v_Qtde_Itens = value;
        }

        public decimal VlrSub_Itens
        {
            get => v_VlrSub_Itens;
            set => v_VlrSub_Itens = value;
        }
        #endregion
    }
}
