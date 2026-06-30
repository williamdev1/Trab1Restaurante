using System;

namespace Program;

public class RelatorioPedidosEmTela : Relatorio
{
    public override void RegistrarInformacao(Pedido conteudo)
    {
        Console.WriteLine($"Pedido: {conteudo.IdPedido}");
        Console.WriteLine($"Cliente: {conteudo.Cliente?.Nome ?? "Anônimo"}");
        Console.WriteLine($"Data/Hora: {conteudo.Horario}");
        Console.WriteLine($"Pago: {conteudo.Pago}");
        Console.WriteLine("Itens:");

        foreach (var item in conteudo.Itens)
        {
            Console.WriteLine($"  - {item.DescricaoEm("pt")} (Qtd: {item.Quantidade}, Subtotal: {item.Subtotal})");
        }

        Console.WriteLine($"Valor Total: {conteudo.ValorTotal}");
        Console.WriteLine("-----------------------------------\n");
    }
    public override void RegistrarTitulo(string conteudo)
    {
        Console.WriteLine(conteudo);
    }
}
