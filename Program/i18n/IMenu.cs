using System;

namespace Program;

public interface IMenu 
{
    void ExibirMenu();
    void Gerenciamento();
    void Pedidos();
    void Relatorios();
    
    public void CadastrarItem(Cardapio Cardapio);
    public void EditarItem(Cardapio Cardapio);
    public void DeletarItem(Cardapio Cardapio);
    public void ListarItem(Cardapio Cardapio);
    public void ListarItensOferecidos(Cardapio Cardapio);
    public void CadastrarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes);
    public void MostrarPedidos(List<Pedido> pedidos);

    public void EditarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes);
    public void MostrarItens(Cardapio cardapio, Pedido pedido);
    public void PagarPedido(List<Pedido> pedidos);
    public void FiltrarPorPeriodo(Relatorio relatorio, List<Pedido> pedidos);
    public void FiltrarPorCliente(Relatorio relatorio, List<Pedido> pedidos);
    public void FiltrarPorClientePeriodo(Relatorio relatorio, List<Pedido> pedidos);
    public void CalcularConsumoItem(Relatorio relatorio, List<Pedido> pedidos);
}
