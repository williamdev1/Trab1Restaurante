using System;
using System.Text.Json;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        string diretorioDados = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string caminhoCardapio = Path.Combine(diretorioDados, "cardapio.json");
        string caminhoPedidos = Path.Combine(diretorioDados, "pedidos.json");
        string caminhoClientes = Path.Combine(diretorioDados, "clientes.json");

        Cardapio cardapio = new Cardapio();
        
        string cardapioJson = File.ReadAllText(caminhoCardapio);
        cardapio = JsonSerializer.Deserialize<Cardapio>(cardapioJson);

        List<Pedido> pedidos = new List<Pedido>();
        
        string pedidosJson = File.ReadAllText(caminhoPedidos);
        pedidos = JsonSerializer.Deserialize<List<Pedido>>(pedidosJson);

        List<Pessoa> clientes = new List<Pessoa>();
    
        string clientesJson = File.ReadAllText(caminhoClientes);
        clientes = JsonSerializer.Deserialize<List<Pessoa>>(clientesJson);
        
        //Relatorio relatorio = new Relatorio();
        
        Console.WriteLine("1. Português - PT");
        Console.WriteLine("2. English - EN");
        Console.WriteLine("3. Español - ESP");

        int escolha;
        while (!int.TryParse(Console.ReadLine(), out escolha) || (escolha != 1 && escolha != 2 && escolha != 3))
        {
            Console.WriteLine("Erro!:");
        }

        if (escolha == 1)
        {
            IMenu menu = new MenuPt();
            int opcao;
            do
            {
                menu.ExibirMenu();
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 5)
                {
                    Console.WriteLine("Opção inválida. Digite um número entre 0 e 5:");
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
                        menu.FiltrarPorPeriodo(pedidos);
                    }
                    else if (oprel == 2)
                    {
                        menu.FiltrarPorCliente(pedidos);
                    }
                    else if (oprel == 3)
                    {
                        menu.FiltrarPorClientePeriodo(pedidos);
                    }
                    else if (oprel == 4)
                    {
                        menu.CalcularConsumoItem(pedidos);
                    }
                    else if (oprel == 0)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                    }
                }
                else if (opcao == 4)
                {
                    string conteudojson = JsonSerializer.Serialize(cardapio);
                    File.WriteAllText(caminhoCardapio, conteudojson);

                    conteudojson = JsonSerializer.Serialize(pedidos);
                    File.WriteAllText(caminhoPedidos, conteudojson);

                    conteudojson = JsonSerializer.Serialize(clientes);
                    File.WriteAllText(caminhoClientes, conteudojson);
                    menu.Sair();
                    break;
                }
                else if (opcao == 5)
                {
                    menu.TrocarIdioma();
                    int novaEscolha;
                    while (!int.TryParse(Console.ReadLine(), out novaEscolha) || (novaEscolha != 1 && novaEscolha != 2 && novaEscolha != 3))
                    {
                        Console.WriteLine("Opção inválida. Digite 1 para Português, 2 para Inglês e 3 para Espanhol:");
                    }
                    if (novaEscolha == 1)
                    {
                        menu = new MenuPt();
                    }
                    else if (novaEscolha == 2)
                    {
                        menu = new MenuEn();
                    }
                    else if (novaEscolha == 3)
                    {
                        menu = new MenuEsp();
                    }
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
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 5)
                {
                    Console.WriteLine("Invalid option. Enter a number between 0 and 5:");
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
                        menu.FiltrarPorPeriodo(pedidos);
                    }
                    else if (oprel == 2)
                    {
                        menu.FiltrarPorCliente(pedidos);
                    }
                    else if (oprel == 3)
                    {
                        menu.FiltrarPorClientePeriodo(pedidos);
                    }
                    else if (oprel == 4)
                    {
                        menu.CalcularConsumoItem(pedidos);
                    }
                    else if (oprel == 0)
                    {
                        Console.WriteLine("Back to main menu...");
                    }
                }
                else if (opcao == 4)
                {
                    string conteudojson = JsonSerializer.Serialize(cardapio);
                    File.WriteAllText(caminhoCardapio, conteudojson);

                    conteudojson = JsonSerializer.Serialize(pedidos);
                    File.WriteAllText(caminhoPedidos, conteudojson);

                    conteudojson = JsonSerializer.Serialize(clientes);
                    File.WriteAllText(caminhoClientes, conteudojson);
                    menu.Sair();
                    break;
                }
                else if (opcao == 5)
                {
                    menu.TrocarIdioma();
                    int novaEscolha;
                    while (!int.TryParse(Console.ReadLine(), out novaEscolha) || (novaEscolha != 1 && novaEscolha != 2 && novaEscolha != 3))
                    {
                        Console.WriteLine("Invalid option. Enter 1 for Portuguese, 2 for English or 3 for Spanish:");
                    }
                    if (novaEscolha == 1)
                    {
                        menu = new MenuPt();
                    }
                    else if (novaEscolha == 2)
                    {
                        menu = new MenuEn();
                    }
                    else if (novaEscolha == 3)
                    {
                        menu = new MenuEsp();
                    }
                }
            } while (opcao != 0);
        }    
        else if (escolha == 3)
        {
            IMenu menu = new MenuEsp();
            int opcao;
            do
            {
                menu.ExibirMenu();
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 5)
                {
                    Console.WriteLine("Opción inválida. Ingrese un número entre 0 y 5:");
                }

                if (opcao == 1)
                {
                    menu.Gerenciamento();
                    int opcaoGerenciamento;
                    while (!int.TryParse(Console.ReadLine(), out opcaoGerenciamento) || opcaoGerenciamento < 0 || opcaoGerenciamento > 4)
                    {
                        Console.WriteLine("Opción inválida. Ingrese un número entre 0 y 4:");
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
                        Console.WriteLine("Volver al menú principal...");
                    }
                }
                else if (opcao == 2)
                {
                    menu.Pedidos();
                    int opcaopedidos;
                    while (!int.TryParse(Console.ReadLine(), out opcaopedidos) || opcaopedidos < 0 || opcaopedidos > 3)
                    {
                        Console.WriteLine("Opción inválida. Ingrese un número entre 0 y 3:");
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
                        Console.WriteLine("Volver al menú principal...");
                    }
                }
                else if (opcao == 3)
                {
                    menu.Relatorios();
                    int oprel;
                    while (!int.TryParse(Console.ReadLine(), out oprel) || oprel < 0 || oprel > 4)
                    {
                        Console.WriteLine("Opción inválida. Ingrese un número entre 0 y 4:");
                    }

                    if (oprel == 1)
                    {
                        menu.FiltrarPorPeriodo(pedidos);
                    }
                    else if (oprel == 2)
                    {
                        menu.FiltrarPorCliente(pedidos);
                    }
                    else if (oprel == 3)
                    {
                        menu.FiltrarPorClientePeriodo(pedidos);
                    }
                    else if (oprel == 4)
                    {
                        menu.CalcularConsumoItem(pedidos);
                    }
                    else if (oprel == 0)
                    {
                        Console.WriteLine("Volver al menú principal...");
                    }
                }
                else if (opcao == 4)
                {
                    string conteudojson = JsonSerializer.Serialize(cardapio);
                    File.WriteAllText(caminhoCardapio, conteudojson);

                    conteudojson = JsonSerializer.Serialize(pedidos);
                    File.WriteAllText(caminhoPedidos, conteudojson);

                    conteudojson = JsonSerializer.Serialize(clientes);
                    File.WriteAllText(caminhoClientes, conteudojson);
                    menu.Sair();
                    break;
                }
                else if (opcao == 5)
                {
                    menu.TrocarIdioma();
                    int novaEscolha;
                    while (!int.TryParse(Console.ReadLine(), out novaEscolha) || (novaEscolha != 1 && novaEscolha != 2 && novaEscolha != 3))
                    {
                        Console.WriteLine("Opción inválida. Ingrese 1 para Portugués, 2 para Inglés o 3 para Español:");
                    }
                    if (novaEscolha == 1)
                    {
                        menu = new MenuPt();
                    }
                    else if (novaEscolha == 2)
                    {
                        menu = new MenuEn();
                    }
                    else if (novaEscolha == 3)
                    {
                        menu = new MenuEsp();
                    }
                }
            } while (opcao != 0);
        }
    }
}