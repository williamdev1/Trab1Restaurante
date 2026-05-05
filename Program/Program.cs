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
            menuPt.ExibirMenu();
            int opcao = int.Parse(Console.ReadLine());
            if(opcao == 1)
            {
                menuPt.Gerenciamento();
                int opcaoGerenciamento = int.Parse(Console.ReadLine());
                if(opcaoGerenciamento == 1)
                {
                }
                else if (opcaoGerenciamento == 2)
                {
                }
                else if (opcaoGerenciamento == 3)
                {
                }
                else if (opcaoGerenciamento == 4)
                {
                }
            }
            else if (opcao == 2)
            {
                menuPt.Pedidos();
            }
            else if (opcao == 3)
            {
                menuPt.Relatorios();
            }
        }
        else if (escolha == 2)
        {
            MenuEn menuEn = new MenuEn();
            menuEn.ExibirMenu();
        }

    }

}
