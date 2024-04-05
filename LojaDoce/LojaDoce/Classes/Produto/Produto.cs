/**********************************************************************************
 Nome da Classe: Produto
    Dt. Criação: 05/04/2024
      Descrição: Esta classe é responsável pelo objeto Produto.
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
    internal class Produto
    {
        //Método Destroy
        // servem para liberar a memória alocada dinamicamente pela classe,
        // para eliminar as referências a ela, quando não existir.
        ~Produto()
        {
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Produto = -1;
        private int v_Cod_Fornecedor = -1;
        private int v_Cod_Fabricante = -1;
        private string v_Nm_Produto = "";
        private int v_Vlr_Produto = 0;
        private int v_VlrUnit_Produto = 0;
        #endregion

        #region Métodos
        //Métodos Públicos
        public int Cod_Produto
        {
            get => v_Cod_Produto;
            set => v_Cod_Produto = value;
        }

        public int Cod_Fornecedor
        {
            get => v_Cod_Fornecedor;
            set => v_Cod_Fornecedor = value;
        }

        public int Cod_Fabricante
        {
            get => v_Cod_Fabricante;
            set => v_Cod_Fabricante = value;
        }

        public string Nm_Produto
        {
            get => v_Nm_Produto;
            set => v_Nm_Produto = value;
        }

        public int VlrSub_Produto
        {
            get => v_Vlr_Produto;
            set => v_Vlr_Produto = value;
        }

        public int VlrUnit_Produto
        {
            get => v_VlrUnit_Produto;
            set => v_VlrUnit_Produto = value;
        }
        #endregion
    }
}
