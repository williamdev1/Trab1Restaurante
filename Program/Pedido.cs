using System;
//using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Program;



public class Pedido
{
    //private static int nextId = 1;

    public int IdPedido { get; set; }
    public Pessoa? Cliente { get; set; }
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    public DateTime Horario { get; set; }
    public bool Pago { get; set; }
    public bool Dividido { get; set; }
    public decimal ValorTotal => CalcularTotal();

    [JsonConstructor]
    public Pedido()
    {
        Itens = new List<ItemPedido>();
        Horario = DateTime.Now;
    }

    public Pedido(List<Pedido> pedidos)
    {
        Pedido pedidoaux = pedidos[pedidos.Count - 1];
        IdPedido = pedidoaux.IdPedido + 1;
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
            Itens.Add(new ItemPedido { Codigo = item.Codigo, Categoria = item.Categoria, Oferecido = item.Oferecido, Descricao = item.Descricao, Preco = item.Preco, Quantidade = quantidade });
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
    public void Editar(Cardapio cardapio, int opcao, int cod, int qtd)
    {
        if (Pago)
        {
            return;
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
                return;
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
            return;
        }

        Dividido = dividirConta;
        if (confirmar)
        {
            Pago = true;
        }
    }

}
