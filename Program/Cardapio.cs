using System;

namespace Program;

public class Cardapio
{
    public static List<ItemPedido> cardapio = new List<ItemPedido>();

    public static void CadastrarItem()
    {
        Console.WriteLine("Qual a senha de acesso?");
        ItemPedido item = new ItemPedido();
        int senha = int.Parse(Console.ReadLine());
        if (senha == 0000)
        {
            Console.WriteLine("Acesso permitido!");

            Console.WriteLine("Código: ");
            int cod = int.Parse(Console.ReadLine());
            item.Codigo = cod;
            
            Console.WriteLine("Categoria: ");
            string cat = Console.ReadLine();
            item.Categoria = cat;
            
            Console.WriteLine("Oferecido (true/false): ");
            bool ofer = bool.Parse(Console.ReadLine());
            item.Oferecido = ofer;
            
            Console.WriteLine("Descrição: ");
            string des = Console.ReadLine();
            item.Descricao = des;
            
            Console.WriteLine("Preço: ");
            decimal pre = decimal.Parse(Console.ReadLine());
            item.Preco = pre;

            cardapio.Add(item);
            Console.WriteLine("Item cadastrado com sucesso!");

        }
        else
        {
            Console.WriteLine("Acesso negado!");
            return;
        }
    }

    public static void EditarItem()
    {
        Console.WriteLine("Qual a senha de acesso?");
        int senha = int.Parse(Console.ReadLine());
        if (senha == 0000)
        {
            Console.WriteLine("Acesso permitido!");

            Console.WriteLine("Codigo: ");
            int cod = int.Parse(Console.ReadLine());
            for (int i = 0; i < cardapio.Count; i++)
            {
                if (cardapio[i].Codigo == cod)
                {
                    Console.WriteLine("Categoria: ");
                    string cat = Console.ReadLine();
                    cardapio[i].Categoria = cat;
            
                    Console.WriteLine("Oferecido (true/false): ");
                    bool ofer = bool.Parse(Console.ReadLine());
                    cardapio[i].Oferecido = ofer;
            
                    Console.WriteLine("Descrição: ");
                    string des = Console.ReadLine();
                    cardapio[i].Descricao = des;
            
                    Console.WriteLine("Preço: ");
                    decimal pre = decimal.Parse(Console.ReadLine());
                    cardapio[i].Preco = pre;

                    Console.WriteLine("Item editado com sucesso!");
                }
        }
        }
        else
        {
            Console.WriteLine("Acesso negado!");
            return;
        }
    }

    public static void DeletarItem()
    {   
        Console.WriteLine("Qual a senha de acesso?");
        int senha = int.Parse(Console.ReadLine());
        if (senha == 0000)
        {
            Console.WriteLine("Acesso permitido!");

            Console.WriteLine("Codigo: ");
            int cod = int.Parse(Console.ReadLine());
            for (int i = 0; i < cardapio.Count; i++)
            {
                if(cardapio[i].Codigo == cod)
                {
                    cardapio.Remove(cardapio[i]);
                    Console.WriteLine("Item deletado com sucesso!");
                }
            }
        }
        else
        {
            Console.WriteLine("Acesso negado!");
            return;
        }
    }
    
    public static void ListarItem()
    {
        foreach (var item in cardapio)
        {
            Console.WriteLine($"Código: {item.Codigo}");
            Console.WriteLine($"Categoria: {item.Categoria}");
            Console.WriteLine($"Oferecido: {item.Oferecido}");
            Console.WriteLine($"Descrição: {item.Descricao}");
            Console.WriteLine($"Preço: {item.Preco}");
        }
    }
}
