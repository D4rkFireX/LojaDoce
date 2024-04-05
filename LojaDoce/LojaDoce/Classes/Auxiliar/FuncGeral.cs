/*****************************************************************************
*           Nome: FuncGeral
*      Descrição: Representa a classe que executa as funções gerais de classes
*                 e formulários.
*    Dt. Criação: 04/04/2024
*  Dt. Alteração: --/--/----
* Obs. Alteração: -------------------
*     Criada por: D4rkFire
******************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaDoce
{
    class FuncGeral
    {
        ///<summary>
        ///Vetor de byte utilizado para a criptografia (chave externa) 
        ///</summary>

        private static byte[] bIV = { 0x50, 0x80, 0xF1, 0xDD, 0xDE,
            0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>
        /// Representação de valor em base 64 (chave interna)
        /// Valor representa a transformação para base 64 de 
        /// um conjunto de 32 caracteres (8 * 32 - 256 bits)
        /// a chave é: "Criptografia com Rijndael / AES"
        /// </summary>
        private const string s_cryptokey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyNNRVM=";


        /**********************************************************************
        *            Nome: Criptografa
        *       Descrição: Responsável por criptografar o password do usuário e 
        *                  retornar a criptografia em 32 bits
        *                  
        *       Parametro: string (senha)
        *         Retorno: string (senha criptografada)
        *     Dt. Criação: 08/03/2024
        *   DT. Alteração:
        *  Obs. Alteração: -------------------
        *      Criada por: D4rkFire
        ***********************************************************************/
        public string Criptografa(string s_PW)
        {
            try
            {
                //Se a string não for vazia, executa a criptografia
                if (!string.IsNullOrEmpty(s_PW))
                {
                    //Cria uma instância do vetor de bytes com as chaves
                    byte[] bKey = Convert.FromBase64String(s_cryptokey);
                    byte[] bText = new UTF8Encoding().GetBytes(s_PW);

                    //Instância da classe de criptografia Rijndael
                    Rijndael obj_Rijndael = new RijndaelManaged();

                    //Define o tamanho da chave " 256 = 8 * 32 "
                    //Chaves possíveis: 128 (16 caracteres), 192 (24 caracteres),
                    //                  256 (32 caracteres),
                    obj_Rijndael.KeySize = 256;

                    //Criar um espaço de memória para guardar a string criptografada
                    MemoryStream mStream = new MemoryStream();

                    //Instância para o Encriptografador 
                    CryptoStream cStream = new CryptoStream(
                        mStream,
                        obj_Rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    //Fazer a escrita da criptografia no espaço de memória
                    cStream.Write(bText, 0, bText.Length);

                    //Despejar toda a memória
                    cStream.FlushFinalBlock();

                    //Pegar o vetor de bytes da memória e gerar a string Criptografada

                    return Convert.ToBase64String(mStream.ToArray());

                }
                else
                {
                    // Se a string for vazia, deve ser retornado nulo
                    return null;
                }
            }
            catch (Exception erro)
            {
                //Se algum erro ocorrer, dispara a exceção
                throw new ApplicationException("Erro ao tentar criptografar", erro);
            }
        }

        /**********************************************************************
        *            Nome: Descriptografa
        *       Descrição: Responsável por descriptografar o password do usuário
        *                  e retornar a senha descriptografada
        *                  
        *       Parametro: string (senha criptografada)
        *         Retorno: string (senha)
        *     Dt. Criação: 04/04/2024
        *   DT. Alteração:
        *  Obs. Alteração: -------------------
        *      Criada por: D4rkFire
        ***********************************************************************/
        public string Descriptografa(string s_PW)
        {
            try
            {
                //Se a string não for vazia, executa a criptografia
                if (!string.IsNullOrEmpty(s_PW))
                {
                    //Cria uma instância do vetor de bytes com as chaves
                    byte[] bKey = Convert.FromBase64String(s_cryptokey);
                    byte[] bText = Convert.FromBase64String(s_PW);

                    //Instância da classe de criptografia Rijndael
                    Rijndael obj_Rijndael = new RijndaelManaged();

                    //Define o tamanho da chave " 256 = 8 * 32 "
                    //Chaves possíveis: 128 (16 caracteres), 192 (24 caracteres),
                    //                  256 (32 caracteres),
                    obj_Rijndael.KeySize = 256;

                    //Criar um espaço de memória para guardar a string criptografada
                    MemoryStream mStream = new MemoryStream();

                    //Instância para o Encriptografador 
                    CryptoStream dcStream = new CryptoStream(
                        mStream,
                        obj_Rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    //Fazer a escrita da criptografia no espaço de memória
                    dcStream.Write(bText, 0, bText.Length);

                    //Despejar toda a memória
                    dcStream.FlushFinalBlock();

                    //Instância a classe de codificação para que a string venha de forma correta
                    UTF8Encoding utf8 = new UTF8Encoding();

                    //Com o vetor de bytes da memória, gera a string Descriptografada em UTF8

                    return utf8.GetString(mStream.ToArray());

                }
                else
                {
                    // Se a string for vazia, deve ser retornado nulo
                    return null;
                }
            }
            catch (Exception erro)
            {
                //Se algum erro ocorrer, dispara a exceção
                throw new ApplicationException("Erro ao tentar descriptografar", erro);
            }
        }


        /**********************************************************************
        *            Nome: LimpaTela
        *       Descrição: Responsável por limpar cada componente editavel da
        *                  tela e labels de auxilio a botões de busca
        *       Parametro: Nome do Formulário
        *     Dt. Criação: 04/04/2024
        *   DT. Alteração:
        *  Obs. Alteração: -------------------
        *      Criada por: D4rkFire
        *      Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public void LimpaTela(Form pobj_Form)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctr in pnl.Controls)
                    {
                        if (ctr is TextBox)
                        {
                            ctr.Text = "";
                        }

                        if (ctr is Label && Convert.ToInt16(ctr.Tag) == 1)
                        {
                            ctr.Text = "";
                        }

                        if (ctr is ListView)
                        {
                            ((ListView)ctr).Items.Clear();
                        }

                        if (ctr is ComboBox)
                        {
                            ctr.Text = "";
                        }

                        if (ctr is CheckBox)
                        {
                            ((CheckBox)ctr).Checked = false;
                        }
                    }
                }
            }
        }

        /**********************************************************************
        *            Nome: HabilitaTela
        *       Descrição: Responsável por Halibitar/Desabilitar cada componente
        *                  editavel da tela
        *       Parametro: Nome do Formulário e um Booleano
        *     Dt. Criação: 04/042024
        *   DT. Alteração:
        *  Obs. Alteração: -------------------
        *      Criada por: D4rkFire
        *      Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public void HabilitaTela(Form pobj_Form, bool b_Habilita)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctr in pnl.Controls)
                    {
                        if (ctr is TextBox && Convert.ToInt16(ctr.Tag) != 1)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is CheckBox)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is Button)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is ComboBox)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is ListView)
                        {
                            ctr.Enabled = b_Habilita;
                        }
                    }
                }
            }
        }

        /**********************************************************************
        *            Nome: StatusBtn
        *       Descrição: Responsável por Halibitar/Desabilitar os botões do 
        *                  painel pnl_Button da tela
        *       Parametro: Nome do Formulário e um int
        *     Dt. Criação: 04/04/2024
        *   DT. Alteração: --/--/----
        *  Obs. Alteração: -
        *      Criada por: D4rkFire
        *     Observações: status 1 --> btn_Novo(true) e os outros(false)
        *                  status 2 --> btn_Novo btn_Alterar e btn_Excluir(true)
        *                  e os outros(false)
        *                  status 3 --> btn_Cancelar e btn_Confirmar(true) e os 
        *                  outros(false)
        ***********************************************************************/
        public void StatusBtn(Form pobj_Form, int i_Status)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Button")
                {
                    foreach (Control ctr in pnl.Controls)
                    {
                        switch (i_Status)
                        {
                            case 1:
                                {
                                    if (ctr.Name == "btn_Novo")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Alterar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Excluir")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Cancelar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Confirmar")
                                    {
                                        ctr.Enabled = false;
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    if (ctr.Name == "btn_Novo")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Alterar")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Excluir")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Cancelar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Confirmar")
                                    {
                                        ctr.Enabled = false;
                                    }
                                    break;
                                }

                            case 3:
                                {
                                    if (ctr.Name == "btn_Novo")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Alterar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Excluir")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Cancelar")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Confirmar")
                                    {
                                        ctr.Enabled = true;
                                    }
                                    break;
                                }
                        }

                    }
                }
            }
        }

        /**********************************************************************
        *            Nome: ValidaTipo
        *       Descrição: Responsável por validar o conteúdo editável
        *       Parametro: Tipo e o conteúdo
        *         Retorno: boleano (bool) 
        *     Dt. Criação: 04/04/2024
        *   DT. Alteração:
        *  Obs. Alteração: -------------------
        *      Criada por: D4rkFire
        ***********************************************************************/
        public bool ValidaTipo(Type p_Tipo, string ps_Conteudo)
        {
            bool b_Valida = false;
            switch (p_Tipo.Name)
            {
                case "Int16":
                    {
                        int i_vlr_Inteiro = 0;
                        b_Valida = int.TryParse(ps_Conteudo, out i_vlr_Inteiro);
                        break;
                    }

                case "DateTime":
                    {
                        DateTime dt_vlr_Data = DateTime.MinValue;
                        b_Valida = DateTime.TryParse(ps_Conteudo, out dt_vlr_Data);
                        break;
                    }
                case "double":
                    {
                        double d_vlr_Decimal = 0;
                        b_Valida = double.TryParse(ps_Conteudo, out d_vlr_Decimal);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return b_Valida;
        }

        /**********************************************************************
        *            Nome: ShowAlert
        *       Descrição: Responsável por verificar se o componente de texto 
        *                  está preenchido
        *       Parametro: Controle de tela (Ctrl)
        *     Dt. Criação: 04/04/2024
        *   DT. Alteração:
        *  Obs. Alteração: -------------------
        *      Criada por: D4rkFire
        ***********************************************************************/
        public void ShowAlert(Control p_Ctrl)
        {
            MessageBox.Show("Campo não preenchido ou inválido...", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            p_Ctrl.Focus();
        }
    }
}
