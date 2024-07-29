using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFinal
{
    public class EfetuandoCompra
    {
        public List<Iphone> Iphones { get; set; } = new List<Iphone>();
        public string Carrinho { get; set; }
        public decimal Saldo { get; set; }
        public Empresa EmpresaSelecionada { get; set; }


        public void EfetuarCompra()
        {

            Console.Clear();

            Console.WriteLine("\nDeseja finalizar a compra?");
            Console.WriteLine("Digite [1] para finalizar sua compra.");
            Console.WriteLine("Digite [2] para retornar a lista de iphones disponiveis");

            int final = int.Parse(Console.ReadLine()!);
            switch (final)
            {
                case 1:
                    FinalizarCompra();

                    break;

                case 2:
                    EmpresaSelecionada.VisualizarIphones();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Digite novamente.");
                    EfetuarCompra();
                    break;
            }

        }

        private void FinalizarCompra()
        {
            var somaTotal = Iphones.Sum(i => i.Valor);
            if (Saldo >= somaTotal)
            {
                Saldo -= somaTotal;
                Console.WriteLine("Parabéns! Sua compra foi efetuada.");
                Console.WriteLine($"Valor total pago: {somaTotal:C}");
            }
            else
            {
                Console.WriteLine("Infelizmente seu saldo é insuficiente para efetuar a compra.");
            }
            Console.ReadLine();
        }
        

        public void CarrinhoDeCompra(string modelo)
        {
            
            try
            {
                Console.Clear();
                if (Iphones == null || !Iphones.Any())
                {
                    Console.WriteLine("Nenhum iphone disponível, ou cadrastrado para adicionar ao carrinho.");
                    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu cliente.");
                    Console.ReadKey();
                    Console.Clear();
                    var menu = new Menu();
                    menu.MenuCliente();
                    return;
                }

              
                var iphone = Iphones.FirstOrDefault(i => i.Modelo.Equals(modelo, StringComparison.OrdinalIgnoreCase));

                if (iphone == null)
                {
                    Console.WriteLine("iPhone não encontrado.");
                    Console.WriteLine("Digite qualquer tecla para voltar ao menu cliente.");
                    Console.ReadKey();
                    Console.Clear();
                    var menu = new Menu();
                    menu.MenuCliente();
                    return;
                }

                
                Console.WriteLine("\nSeu iPhone foi adicionado ao carrinho.");
                Console.WriteLine($"Modelo: {iphone.Modelo}, Valor: {iphone.Valor}, Ano: {iphone.Ano}");

                Console.WriteLine("Digite qualquer tecla para continuar no carrinho.");
                Console.ReadKey();
                Console.Clear();

                var cliente = new Cliente("", 0, 0);
                cliente.ContinuaNoCarrinho();
                

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Não foi possível visualizar seu carrinho de compras: {ex.Message}");
            }

            Console.ReadLine();
            Console.Clear();
          
        }
    }
}
