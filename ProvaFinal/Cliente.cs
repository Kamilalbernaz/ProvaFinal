using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinal
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public decimal Saldo { get; set; }
        public List<Iphone> IphonesComprados { get; set; }
        

        public Cliente(string nomecliente, int cpf, decimal saldo)
        {
            Nome = nomecliente;
            CPF = cpf;
            Saldo = saldo;
            IphonesComprados = new List<Iphone>();

        }
        public void CadastroCliente()
        {
            var menu = new Menu();
            try
            {
                Console.Clear();
                Console.Write("\nOlá, bem vindo! Vamos iniciar seu cadrastro.\n");
                Console.Write("\nCliente, digite o seu nome:");
                Nome = Console.ReadLine()!.Trim().ToLower();
                Console.Write("\nPor gentileza, digite o seu CPF:");
                CPF = int.Parse(Console.ReadLine()!.ToLower());
                Console.Write("\nAgora digite o seu saldo disponivel para compra:");
                Saldo = decimal.Parse(Console.ReadLine()!.ToLower().Trim());
            }
            catch
            {   
                Console.Clear();
                Console.WriteLine("Opção inválida, digite qualquer tecla para voltar ao menu cliente.");
               
            }
            Console.ReadKey();
            Console.Clear() ;
            menu.MenuCliente();
        }
        public void VisualizarInformacoesCliente()
        { 
            try
            {
                Console.Clear();
                Console.WriteLine($"\nNome: {Nome}");
                Console.WriteLine($"\nCPF: {CPF}");
                Console.WriteLine($"\nSaldo: {Saldo}");
                Console.WriteLine("\niphones Comprados:");
                foreach (var iphone in IphonesComprados)
                {
                    Console.WriteLine($"\nModelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor}");
                }
            }
           catch
            {
                Console.Clear();
                Console.WriteLine("Não foi possivel visulizar as informalões do cliente.");
            }
        }

        public void Excluir()
        {
            var menu = new Menu();
            try
            {
                var iphone = new Iphone();
                Console.Clear();
                Console.Write("\nDigite o Iphone que deseja excluir do seu carrinho:");

                var modelo = Console.ReadLine()!.Trim();
                var iphoneParaRemover = IphonesComprados.FirstOrDefault(i => i.Modelo.Equals(modelo, StringComparison.OrdinalIgnoreCase));

                if (iphoneParaRemover != null)
                {
                    IphonesComprados.Remove(iphoneParaRemover);

                    Console.WriteLine("O Iphone foi deletado com sucesso!");
                }

                else
                {
                    Console.WriteLine("Erro a excluir o Iphone.");
                }
            }
           catch
            {
                Console.Clear();
                Console.WriteLine("Não foi possivel executar a função desejada.");
                Console.WriteLine("\nDigite qualquer tecla para voltar o menu do cliente.");
            }
            Console.ReadKey();
            Console.Clear();
            menu.MenuCliente();
        }
            public void ContinuaNoCarrinho()
            {
             
                Console.Clear();
               
                Console.WriteLine($"Digite [1] se deseja adicionar outro produto?");
                Console.WriteLine("Digite [2] se deseja remover um produto já adicionado no carrinho.");
                Console.WriteLine("Digite [3] se deseja finalizar sua compra.");
                Console.WriteLine("\nDigite [0] para voltar ao menu inicial.");

                Console.Write("\nDigite a opção desejada:");
                int escolha = int.Parse(Console.ReadLine()!);

                var empresa = new Empresa("", 0);
                var efetuandocompra = new EfetuandoCompra();
                var menu = new Menu();


                switch (escolha)
                {
                    case 1:
                        empresa.VisualizarIphones();
                        efetuandocompra.CarrinhoDeCompra("");
                        break;


                    case 2:
                        Excluir();
                        break;

                    case 3:
                        efetuandocompra.EfetuarCompra();
                        break;
                   
                    case 0:
                    menu.MenuInicial();
                    break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;



                }
             Console.ReadLine();

            }
        
    }
}
