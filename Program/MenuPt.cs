using System;

namespace Program;

public class MenuPt : IMenu
{
    public void ExibirMenu()
    {
        Console.WriteLine("Menu Principal");
        Console.WriteLine("1. Gerenciamento");
        Console.WriteLine("2. Pedidos");
        Console.WriteLine("3. Relatórios");
        Console.WriteLine("4. Sair");
    }
    public void Gerenciamento()
    {
        Console.WriteLine("1 - Cadastrar Item");
        Console.WriteLine("2 - Editar Item");
        Console.WriteLine("3 - Deletar Item");
        Console.WriteLine("4 - Listar Itens");
        Console.WriteLine("0 - Voltar");
    }

    public void Pedidos()
    {
        Console.WriteLine("1 - Novo Pedido");
        Console.WriteLine("2 - Editar Pedido");
        Console.WriteLine("3 - Pagar Pedido");
        Console.WriteLine("0 - Voltar");
    }

    public void Relatorios()
    {
        Console.WriteLine("Selecione o Relatório.");
        Console.WriteLine("1 - Por Período");
        Console.WriteLine("2 - Por Cliente");
        Console.WriteLine("3 - Cliente em Período");
        Console.WriteLine("4 - Consumo por Item");
        Console.WriteLine("0 - Voltar");
    }
    public static void CadastrarItem();

}
