using System;

namespace Program;

public class Relatorio
{
    public List<Pedido> FiltrarPorPeriodo(List<Pedido> pedidos, DateTime inicio, DateTime fim)
    {
        var resultado = new List<Pedido>();
        foreach (var pedido in pedidos)
        {
            if (pedido.Horario >= inicio && pedido.Horario <= fim)
            {
                resultado.Add(pedido);
            }
        }
        return resultado;
    }

    public List<Pedido> FiltrarPorCliente(List<Pedido> pedidos, string nome)
    {
        var resultado = new List<Pedido>();
        foreach (var pedido in pedidos)
        {
            if (pedido.Cliente != null && pedido.Cliente.Nome == nome)
            {
                resultado.Add(pedido);
            }
        }
        return resultado;
    }

    public List<Pedido> FiltrarPorClientePeriodo(List<Pedido> pedidos, string nome, DateTime inicio, DateTime fim)
    {
        var resultado = new List<Pedido>();
        foreach (var pedido in pedidos)
        {
            if (pedido.Cliente != null && pedido.Cliente.Nome == nome && 
                pedido.Horario >= inicio && pedido.Horario <= fim)
            {
                resultado.Add(pedido);
            }
        }
        return resultado;
    }

    public List<(int IdPedido, int Quantidade)> CalcularConsumoItem(List<Pedido> pedidos, int codigoItem, out int total)
    {
        var consumoPorPedido = new List<(int IdPedido, int Quantidade)>();
        total = 0;
        
        foreach (var pedido in pedidos)
        {
            ItemPedido? item = null;
            foreach (var oi in pedido.Itens)
            {
                if (oi.Codigo == codigoItem)
                {
                    item = oi;
                    break;
                }
            }
            
            if (item != null)
            {
                consumoPorPedido.Add((pedido.IdPedido, item.Quantidade));
                total += item.Quantidade;
            }
        }

        return consumoPorPedido;
    }
}
