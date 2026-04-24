using _01___Explicacao.Context;
using _01___Explicacao.Models;
using _01___Explicacao.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace _01___Explicacao.UI;

public sealed class MovimentacaoMenu
{
    private readonly AppDbContext _db;

    public MovimentacaoMenu(AppDbContext db)
    {
        _db = db;
    }

    public void Run()
    {
        while (true)
        {
            MenuRenderer.ShowHeader("MOVIMENTACOES");
            Console.WriteLine("1 - Registrar entrada");
            Console.WriteLine("2 - Registrar saida");
            Console.WriteLine("3 - Listar movimentacoes");
            Console.WriteLine("0 - Voltar");
            var option = InputHelper.ReadRequired("Escolha: ");

            switch (option)
            {
                case "1":
                    RegisterEntrada();
                    break;
                case "2":
                    RegisterSaida();
                    break;
                case "3":
                    ListMovimentacoes();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opcao invalida.");
                    MenuRenderer.Pause();
                    break;
            }
        }
    }

    private void RegisterEntrada()
    {
        MenuRenderer.ShowHeader("REGISTRAR ENTRADA");
        var veiculoId = InputHelper.ReadInt("VeiculoId: ");
        var vagaId = InputHelper.ReadInt("VagaId: ");

        var veiculoExists = _db.Veiculos.Any(v => v.Id == veiculoId);
        if (!veiculoExists)
        {
            Console.WriteLine("Veiculo nao encontrado.");
            MenuRenderer.Pause();
            return;
        }

        var vaga = _db.Vagas.SingleOrDefault(v => v.Id == vagaId);
        if (vaga is null)
        {
            Console.WriteLine("Vaga nao encontrada.");
            MenuRenderer.Pause();
            return;
        }

        if (vaga.Status != StatusVaga.Livre)
        {
            Console.WriteLine("Vaga nao esta livre.");
            MenuRenderer.Pause();
            return;
        }

        var hasEntradaAberta = _db.Movimentacoes.Any(m => m.VeiculoId == veiculoId && m.DataSaida == null);
        if (hasEntradaAberta)
        {
            Console.WriteLine("Esse veiculo ja possui entrada em aberto.");
            MenuRenderer.Pause();
            return;
        }

        var movimentacao = new Movimentacao
        {
            VeiculoId = veiculoId,
            VagaId = vagaId,
            DataEntrada = DateTime.Now
        };

        vaga.Status = StatusVaga.Ocupada;
        _db.Movimentacoes.Add(movimentacao);
        _db.SaveChanges();

        Console.WriteLine($"Entrada registrada. Movimentacao Id: {movimentacao.Id}");
        MenuRenderer.Pause();
    }

    private void RegisterSaida()
    {
        MenuRenderer.ShowHeader("REGISTRAR SAIDA");
        var movimentacaoId = InputHelper.ReadInt("MovimentacaoId: ");

        var movimentacao = _db.Movimentacoes
            .Include(m => m.Vaga)
            .SingleOrDefault(m => m.Id == movimentacaoId);

        if (movimentacao is null)
        {
            Console.WriteLine("Movimentacao nao encontrada.");
            MenuRenderer.Pause();
            return;
        }

        if (movimentacao.DataSaida is not null)
        {
            Console.WriteLine("Essa movimentacao ja foi encerrada.");
            MenuRenderer.Pause();
            return;
        }

        movimentacao.DataSaida = DateTime.Now;
        movimentacao.ValorCobrado = InputHelper.ReadDecimal("Valor cobrado: ");
        movimentacao.Vaga.Status = StatusVaga.Livre;

        _db.SaveChanges();
        Console.WriteLine("Saida registrada com sucesso.");
        MenuRenderer.Pause();
    }

    private void ListMovimentacoes()
    {
        MenuRenderer.ShowHeader("LISTA DE MOVIMENTACOES");
        var movimentacoes = _db.Movimentacoes
            .Include(m => m.Veiculo)
            .Include(m => m.Vaga)
            .OrderByDescending(m => m.Id)
            .ToList();

        if (movimentacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma movimentacao cadastrada.");
            MenuRenderer.Pause();
            return;
        }

        foreach (var movimentacao in movimentacoes)
        {
            var situacao = movimentacao.DataSaida is null ? "EM ABERTO" : "ENCERRADA";
            Console.WriteLine(
                $"[{movimentacao.Id}] Veiculo: {movimentacao.Veiculo.Placa} | Vaga: {movimentacao.Vaga.Codigo} | Entrada: {movimentacao.DataEntrada:g} | Saida: {movimentacao.DataSaida:g} | Valor: {movimentacao.ValorCobrado:C} | {situacao}");
        }

        MenuRenderer.Pause();
    }
}
