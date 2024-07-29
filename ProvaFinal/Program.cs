using System.Security.Cryptography.X509Certificates;

namespace ProvaFinal
{
    public class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            var cliente = new Cliente("", 0, 0);
            var compra = new EfetuandoCompra();
            var empresa = new Empresa("", 0);
            menu.MenuInicial();
            empresa.CadastroEmpresa();

           
          
            cliente.CadastroCliente();
            empresa.VisualizarIphones();

            
            empresa.VisualizarInformacoesEmpresa();

            

            cliente.VisualizarInformacoesCliente();

            compra.EfetuarCompra();
        }
    } 
}
