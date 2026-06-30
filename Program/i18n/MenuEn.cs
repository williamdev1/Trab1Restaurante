using System;

namespace Program;

public class MenuEn : IMenu
{
    public string Idioma = "en";
    public List<ItemPedido> ItensEn { get; set; } = new List<ItemPedido>();
    public void ExibirMenu()
    {
        Console.WriteLine("Welcome to the Restaurant!");
        Console.WriteLine("1. Management");
        Console.WriteLine("2. Orders");
        Console.WriteLine("3. Reports");
        Console.WriteLine("4. Exit");
        Console.WriteLine("5. Change language");
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
    public void TrocarIdioma()
    {
        Console.WriteLine("Which language do you want to select?");
        Console.WriteLine("1. Portuguese");
        Console.WriteLine("2. English");
        Console.WriteLine("3. Spanish");
    }
    public void CadastrarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Password: ");
        string senha = Console.ReadLine() ?? string.Empty;
        if (senha != "0000")
        {
            Console.WriteLine("Access denied!");
            return;
        }

        Console.WriteLine("Access granted!");

        int cod;
        Console.WriteLine("Code: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Invalid value. Please enter a valid number:");
        }

        Console.WriteLine("Category (Appetizers, Beverages, MainCourses, Desserts): ");
        string catStr = Console.ReadLine() ?? string.Empty;
        Categoria cat;
        while (!Categoria.TryParse(catStr, out cat))
        {
            Console.WriteLine("Invalid category!");
        }

        bool ofer;
        Console.WriteLine("Offered (True/False): ");
        while (!bool.TryParse(Console.ReadLine(), out ofer))
        {
            Console.WriteLine("Invalid value. Please enter True or False:");
        }

        Console.WriteLine("Description in Portuguese: ");
        string descPt = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Description in English: ");
        string descEn = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Description in Spanish: ");
        string descEs = Console.ReadLine() ?? string.Empty;

        Dictionary<string, string> descricao = new Dictionary<string, string>
        {
            ["pt"] = descPt,
            ["en"] = descEn,
            ["es"] = descEs
        };

        decimal preco;
        Console.WriteLine("Price: ");
        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Invalid value. Please enter a valid decimal number:");
        }
        
        try
        {
            Cardapio.CadastrarItem(cod, cat, ofer, descricao, preco);
            Console.WriteLine("Item succesfully registered!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }
    public void EditarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Password: ");
        string senha = Console.ReadLine() ?? string.Empty;
        if (senha != "0000")
        {
            Console.WriteLine("Access denied!");
            return;
        }

        Console.WriteLine("Access granted!");

        int cod;
        Console.WriteLine("Code of the item to be edited: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Invalid value. Please enter a valid number:");
        }

        Console.WriteLine("New category (Appetizers, Beverages, MainCourses, Desserts): ");
        string catStr = Console.ReadLine() ?? string.Empty;
        Categoria cat;
        while (!Categoria.TryParse(catStr, out cat))
        {
            Console.WriteLine("Invalid category!");
        }

        bool ofer;
        Console.WriteLine("New offering status (True/False): ");
        while (!bool.TryParse(Console.ReadLine(), out ofer))
        {
            Console.WriteLine("Invalid value. Please enter True or False:");
        }

        Console.WriteLine("Description in Portuguese: ");
        string descPt = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Description in English: ");
        string descEn = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Description in Spanish: ");
        string descEs = Console.ReadLine() ?? string.Empty;

        Dictionary<string, string> descricao = new Dictionary<string, string>
        {
            ["pt"] = descPt,
            ["en"] = descEn,
            ["es"] = descEs
        };

        decimal preco;
        Console.WriteLine("New price: ");
        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Invalid value. Please enter a valid decimal number:");
        }

        if (Cardapio.EditarItem(cod, cat, ofer, descricao, preco))
        {
            Console.WriteLine("Item successfully edited!");
        }
        else
        {
            Console.WriteLine("Item not found!");
        }
    }
    public void DeletarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Password: ");
            string senha = Console.ReadLine() ?? string.Empty;
            if (senha != "0000")
            {
                Console.WriteLine("Access denied!");
                return;
            }

            Console.WriteLine("Access granted!");

            int cod;
            Console.WriteLine("Code of the item to be deleted: ");
            while (!int.TryParse(Console.ReadLine(), out cod))
            {
                Console.WriteLine("Invalid value. Please enter a valid number:");
            }

            if (Cardapio.DeletarItem(cod))
            {
                Console.WriteLine("Item successfully deleted!");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }
    }
    public void ListarItem(Cardapio Cardapio)
    {
        
        foreach (var item in Cardapio.Itens)
        {   
            Console.WriteLine($"Code: {item.Codigo} - Description: {item.DescricaoEm(Idioma)} - Price: {item.Preco}");
        }
    }
    public void ListarItensOferecidos(Cardapio Cardapio)
    {
        foreach (var item in Cardapio.Itens.Where(i => i.Oferecido))
        {
            Console.WriteLine($"Code: {item.Codigo} - Description: {item.DescricaoEm(Idioma)} - Price: {item.Preco}");
        }
    }

    public void CadastrarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes)
    {
        Pedido pedido = new Pedido();
        pedidos.Add(pedido);
        ListarItensOferecidos(cardapio);

        int cod;
        Console.WriteLine("Code: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Invalid value. Please enter a valid number:");
        }

        var item = cardapio.Itens.Find(i => i.Codigo == cod && i.Oferecido);
        if (item != null)
        {
            int qtd;
            Console.WriteLine("Quantity: ");
            while (!int.TryParse(Console.ReadLine(), out qtd))
            {
                Console.WriteLine("Invalid value. Please enter a valid number:");
            }

            pedido.AdicionarItem(item, qtd);
            Console.WriteLine("Item added!");
        }
        else
        {
            Console.WriteLine("Item not found!");
        }

        bool registrado;
        Console.WriteLine("Registered customer? (True/False)");
        while (!bool.TryParse(Console.ReadLine(), out registrado))
        {
            Console.WriteLine("Invalid value. Please enter True or False:");
        }

        if (registrado)
        {
            Console.WriteLine("Customer's name: ");
            string nomeCliente = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Customer's email: ");
            string emailCliente = Console.ReadLine() ?? string.Empty;
            foreach (var cliente in clientes)
            {
                if (cliente.Nome == nomeCliente && cliente.Email == emailCliente)
                {
                    pedido.Cliente = cliente;
                    Console.WriteLine("Customer linked to the order!");
                    break;
                }
            }
        }
    }
    public void MostrarPedidos(List<Pedido> pedidos)
    {
        if (pedidos.Count == 0)
        {
            Console.WriteLine("No orders have been created yet.");
        }
        foreach (var pedido in pedidos)
        {
            if (!pedido.Pago)
            {
                Console.WriteLine($"ID: {pedido.IdPedido}, Customer: {pedido.Cliente?.Nome ?? "Anonymous"}, Total: {pedido.ValorTotal}, Paid: {pedido.Pago}");
            }
        }
    }

    public void EditarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes)
    {
        MostrarPedidos(pedidos);
        int id;
        Console.WriteLine("ID of the order: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid value. Please enter a valid number:");
        }

        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
        if (pedido != null)
        {
            MostrarItens(cardapio, pedido);
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Remove item");
            int op;
            while (!int.TryParse(Console.ReadLine(), out op) || (op != 1 && op != 2))
            {
                Console.WriteLine("Invalid option. Please enter 1 or 2:");
            }
            if (op == 1)
            {
                ListarItensOferecidos(cardapio);
                int cod;
                Console.WriteLine("Code: ");
                while (!int.TryParse(Console.ReadLine(), out cod))
                {
                    Console.WriteLine("Invalid value. Please enter a valid number:");
                }
                
                int qtd;
                Console.WriteLine("Quantity: ");
                while (!int.TryParse(Console.ReadLine(), out qtd))
                {
                    Console.WriteLine("Invalid value. Please enter a valid number:");
                }

                try
                {
                    pedido.Editar(cardapio, op, cod, qtd);
                    Console.WriteLine("Operation completed!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (op == 2)
            {
                MostrarItens(cardapio, pedido);
                int cod;
                Console.WriteLine("Code: ");
                while (!int.TryParse(Console.ReadLine(), out cod))
                {
                    Console.WriteLine("Invalid value. Please enter a valid number:");
                }
                
                int qtd;
                Console.WriteLine("Quantity: ");
                while (!int.TryParse(Console.ReadLine(), out qtd))
                {
                    Console.WriteLine("Invalid value. Please enter a valid number:");
                }

                try
                {
                    pedido.Editar(cardapio, op, cod, qtd);
                    Console.WriteLine("Operation completed!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        else
        {
            Console.WriteLine("Order not found!");
        }
    }
    public void MostrarItens(Cardapio Cardapio, Pedido pedido)
    {
        if (pedido.Itens.Count == 0)
        {
            Console.WriteLine("No items in the order.");
            return;
        }

        foreach (var item in pedido.Itens)
        {
            Console.WriteLine($"Code: {item.Codigo} - {item.DescricaoEm(Idioma)} - Quantity: {item.Quantidade} - Subtotal: {item.Subtotal}");
        }
    }

    public void PagarPedido(List<Pedido> pedidos)
    {
        MostrarPedidos(pedidos);
        int id;
        Console.WriteLine("ID of the order: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid value. Please enter a valid number:");
        }

        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
        if(pedido.Pago)
        {
            Console.WriteLine("Order has already been paid!");
            return;
        }
        if (pedido != null)
        {
            Console.WriteLine($"Total value: {pedido.ValorTotal}");

            bool dividir;
            Console.WriteLine("Divide bill? (True/False)");
            while (!bool.TryParse(Console.ReadLine(), out dividir))
            {
                Console.WriteLine("Invalid value. Please enter True or False:");
            }

            bool confirmar;
            Console.WriteLine("Confirm payment? (True/False)");
            while (!bool.TryParse(Console.ReadLine(), out confirmar))
            {
                Console.WriteLine("Invalid value. Please enter True or False:");
            }

            try
            {
                pedido.Pagar(dividir, confirmar);
                if (confirmar)
                {
                    Console.WriteLine("Order paid!");
                    pedido.Pago = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Order not found!");
        }
    }
    public void FiltrarPorPeriodo(List<Pedido> pedidos)
    {
        DateTime inicio;
        Console.WriteLine("Start date (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
        {
            Console.WriteLine("Invalid date. Enter a valid date:");
        }

        DateTime fim;
        Console.WriteLine("End date (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out fim))
        {
            Console.WriteLine("Invalid date. Enter a valid date:");
        }

        new RelatorioPedidosEmTela().FiltrarPorPeriodo(pedidos, inicio, fim);
        new RelatorioPedidosParaArquivo().FiltrarPorPeriodo(pedidos, inicio, fim);
        //Console.WriteLine($"Orders in the period {inicio} to {fim}:");
        // foreach (var p in pedidosFiltrados)
        // {
        //     Console.WriteLine($"ID: {p.IdPedido}, Customer: {p.Cliente?.Nome ?? "Anonymous"}, Total: {p.ValorTotal}, Paid: {p.Pago}");
        // }
    }

    public void FiltrarPorCliente(List<Pedido> pedidos)
    {
        Console.WriteLine("Customer name: ");
        string nome = Console.ReadLine() ?? string.Empty;
        new RelatorioPedidosEmTela().FiltrarPorCliente(pedidos, nome);
        new RelatorioPedidosParaArquivo().FiltrarPorCliente(pedidos, nome);
        //var pedidosFiltrados = relatorio.FiltrarPorCliente(pedidos, nome);
        //Console.WriteLine($"Orders for customer {nome}:");
        //foreach (var p in pedidosFiltrados)
        //{
        //     Console.WriteLine($"ID: {p.IdPedido}, Customer: {p.Cliente?.Nome ?? "Anonymous"}, Total: {p.ValorTotal}, Paid: {p.Pago}");
        //}
    }

    public void FiltrarPorClientePeriodo(List<Pedido> pedidos)
    {
        Console.WriteLine("Customer name: ");
        string nome = Console.ReadLine() ?? string.Empty;

        DateTime inicio;
        Console.WriteLine("Start date (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
        {
            Console.WriteLine("Invalid date. Enter a valid date (yyyy-MM-dd):");
        }

        DateTime fim;
        Console.WriteLine("End date (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out fim))
        {
            Console.WriteLine("Invalid date. Enter a valid date (yyyy-MM-dd):");
        }
        new RelatorioPedidosEmTela().FiltrarPorClientePeriodo(pedidos, nome, inicio, fim);
        new RelatorioPedidosParaArquivo().FiltrarPorClientePeriodo(pedidos, nome, inicio, fim);
        // var pedidosFiltrados = relatorio.FiltrarPorClientePeriodo(pedidos, nome, inicio, fim);
        // Console.WriteLine($"Orders for customer {nome} in the period {inicio} to {fim}:");
        // foreach (var p in pedidosFiltrados)
        // {
        //     Console.WriteLine($"ID: {p.IdPedido}, Customer: {p.Cliente?.Nome ?? "Anonymous"}, Total: {p.ValorTotal}, Paid: {p.Pago}");
        // }
    }

    public void CalcularConsumoItem(List<Pedido> pedidos)
    {
        int cod;
        Console.WriteLine("Code: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Invalid value. Enter a valid number:");
        }

        int total;
        new RelatorioPedidosEmTela().CalcularConsumoItem(pedidos, cod, out total);
        new RelatorioPedidosParaArquivo().CalcularConsumoItem(pedidos, cod, out total);
        // var consumo = relatorio.CalcularConsumoItem(pedidos, cod, out total);
        // Console.WriteLine($"Consumption of item {cod}:");
        // foreach (var c in consumo)
        // {
        //     Console.WriteLine($"ID Order: {c.IdPedido}, Quantity: {c.Quantidade}");
        // }
        // Console.WriteLine($"Total consumed: {total}");
    }
    
}
