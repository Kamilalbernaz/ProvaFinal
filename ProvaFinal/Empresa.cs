using System;

namespace ProvaFinal
{
    public class Empresa
    {


        public string Loja { get; set; }
        public int CNPJ { get; set; }
        public List<Iphone> Iphones { get; set; } = new List<Iphone>();




        public Empresa(string nomeloja, int cnpj)
        {
            Loja = "nomeloja";
            CNPJ = cnpj;
        }

        public void CadastroEmpresa()
        {

            var menu = new Menu();
            try
            {
                Console.Clear();
                Console.WriteLine("Olá, bem vindo! Vamos iniciar seu cadrastro.");
                Console.Write("\nDigite o nome da empresa:");
                Loja = Console.ReadLine()!.ToLower().Trim();
                Console.Write("\nDigite o CNPJ da empresa (somente números):");
                CNPJ = int.Parse(Console.ReadLine()!.Trim());
                Console.Write("\nDigite a quantidade de Iphones que deseja cadastrar:");
                int quantidadeModelos = int.Parse(Console.ReadLine()!.Trim());

                CadastroIphone(quantidadeModelos);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro, digite qualquer tecla para voltar ao menu empresa.");
            }

            Console.ReadKey();
            Console.Clear();
            menu.MenuEmpresa();

        }

        public void CadastroIphone(int quantidadeModelos)
        {

            var menu = new Menu();
            try
            {
                for (int i = 0; i < quantidadeModelos; i++)
                {
                    var iphone = new Iphone();
                    Console.Clear();
                    Console.WriteLine("\nDigite o modelo de Iphone que deseja cadrastrar:");
                    iphone.Modelo = Console.ReadLine()!.Trim();
                    Console.WriteLine("\nDigite o ano do iphone (com apenas números inteiros):");
                    if (!int.TryParse(Console.ReadLine()!.Trim(), out int ano))
                    {
                        Console.WriteLine("Ano inválido, recomece seu cadastro.");
                        i--;
                        continue;
                    }
                    iphone.Ano = ano;
                    Console.WriteLine("\nDgite a cor do Iphone:");
                    iphone.Cor = Console.ReadLine()!.ToLower().Trim();
                    Console.WriteLine("\nDigite o valor do iphone:");
                    if (!decimal.TryParse(Console.ReadLine()!.Trim(), out decimal valor))
                    {
                        Console.WriteLine("Valor inválido, recomece seu cadastro.");
                        i--;
                        continue;
                    }
                    iphone.Valor = valor;
                    iphone.IsDisponivel = true;
                    Iphones.Add(iphone);
                }

                Console.WriteLine("\nO cadastro da Empresa e dos Iphones foi concluído com sucesso!");
            }
            catch
            {
                Console.Clear();
                Console.WriteLine($"Ocorreu um erro ao efetuir o cadastro do Iphone.");
            }

            Console.WriteLine("\nDigite qualquer tecla para voltar ao menu empresa.");
            Console.ReadKey();
            Console.Clear();
            menu.MenuInicial();


        }



        public void VisualizarInformacoesEmpresa()
        {

            try
            {
                Console.Clear();
                Console.WriteLine($"\nNome da empresa: {Loja}");
                Console.WriteLine($"\nCNPJ da empresa cadastrada: {CNPJ}");
                Console.WriteLine("\nIphones Disponíveis:");
                foreach (var iphone in Iphones)
                {
                    if (iphone.IsDisponivel)
                    {
                        Console.WriteLine($"\nModelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor}, Quantidade: {iphone.Quantidade}");
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Não foi possivel visualizar informações da empresa.");
            }
        }

        public void SelecionarEmpresa(Empresa empresa)
        {

            var EmpresaSelecionada = empresa;

        }


        public void VisualizarIphones()
        {
            var menu = new Menu();

            try
            {
                Console.Clear();
                Console.WriteLine("\nIphones disponíveis na loja:");

                if (Iphones != null && Iphones.Count != 0)

                {
                    foreach (var iphone in Iphones)
                    {
                        if (iphone.IsDisponivel)
                        {
                            Console.WriteLine($"\nModelo: {iphone.Modelo}, Ano: {iphone.Ano}, Cor: {iphone.Cor}, Valor: {iphone.Valor}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum iphone disponível na loja.");
                    
                }

            }

            catch
            {
                Console.Clear();
                Console.WriteLine("Não foi possível visualizar os iphones.");
            }

            Console.WriteLine("Digite qualquer tecla para voltar ao menu cliente.");
            Console.ReadKey();
            Console.Clear();
            menu.MenuCliente();



        }   
    }
}