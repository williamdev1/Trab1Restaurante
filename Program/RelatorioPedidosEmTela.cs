using System;

namespace Program;

public class RelatrioPedidosEmTela : IRelatorioPedidos
{
    public void RegistrarInformacao(string conteudo)
    {
        Console.WriteLine(conteudo);
    }
    
}
