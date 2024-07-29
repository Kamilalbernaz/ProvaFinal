using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinal
{
    public class Menu
    {
       
        public void MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("\nOlá, bem vindo!\n");
            Console.WriteLine("Digite [1] para acessar como empresa.");
            Console.WriteLine("Digite [2] para acessar como cliente.");

            Console.Write("\nDigite a opção desejada:");

            int menuinicial = int.Parse(Console.ReadLine()!);


            switch (menuinicial)

            {
                case 1:
                    MenuEmpresa();
                    break;


                case 2:
                    MenuCliente();
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            Console.ReadLine();
        }

        public void MenuCliente() 
        {
            Console.Clear();
            Console.WriteLine("\nOlá, bem vindo ao menu do Cliente!");
            Console.WriteLine("Digite [1] para iniciar seu cadastro");
            Console.WriteLine("Digite [2] para acessar os Iphones disponiveis para compra.");
            Console.WriteLine("Digite [3] para acessar o seu carrinho");
            Console.WriteLine("Digite [4] para finalizar a compra.");
            Console.WriteLine("\nDigite [0] para voltar ao Menu Principal.");
            Console.Write("\nDigite a opção desejada:");

            var efetuandocompra = new EfetuandoCompra();
            var cliente = new Cliente("", 0, 00);
            var empresa = new Empresa("",0);
            int menucliente = int.Parse(Console.ReadLine()!); 
            switch (menucliente)
            {
                case 1:
                    cliente.CadastroCliente();
                    break;

                case 2:
                    empresa.VisualizarIphones();
                    
                    break;

                case 3:
                    efetuandocompra.CarrinhoDeCompra("");
                    cliente.ContinuaNoCarrinho();

                    break;


                case 4:
                    efetuandocompra.EfetuarCompra();
                    break;

                case 0:
                    MenuInicial();
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            } 
           
            
        }
             public void MenuEmpresa()
             {
                Console.Clear();
                Console.WriteLine("\nOlá, bem vindo ao Cadastro da empresa!");

                Console.WriteLine("\nDigite [1] para cadrastrar os dados da empresa.");

                Console.WriteLine("\nDigite [0] para voltar ao Menu Principal.");

               var empresa = new Empresa("",0);
               int menuempresa = int.Parse(Console.ReadLine()!.Trim());
           
                switch (menuempresa)
                {
                    case 1:
                    empresa.CadastroEmpresa();
                   
                    break;


                    case 0:
                        MenuInicial();
                        break;

                    default:
                    Console.WriteLine("Opção inválida, por favor digite novamente." );
                    MenuInicial();
                        break;

                }
            
               
             }                    
        

    }
}
