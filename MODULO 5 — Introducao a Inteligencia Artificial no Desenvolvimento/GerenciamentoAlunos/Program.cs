using GerenciamentoAlunos.Repositories;
using GerenciamentoAlunos.Services;
using GerenciamentoAlunos.UI;

var repository = new AlunoRepository();
var service = new AlunoService(repository);
var menu = new Menu(service);

menu.Executar();
