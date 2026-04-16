using ProjetoPraticoClientes.Interfaces;
using ProjetoPraticoClientes.Interfaces.Views;
using ProjetoPraticoClientes.Servicos;

namespace ProjetoPraticoClientes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var repositorio = RepositorioSelecionacaoView.SelecionarRepositorio();
            var servico = new ClienteServico(repositorio);
            var interfaceConsole = new ClienteInterfaceConsole(servico);

            interfaceConsole.ExecutarMenuPrincipal();
        }
    }
}

