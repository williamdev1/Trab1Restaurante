using System;

namespace Program;

public class RelatorioPedidosParaArquivo : Relatorio
{
    public override void RegistrarInformacao(Pedido conteudo)
    {
        File.AppendAllText("relatorio.txt", $"Pedido: {conteudo.IdPedido}\n");
        File.AppendAllText("relatorio.txt", $"Cliente: {conteudo.Cliente?.Nome ?? "Anônimo"}\n");
        File.AppendAllText("relatorio.txt", $"Data/Hora: {conteudo.Horario}\n");
        File.AppendAllText("relatorio.txt", $"Pago: {conteudo.Pago}\n");
        File.AppendAllText("relatorio.txt", "Itens:\n");

        foreach (var item in conteudo.Itens)
        {
            File.AppendAllText("relatorio.txt", $"  - {item.DescricaoEm("pt")} (Qtd: {item.Quantidade}, Subtotal: {item.Subtotal})\n");
        }

        File.AppendAllText("relatorio.txt", $"Valor Total: {conteudo.ValorTotal}\n");
        File.AppendAllText("relatorio.txt", "--------------------------------\n");
    }
    
    public override void RegistrarTitulo(string conteudo)
    {
        File.AppendAllText("relatorio.txt", $"{conteudo}\n");
    }
}
