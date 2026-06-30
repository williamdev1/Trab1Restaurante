using System;
using System.Runtime.InteropServices.Marshalling;

namespace Program;

public abstract class Relatorio
{   
    public abstract void RegistrarInformacao(Pedido conteudo);
    public abstract void RegistrarTitulo(string conteudo);

    public void FiltrarPorPeriodo(List<Pedido> pedidos, DateTime inicio, DateTime fim)
    {
        RegistrarTitulo("===RELATÓRIO DE PEDIDOS POR PERÍODO===");
        foreach (var pedido in pedidos)
        {
            if (pedido.Horario >= inicio && pedido.Horario <= fim)
            {
                RegistrarInformacao(pedido);
            }
        }
        
    }

    public void FiltrarPorCliente(List<Pedido> pedidos, string nome)
    {
        RegistrarTitulo("===RELATÓRIO DE PEDIDOS POR CLIENTE===");
        foreach (var pedido in pedidos)
        {
            if (pedido.Cliente != null && pedido.Cliente.Nome == nome)
            {
                RegistrarInformacao(pedido);
            }
        }
    }

    public void FiltrarPorClientePeriodo(List<Pedido> pedidos, string nome, DateTime inicio, DateTime fim)
    {
        RegistrarTitulo("===RELATÓRIO DE PEDIDOS POR CLIENTE E PERÍODO===");
        foreach (var pedido in pedidos)
        {
            if (pedido.Cliente != null && pedido.Cliente.Nome == nome && 
                pedido.Horario >= inicio && pedido.Horario <= fim)
            {
                RegistrarInformacao(pedido);
            }
        }
    }

    public void CalcularConsumoItem(List<Pedido> pedidos, int codigoItem, out int total)
    {
        total = 0;
        foreach (var pedido in pedidos)
        {
            ItemPedido item = null;
            foreach (var i in pedido.Itens)
            {
                if (i.Codigo == codigoItem)
                {
                    item = i;
                    break;
                }
            }
            RegistrarTitulo("===RELATÓRIO DE CONSUMO DE ITEM===");
            if (item != null)
            {
                RegistrarInformacao(pedido);
                total += item.Quantidade;
            }
        }
    }
}
