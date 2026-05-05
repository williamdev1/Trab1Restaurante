using System;

namespace Program;

public class Pedido : Cardapio
{

    public DateTime Horario { get; set; }
    public bool Pago { get; set; }
    public bool Dividido { get; set; }
    public decimal ValorTotal { get; set; }
    public List<Pedido> Pedidos { get; set; }


    public void NovoPedido()
    {
        Horario = DateTime.Now;
        Pago = false;
        ListarItem();
        Console.WriteLine("Digite o código do item que deseja pedir: ");
        int cod = int.Parse(Console.ReadLine());
        foreach (var item in cardapio)
        {
            if (item.Codigo == cod)
            {
                ValorTotal += item.Preco;
                Console.WriteLine($"Item {item.Descricao} adicionado ao pedido. Valor total: {ValorTotal}");
            }
        }
        Pedidos.Add(this);
    }

    public void EditarPedido()
    {
        Console.WriteLine("Digite o código do item que deseja remover do pedido: ");
        int cod = int.Parse(Console.ReadLine());
        foreach (var item in cardapio)
        {
            if (item.Codigo == cod)
            {
                ValorTotal -= item.Preco;
                Console.WriteLine($"Item {item.Descricao} removido do pedido. Valor total: {ValorTotal}");
            }
        }
    }

    public void PagarPedido()
    {
        if (ValorTotal > 0)
        {
            Console.WriteLine($"O valor total do pedido é: {ValorTotal}. Deseja pagar? (true / false)");
            bool resposta = bool.Parse(Console.ReadLine());
            if (resposta)
            {
                Pago = true;
                Console.WriteLine("Pedido pago com sucesso!");
            }
            else
            {
                Console.WriteLine("Pagamento cancelado.");
            }
        }
        else
        {
            Console.WriteLine("O pedido está vazio. Não é possível pagar.");
        }
    }
}
