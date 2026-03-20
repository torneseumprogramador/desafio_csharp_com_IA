using ProjetoPraticoClientes.Interfaces.Views;
using ProjetoPraticoClientes.Servicos;

namespace ProjetoPraticoClientes.Interfaces
{
    public class ClienteInterfaceConsole
    {
        private readonly ClienteOperacoesView _operacoes;
        private readonly CadastrarClienteView _cadastro;

        public ClienteInterfaceConsole(ClienteServico servico)
        {
            _operacoes = new ClienteOperacoesView(servico);
            _cadastro = new CadastrarClienteView(servico);
        }

        public void ExecutarMenuPrincipal()
        {
            ClienteMenuPrincipalView.Executar(_cadastro, _operacoes);
        }
    }
}

