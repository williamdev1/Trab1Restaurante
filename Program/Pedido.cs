using System;

namespace Program;

public class Pedido
{
    private static int nextId = 1;

    public int IdPedido { get; set; }
    public Pessoa Cliente { get; set; }
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    public DateTime Horario { get; set; }
    public bool Pago { get; set; }
    public bool Dividido { get; set; }
    public decimal ValorTotal => CalcularTotal();

    public Pedido()
    {
        IdPedido = nextId++;
        Horario = DateTime.Now;
    }

    private decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var item in Itens)
        {
            total += item.Subtotal;
        }
        return total;
    }

    public void AdicionarItem(ItemPedido item, int quantidade)
    {
        var existing = Itens.Find(oi => oi.Codigo == item.Codigo);
        if (existing != null)
        {
            existing.Quantidade += quantidade;
        }
        else
        {
            Itens.Add(new ItemPedido { Codigo = item.Codigo, Categoria = item.Categoria, Oferecido = item.Oferecido, Descricao = item.Descricao, DescricaoEn = item.DescricaoEn, Preco = item.Preco, Quantidade = quantidade });
        }
    }

    public void RemoverItem(int codigo, int quantidade)
    {
        var existing = Itens.Find(oi => oi.Codigo == codigo);
        if (existing != null)
        {
            existing.Quantidade -= quantidade;
            if (existing.Quantidade <= 0)
            {
                Itens.Remove(existing);
            }
        }
    }

    public void MostrarItens(string lang = "pt")
    {
        if (Itens.Count == 0)
        {
            Console.WriteLine(lang == "en" ? "No items in this order." : "Nenhum item no pedido.");
            return;
        }

        foreach (var item in Itens)
        {
            if (lang == "en")
            {
                Console.WriteLine($"Code: {item.Codigo} - {item.DescricaoEn} - Quantity: {item.Quantidade} - Subtotal: {item.Subtotal}");
            }
            else
            {
                Console.WriteLine($"Código: {item.Codigo} - {item.Descricao} - Quantidade: {item.Quantidade} - Subtotal: {item.Subtotal}");
            }
        }
    }

    public void Editar(Cardapio cardapio, int opcao, int cod, int qtd)
    {
        if (Pago)
        {
            throw new InvalidOperationException("Pedido já pago!");
        }

        if (opcao == 1)
        {
            var item = cardapio.Itens.Find(i => i.Codigo == cod && i.Oferecido);
            if (item != null)
            {
                AdicionarItem(item, qtd);
            }
            else
            {
                throw new ArgumentException("Item não encontrado ou não oferecido!");
            }
        }
        else if (opcao == 2)
        {
            RemoverItem(cod, qtd);
        }
    }

    public void Pagar(bool dividirConta, bool confirmar)
    {
        if (ValorTotal <= 0)
        {
            throw new InvalidOperationException("Pedido vazio!");
        }

        Dividido = dividirConta;
        if (confirmar)
        {
            Pago = true;
        }
    }

}
