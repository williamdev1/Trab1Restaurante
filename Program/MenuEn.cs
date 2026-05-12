using System;

namespace Program;

public class MenuEn : IMenu
{
    public List<ItemPedido> ItensEn { get; set; } = new List<ItemPedido>();
    public void ExibirMenu()
    {
        Console.WriteLine("Welcome to the Restaurant!");
        Console.WriteLine("1. Management");
        Console.WriteLine("2. Orders");
        Console.WriteLine("3. Reports");
        Console.WriteLine("4. Exit");
    }
    public void Gerenciamento()
    {
        Console.WriteLine("1 - Register Item");
        Console.WriteLine("2 - Edit Item");
        Console.WriteLine("3 - Delete Item");
        Console.WriteLine("4 - List Items");
        Console.WriteLine("0 - Back");
    }

    public void Pedidos()
    {
        Console.WriteLine("1 - New Order");
        Console.WriteLine("2 - Edit Order");
        Console.WriteLine("3 - Pay Order");
        Console.WriteLine("0 - Back");
    }

    public void Relatorios()
    {
        Console.WriteLine("Select the Report.");
        Console.WriteLine("1 - By Period");
        Console.WriteLine("2 - By Client");
        Console.WriteLine("3 - Client by Period");
        Console.WriteLine("4 - Consumption by Item");
        Console.WriteLine("0 - Back");
    }
}
