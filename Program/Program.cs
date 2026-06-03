using System;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Program programa = new Program();
        Cardapio cardapio = new Cardapio();
        cardapio.InicializarMock();
        List<Pedido> pedidos = new List<Pedido>();
        List<Pessoa> clientes = new List<Pessoa>
        {
            new Pessoa { Nome = "João Silva", Email = "joaosilva@gmail.com" },
            new Pessoa { Nome = "Maria Oliveira", Email = "mariaoliveira@gmail.com" },
            new Pessoa { Nome = "Carlos Santos", Email = "carlossantos@gmail.com" },
            new Pessoa { Nome = "Ana Pereira", Email = "anapereira@gmail.com" },
            new Pessoa { Nome = "Pedro Costa", Email = "pedrocosta@gmail.com" }
        };
        Relatorio relatorio = new Relatorio();

        pedidos.Add(new Pedido { Cliente = clientes[0] });
        pedidos.Add(new Pedido { Cliente = clientes[1] });
        pedidos.Add(new Pedido { Cliente = clientes[2] });
        pedidos.Add(new Pedido { Cliente = clientes[3] });
        pedidos.Add(new Pedido { Cliente = clientes[4] });

        Console.WriteLine("1. Português - PT");
        Console.WriteLine("2. English - EN");

        int escolha;
        while (!int.TryParse(Console.ReadLine(), out escolha) || (escolha != 1 && escolha != 2))
        {
            Console.WriteLine("Opção inválida. Digite 1 para Português ou 2 para English:");
        }

        if (escolha == 1)
        {
            IMenu menu = new MenuPt();
            int opcao;
            do
            {
                menu.ExibirMenu();
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 4)
                {
                    Console.WriteLine("Opção inválida. Digite um número entre 0 e 4:");
                }

                if (opcao == 1)
                {
                    menu.Gerenciamento();
                    int opcaoGerenciamento;
                    while (!int.TryParse(Console.ReadLine(), out opcaoGerenciamento) || opcaoGerenciamento < 0 || opcaoGerenciamento > 4)
                    {
                        Console.WriteLine("Opção inválida. Digite um número entre 0 e 4:");
                    }

                    if (opcaoGerenciamento == 1)
                    {
                        menu.CadastrarItem(cardapio);
                    }
                    else if (opcaoGerenciamento == 2)
                    {
                        menu.EditarItem(cardapio);
                    }
                    else if (opcaoGerenciamento == 3)
                    {
                        menu.DeletarItem(cardapio);
                    }
                    else if (opcaoGerenciamento == 4)
                    {
                        menu.ListarItem(cardapio);
                    }
                    else if (opcaoGerenciamento == 0)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                    }
                }
                else if (opcao == 2)
                {
                    menu.Pedidos();
                    int opcaopedidos;
                    while (!int.TryParse(Console.ReadLine(), out opcaopedidos) || opcaopedidos < 0 || opcaopedidos > 3)
                    {
                        Console.WriteLine("Opção inválida. Digite um número entre 0 e 3:");
                    }

                    if (opcaopedidos == 1)
                    {
                        menu.CadastrarPedido(pedidos, cardapio, clientes);
                    }
                    else if (opcaopedidos == 2)
                    {
                        menu.EditarPedido(pedidos, cardapio, clientes);
                    }
                    else if (opcaopedidos == 3)
                    {
                        menu.PagarPedido(pedidos);
                    }
                    else if (opcaopedidos == 0)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                    }
                else if (opcao == 3)
                {
                    menu.Relatorios();
                    int oprel;
                    while (!int.TryParse(Console.ReadLine(), out oprel) || oprel < 0 || oprel > 4)
                    {
                        Console.WriteLine("Opção inválida. Digite um número entre 0 e 4:");
                    }

                    if (oprel == 1)
                    {
                        DateTime inicio;
                        Console.WriteLine("Data início (yyyy-MM-dd): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
                        {
                            Console.WriteLine("Data inválida. Digite uma data válida:");
                        }

                        DateTime fim;
                        Console.WriteLine("Data fim (yyyy-MM-dd): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out fim))
                        {
                            Console.WriteLine("Data inválida. Digite uma data válida:");
                        }

                        var pedidosFiltrados = relatorio.FiltrarPorPeriodo(pedidos, inicio, fim);
                        Console.WriteLine($"Pedidos no período {inicio} a {fim}:");
                        foreach (var p in pedidosFiltrados)
                        {
                            Console.WriteLine($"ID: {p.IdPedido}, Cliente: {p.Cliente?.Nome ?? "Anônimo"}, Total: {p.ValorTotal}, Pago: {p.Pago}");
                        }
                    }
                    else if (oprel == 2)
                    {
                        Console.WriteLine("Nome do cliente: ");
                        string nome = Console.ReadLine() ?? string.Empty;
                        var pedidosFiltrados = relatorio.FiltrarPorCliente(pedidos, nome);
                        Console.WriteLine($"Pedidos do cliente {nome}:");
                        foreach (var p in pedidosFiltrados)
                        {
                            Console.WriteLine($"ID: {p.IdPedido}, Total: {p.ValorTotal}, Pago: {p.Pago}");
                        }
                    }
                    else if (oprel == 3)
                    {
                        Console.WriteLine("Nome do cliente: ");
                        string nome = Console.ReadLine() ?? string.Empty;

                        DateTime inicio;
                        Console.WriteLine("Data início (yyyy-MM-dd): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
                        {
                            Console.WriteLine("Data inválida. Digite uma data válida:");
                        }

                        DateTime fim;
                        Console.WriteLine("Data fim (yyyy-MM-dd): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out fim))
                        {
                            Console.WriteLine("Data inválida. Digite uma data válida:");
                        }

                        var pedidosFiltrados = relatorio.FiltrarPorClientePeriodo(pedidos, nome, inicio, fim);
                        Console.WriteLine($"Pedidos do cliente {nome} no período {inicio} a {fim}:");
                        foreach (var p in pedidosFiltrados)
                        {
                            Console.WriteLine($"ID: {p.IdPedido}, Total: {p.ValorTotal}, Pago: {p.Pago}");
                        }
                    }
                    else if (oprel == 4)
                    {
                        int cod;
                        Console.WriteLine("Código do item: ");
                        while (!int.TryParse(Console.ReadLine(), out cod))
                        {
                            Console.WriteLine("Valor inválido. Digite um número válido:");
                        }

                        var consumo = relatorio.CalcularConsumoItem(pedidos, cod, out int totalConsumido);
                        foreach (var item in consumo)
                        {
                            Console.WriteLine($"Pedido {item.IdPedido}: {item.Quantidade} unidades");
                        }
                        Console.WriteLine($"Total consumido do item {cod}: {totalConsumido}");
                    }
                    else if (oprel == 0)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                    }
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("Até mais!");
                    break;
                }
            } while (opcao != 0);
        }

        else if (escolha == 2)
        {
            IMenu menu = new MenuEn();
            int opcao;
            do
            {
                menu.ExibirMenu();
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 4)
                {
                    Console.WriteLine("Invalid option. Enter a number between 0 and 4:");
                }

                if (opcao == 1)
                {
                    menu.Gerenciamento();
                    int opcaoGerenciamento;
                    while (!int.TryParse(Console.ReadLine(), out opcaoGerenciamento) || opcaoGerenciamento < 0 || opcaoGerenciamento > 4)
                    {
                        Console.WriteLine("Invalid option. Enter a number between 0 and 4:");
                    }

                    if (opcaoGerenciamento == 1)
                    {
                        int cod;
                        Console.WriteLine("Code: ");
                        while (!int.TryParse(Console.ReadLine(), out cod))
                        {
                            Console.WriteLine("Invalid value. Enter a valid number:");
                        }

                        Console.WriteLine("Category (entradas, bebidas, pratos principais, sobremesas): ");
                        string catStr = Console.ReadLine() ?? string.Empty;
                        Categoria cat;
                        if (!Categoria.TryParse(catStr, out cat))
                        {
                            Console.WriteLine("Invalid category!");
                            continue;
                        }

                        bool ofer;
                        Console.WriteLine("Offered (True/False): ");
                        while (!bool.TryParse(Console.ReadLine(), out ofer))
                        {
                            Console.WriteLine("Invalid value. Type True or False:");
                        }

                        Console.WriteLine("Description: ");
                        string desc = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Description in English: ");
                        string descEn = Console.ReadLine() ?? string.Empty;

                        decimal preco;
                        Console.WriteLine("Price: ");
                        while (!decimal.TryParse(Console.ReadLine(), out preco))
                        {
                            Console.WriteLine("Invalid value. Enter a valid decimal number:");
                        }

                        try
                        {
                            cardapio.CadastrarItem(cod, cat, ofer, desc, descEn, preco);
                            Console.WriteLine("Item registered successfully!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (opcaoGerenciamento == 2)
                    {
                        int cod;
                        Console.WriteLine("Code of the item to be edited: ");
                        while (!int.TryParse(Console.ReadLine(), out cod))
                        {
                            Console.WriteLine("Invalid value. Enter a valid number:");
                        }

                        Console.WriteLine("New category (entradas, bebidas, pratos principais, sobremesas): ");
                        string catStr = Console.ReadLine() ?? string.Empty;
                        if (!Categoria.TryParse(catStr, out Categoria cat))
                        {
                            Console.WriteLine("Invalid category!");
                            continue;
                        }

                        bool ofer;
                        Console.WriteLine("New offered status (True/False): ");
                        while (!bool.TryParse(Console.ReadLine(), out ofer))
                        {
                            Console.WriteLine("Invalid value. Type True or False:");
                        }

                        Console.WriteLine("New description: ");
                        string desc = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("New description in English: ");
                        string descEn = Console.ReadLine() ?? string.Empty;

                        decimal preco;
                        Console.WriteLine("New price: ");
                        while (!decimal.TryParse(Console.ReadLine(), out preco))
                        {
                            Console.WriteLine("Invalid value. Enter a valid decimal number:");
                        }

                        if (cardapio.EditarItem(cod, cat, ofer, desc, descEn, preco))
                        {
                            Console.WriteLine("Item edited successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Item not found!");
                        }
                    }
                    else if (opcaoGerenciamento == 3)
                    {
                        int cod;
                        Console.WriteLine("Code of the item to be deleted: ");
                        while (!int.TryParse(Console.ReadLine(), out cod))
                        {
                            Console.WriteLine("Invalid value. Enter a valid number:");
                        }

                        if (cardapio.DeletarItem(cod))
                        {
                            Console.WriteLine("Item deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Item not found!");
                        }
                    }
                    else if (opcaoGerenciamento == 4)
                    {
                        cardapio.ListarItem("en");
                    }
                    else if (opcaoGerenciamento == 0)
                    {
                        Console.WriteLine("Back to main menu...");
                    }
                }
                else if (opcao == 2)
                {
                    menu.Pedidos();
                    int opcaopedidos;
                    while (!int.TryParse(Console.ReadLine(), out opcaopedidos) || opcaopedidos < 0 || opcaopedidos > 3)
                    {
                        Console.WriteLine("Invalid option. Enter a number between 0 and 3:");
                    }

                    if (opcaopedidos == 1)
                    {
                        Pedido pedido = new Pedido();
                        pedidos.Add(pedido);
                        Console.WriteLine($"Order created with ID: {pedido.IdPedido}");
                        cardapio.ListarItensOferecidos("en");

                        int cod;
                        Console.WriteLine("Item code: ");
                        while (!int.TryParse(Console.ReadLine(), out cod))
                        {
                            Console.WriteLine("Invalid value. Enter a valid number:");
                        }

                        var item = cardapio.Itens.Find(i => i.Codigo == cod && i.Oferecido);
                        if (item != null)
                        {
                            int qtd;
                            Console.WriteLine("Quantity: ");
                            while (!int.TryParse(Console.ReadLine(), out qtd))
                            {
                                Console.WriteLine("Invalid value. Enter a valid number:");
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
                            Console.WriteLine("Invalid value. Type True or False:");
                        }

                        if (registrado)
                        {
                            Console.WriteLine("Customer name: ");
                            string nomeCliente = Console.ReadLine() ?? string.Empty;
                            Console.WriteLine("Customer email: ");
                            string emailCliente = Console.ReadLine() ?? string.Empty;
                            foreach (var cliente in clientes)
                            {
                                if (cliente.Nome == nomeCliente && cliente.Email == emailCliente)
                                {
                                    pedido.Cliente = cliente;
                                    Console.WriteLine("Customer already registered. Linked to the order!");
                                    break;
                                }
                            }
                        }
                    }
                    else if (opcaopedidos == 2)
                    {
                        programa.MostrarPedidos(pedidos, "en");
                        int id;
                        Console.WriteLine("Order ID: ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid value. Enter a valid number:");
                        }

                        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
                        if (pedido != null)
                        {
                            pedido.MostrarItens("en");
                            Console.WriteLine("1. Add item");
                            Console.WriteLine("2. Remove item");

                            int op;
                            while (!int.TryParse(Console.ReadLine(), out op) || (op != 1 && op != 2))
                            {
                                Console.WriteLine("Invalid option. Enter 1 or 2:");
                            }
                            if(op == 1)
                            {
                                cardapio.ListarItensOferecidos("en");
                                int cod;
                                Console.WriteLine("Item code: ");
                                while (!int.TryParse(Console.ReadLine(), out cod))
                                {
                                    Console.WriteLine("Invalid value. Enter a valid number:");
                                }
                                
                                int qtd;
                                Console.WriteLine("Quantity: ");
                                while (!int.TryParse(Console.ReadLine(), out qtd))
                                {
                                    Console.WriteLine("Invalid value. Enter a valid number:");
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
                                pedido.MostrarItens("en");
                                int cod;
                                Console.WriteLine("Item code: ");
                                while (!int.TryParse(Console.ReadLine(), out cod))
                                {
                                    Console.WriteLine("Invalid value. Enter a valid number:");
                                }
                                int qtd;
                                Console.WriteLine("Quantity: ");
                                while (!int.TryParse(Console.ReadLine(), out qtd))
                                {
                                    Console.WriteLine("Invalid value. Enter a valid number:");
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
                    else if (opcaopedidos == 3)
                    {
                        programa.MostrarPedidos(pedidos, "en");
                        int id;
                        Console.WriteLine("Order ID: ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid value. Enter a valid number:");
                        }

                        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
                        if (pedido != null)
                        {
                            Console.WriteLine($"Total value: {pedido.ValorTotal}");

                            bool dividir;
                            Console.WriteLine("Split bill? (True/False)");
                            while (!bool.TryParse(Console.ReadLine(), out dividir))
                            {
                                Console.WriteLine("Invalid value. Enter True or False:");
                            }

                            bool confirmar;
                            Console.WriteLine("Confirm payment? (True/False)");
                            while (!bool.TryParse(Console.ReadLine(), out confirmar))
                            {
                                Console.WriteLine("Invalid value. Enter True or False:");
                            }

                            try
                            {
                                pedido.Pagar(dividir, confirmar);
                                if (confirmar)
                                {
                                    Console.WriteLine("Order paid!");
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
                    else if (opcaopedidos == 0)
                    {
                        Console.WriteLine("Back to main menu...");
                    }
                }
                else if (opcao == 3)
                {
                    menu.Relatorios();
                    int oprel;
                    while (!int.TryParse(Console.ReadLine(), out oprel) || oprel < 0 || oprel > 4)
                    {
                        Console.WriteLine("Invalid option. Enter a number between 0 and 4:");
                    }

                    if (oprel == 1)
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

                        var pedidosFiltrados = relatorio.FiltrarPorPeriodo(pedidos, inicio, fim);
                        Console.WriteLine($"Orders from {inicio} to {fim}:");
                        foreach (var p in pedidosFiltrados)
                        {
                            Console.WriteLine($"ID: {p.IdPedido}, Customer: {p.Cliente?.Nome ?? "Anonymous"}, Total: {p.ValorTotal}, Paid: {p.Pago}");
                        }
                    }
                    else if (oprel == 2)
                    {
                        Console.WriteLine("Customer name: ");
                        string nome = Console.ReadLine() ?? string.Empty;
                        var pedidosFiltrados = relatorio.FiltrarPorCliente(pedidos, nome);
                        Console.WriteLine($"Orders for customer {nome}:");
                        foreach (var p in pedidosFiltrados)
                        {
                            Console.WriteLine($"ID: {p.IdPedido}, Total: {p.ValorTotal}, Paid: {p.Pago}");
                        }
                    }
                    else if (oprel == 3)
                    {
                        Console.WriteLine("Customer name: ");
                        string nome = Console.ReadLine() ?? string.Empty;

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

                        var pedidosFiltrados = relatorio.FiltrarPorClientePeriodo(pedidos, nome, inicio, fim);
                        Console.WriteLine($"Orders for customer {nome} from {inicio} to {fim}:");
                        foreach (var p in pedidosFiltrados)
                        {
                            Console.WriteLine($"ID: {p.IdPedido}, Total: {p.ValorTotal}, Paid: {p.Pago}");
                        }
                    }
                    else if (oprel == 4)
                    {
                        int cod;
                        Console.WriteLine("Item code: ");
                        while (!int.TryParse(Console.ReadLine(), out cod))
                        {
                            Console.WriteLine("Invalid value. Enter a valid number:");
                        }

                        var consumo = relatorio.CalcularConsumoItem(pedidos, cod, out int totalConsumido);
                        foreach (var item in consumo)
                        {
                            Console.WriteLine($"Order {item.IdPedido}: {item.Quantidade} units");
                        }
                        Console.WriteLine($"Total consumed for item {cod}: {totalConsumido}");
                    }
                    else if (oprel == 0)
                    {
                        Console.WriteLine("Back to main menu...");
                    }
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            } while (opcao != 0);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please restart the program and choose 1 or 2.");
        }
    }
}
