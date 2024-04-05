/*****************************************************************************
*           Nome: Connection
*      Descrição: Representa a classe de conexão com a Base de dados.
*                 A classe de Conexão possui o metodo: PathConnection (Público)
*    Dt. Criação: 05/04/2024
*  Dt. Alteração: --/--/----
* Obs. Alteração: -------------------
*     Criada por: D4rkFire
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoce
{
    public static class Connection
    {
        /**********************************************************************
        *  Nome: PathConnection
        *  Descrição: Responsável por retornar o caminho do banco da aplicação
        *  Retorna: string
        *  Dt. Criação: 05/04/2024
        *  DT. Alteração: --/--/----
        *  Obs. Alteração: -------------------
        *  Criada por: D4rkFire
        ***********************************************************************/
        public static string PathConnection()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\victor.grferreira\source\repos\LojaDoce\LojaDoce\BD_LojaDoce.mdf;Integrated Security=True";
        }
    }
}
