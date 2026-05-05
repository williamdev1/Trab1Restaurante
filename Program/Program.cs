using System.Reflection.Emit;

namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem vindo ao restaurante! / Welcome to the restaurant!");
        Console.WriteLine("Selecione o idioma / Select the language:");
        Console.WriteLine("1. Português - PT");
        Console.WriteLine("2. English - EN");
        
        int escolha = int.Parse(Console.ReadLine());
        if (escolha == 1)
        {

            MenuPt menuPt = new MenuPt();
            int opcao;
            do{
                menuPt.ExibirMenu();
                opcao = int.Parse(Console.ReadLine());
                if(opcao == 1)
                {
                    menuPt.Gerenciamento();
                    int opcaoGerenciamento = int.Parse(Console.ReadLine());
                    if(opcaoGerenciamento == 1)
                    {
                        ItemPedido itemPedido = new ItemPedido();
                        Cardapio.CadastrarItem();
                    }
                    else if (opcaoGerenciamento == 2)
                    {

                        Cardapio.EditarItem();
                    }
                    else if (opcaoGerenciamento == 3)
                    {
                        Cardapio.DeletarItem();
                    }
                    else if (opcaoGerenciamento == 4)
                    {
                        Cardapio.ListarItem();
                    }
                    else if (opcaoGerenciamento == 0)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                    }
                }
                else if (opcao == 2)
                {
                    menuPt.Pedidos();
                    int opcaopedidos = int.Parse(Console.ReadLine());
                    if (opcaopedidos == 1)
                    {
                        Pedido pedido = new Pedido();
                        pedido.NovoPedido();
                    }
                    else if (opcaopedidos == 2)
                    {
                        Pedido.EditarPedido();
                    }
                    else if (opcaopedidos == 3)
                    {
                        Pedido.PagarPedido();
                    }
                    else if (opcaopedidos == 0)
                    {
                        Console.WriteLine("Voltando ao menu principal...");
                    }
                }
                else if (opcao == 3)
                {
                    menuPt.Relatorios();
                }
                else if (opcao == 0)
                {
                    Console.WriteLine("Até mais!");
                }
            }while(opcao !=0);
        }
        else if (escolha == 2)
        {
            MenuEn menuEn = new MenuEn();
            menuEn.ExibirMenu();
        }
        }
    }


