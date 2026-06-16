using System;

namespace Program;

public class MenuPt : IMenu
{
    public void ExibirMenu()
    {
        Console.WriteLine("Menu Principal");
        Console.WriteLine("1. Gerenciamento");
        Console.WriteLine("2. Pedidos");
        Console.WriteLine("3. Relatórios");
        Console.WriteLine("4. Sair");
        Console.WriteLine("5. Trocar idioma");
    }
    public void Gerenciamento()
    {
        Console.WriteLine("1 - Cadastrar Item"); 
        Console.WriteLine("2 - Editar Item");
        Console.WriteLine("3 - Deletar Item"); 
        Console.WriteLine("4 - Listar Itens");
        Console.WriteLine("0 - Voltar");
    }
    public void Pedidos()
    {
        Console.WriteLine("1 - Novo Pedido");
        Console.WriteLine("2 - Editar Pedido");
        Console.WriteLine("3 - Pagar Pedido");
        Console.WriteLine("0 - Voltar");
    }
    public void Relatorios()
    {
        Console.WriteLine("Selecione o Relatório.");
        Console.WriteLine("1 - Por Período");
        Console.WriteLine("2 - Por Cliente");
        Console.WriteLine("3 - Cliente em Período");
        Console.WriteLine("4 - Consumo por Item");
        Console.WriteLine("0 - Voltar");
    }
    public void TrocarIdioma()
    {
        Console.WriteLine("Qual idioma você deseja selecionar?");
        Console.WriteLine("1. Inglês");
        Console.WriteLine("2. Espanhol");
    }
    
    public void CadastrarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Senha de acesso: ");
        string senha = Console.ReadLine() ?? string.Empty;
        if (senha != "0000")
        {
            Console.WriteLine("Acesso negado!");
            return;
        }

        Console.WriteLine("Acesso permitido!");

        int cod;
        Console.WriteLine("Código: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Digite um número válido:");
        }

        Console.WriteLine("Categoria (Entradas, Bebidas, PratosPrincipais, Sobremesas): ");
        string catStr = Console.ReadLine() ?? string.Empty;
        Categoria cat;
        while (!Categoria.TryParse(catStr, out cat))
        {
            Console.WriteLine("Categoria inválida!");
        }

        bool ofer;
        Console.WriteLine("Oferecido (True/False): ");
        while (!bool.TryParse(Console.ReadLine(), out ofer))
        {
            Console.WriteLine("Valor inválido. Digite True ou False:");
        }

        Console.WriteLine("Descrição: ");
        string desc = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Descrição em inglês: ");
        string descEn = Console.ReadLine() ?? string.Empty;

        decimal preco;
        Console.WriteLine("Preço: ");
        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Valor inválido. Digite um número decimal válido:");
        }
        
        try
        {
            Cardapio.CadastrarItem(cod, cat, ofer, desc, descEn, preco);
            Console.WriteLine("Item cadastrado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }

    public void EditarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Senha de acesso: ");
        string senha = Console.ReadLine() ?? string.Empty;
        if (senha != "0000")
        {
            Console.WriteLine("Acesso negado!");
            return;
        }

        Console.WriteLine("Acesso permitido!");

        int cod;
        Console.WriteLine("Código do item a ser editado: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Digite um número válido:");
        }

        Console.WriteLine("Nova categoria (Entradas, Bebidas, PratosPrincipais, Sobremesas): ");
        string catStr = Console.ReadLine() ?? string.Empty;
        Categoria cat;
        while (!Categoria.TryParse(catStr, out cat))
        {
            Console.WriteLine("Categoria inválida!");
        }

        bool ofer;
        Console.WriteLine("Novo status de oferecimento (True/False): ");
        while (!bool.TryParse(Console.ReadLine(), out ofer))
        {
            Console.WriteLine("Valor inválido. Digite True ou False:");
        }

        Console.WriteLine("Nova descrição: ");
        string desc = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Nova descrição em inglês: ");
        string descEn = Console.ReadLine() ?? string.Empty;

        decimal preco;
        Console.WriteLine("Novo preço: ");
        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Valor inválido. Digite um número decimal válido:");
        }

        if (Cardapio.EditarItem(cod, cat, ofer, desc, descEn, preco))
        {
            Console.WriteLine("Item editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Item não encontrado!");
        }
    }

    public void DeletarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Senha de acesso: ");
            string senha = Console.ReadLine() ?? string.Empty;
            if (senha != "0000")
            {
                Console.WriteLine("Acesso negado!");
                return;
            }

            Console.WriteLine("Acesso permitido!");

            int cod;
            Console.WriteLine("Código do item a ser deletado: ");
            while (!int.TryParse(Console.ReadLine(), out cod))
            {
                Console.WriteLine("Valor inválido. Digite um número válido:");
            }

            if (Cardapio.DeletarItem(cod))
            {
                Console.WriteLine("Item deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Item não encontrado!");
            }
    }

    public void ListarItem(Cardapio Cardapio)
    {
        
        foreach (var item in Cardapio.Itens)
        {   
            Console.WriteLine($"Código: {item.Codigo} - Descrição: {item.Descricao} - Preço: {item.Preco}");
        }
    }

    public void ListarItensOferecidos(Cardapio Cardapio)
    {
        foreach (var item in Cardapio.Itens.Where(i => i.Oferecido))
        {
            Console.WriteLine($"Código: {item.Codigo} - Descrição: {item.Descricao} - Preço: {item.Preco}");
        }
    }
    
    public void CadastrarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes)
    {
        Pedido pedido = new Pedido();
        pedidos.Add(pedido);
        ListarItensOferecidos(cardapio);

        int cod;
        Console.WriteLine("Código do item: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Digite um número válido:");
        }

        var item = cardapio.Itens.Find(i => i.Codigo == cod && i.Oferecido);
        if (item != null)
        {
            int qtd;
            Console.WriteLine("Quantidade: ");
            while (!int.TryParse(Console.ReadLine(), out qtd))
            {
                Console.WriteLine("Valor inválido. Digite um número válido:");
            }

            pedido.AdicionarItem(item, qtd);
            Console.WriteLine("Item adicionado!");
        }
        else
        {
            Console.WriteLine("Item não encontrado!");
        }

        bool registrado;
        Console.WriteLine("Cliente registrado? (True/False)");
        while (!bool.TryParse(Console.ReadLine(), out registrado))
        {
            Console.WriteLine("Valor inválido. Digite True ou False:");
        }

        if (registrado)
        {
            Console.WriteLine("Nome do cliente: ");
            string nomeCliente = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Email do cliente: ");
            string emailCliente = Console.ReadLine() ?? string.Empty;
            foreach (var cliente in clientes)
            {
                if (cliente.Nome == nomeCliente && cliente.Email == emailCliente)
                {
                    pedido.Cliente = cliente;
                    Console.WriteLine("Cliente já registrado. Vinculado ao pedido!");
                    break;
                }
            }
        }
    }

    public void MostrarPedidos(List<Pedido> pedidos)
    {
        if (pedidos.Count == 0)
        {
            Console.WriteLine("Nenhum pedido foi criado ainda.");
        }
        foreach (var pedido in pedidos)
        {
            Console.WriteLine($"ID: {pedido.IdPedido}, Cliente: {pedido.Cliente?.Nome ?? "Anônimo"}, Total: {pedido.ValorTotal}, Pago: {pedido.Pago}");
        }
    }

    public void EditarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes)
    {
        MostrarPedidos(pedidos);
        int id;
        Console.WriteLine("ID do pedido: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Valor inválido. Digite um número válido:");
        }

        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
        if (pedido != null)
        {
            MostrarItens(cardapio, pedido);
            Console.WriteLine("1. Adicionar item");
            Console.WriteLine("2. Remover item");
            int op;
            while (!int.TryParse(Console.ReadLine(), out op) || (op != 1 && op != 2))
            {
                Console.WriteLine("Opção inválida. Digite 1 ou 2:");
            }
            if (op == 1)
            {
                ListarItensOferecidos(cardapio);
                int cod;
                Console.WriteLine("Código do item: ");
                while (!int.TryParse(Console.ReadLine(), out cod))
                {
                    Console.WriteLine("Valor inválido. Digite um número válido:");
                }
                
                int qtd;
                Console.WriteLine("Quantidade: ");
                while (!int.TryParse(Console.ReadLine(), out qtd))
                {
                    Console.WriteLine("Valor inválido. Digite um número válido:");
                }

                try
                {
                    pedido.Editar(cardapio, op, cod, qtd);
                    Console.WriteLine("Operação realizada!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (op == 2)
            {
                MostrarItens(cardapio, pedido);
                int cod;
                Console.WriteLine("Código do item: ");
                while (!int.TryParse(Console.ReadLine(), out cod))
                {
                    Console.WriteLine("Valor inválido. Digite um número válido:");
                }
                
                int qtd;
                Console.WriteLine("Quantidade: ");
                while (!int.TryParse(Console.ReadLine(), out qtd))
                {
                    Console.WriteLine("Valor inválido. Digite um número válido:");
                }

                try
                {
                    pedido.Editar(cardapio, op, cod, qtd);
                    Console.WriteLine("Operação realizada!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        else
        {
            Console.WriteLine("Pedido não encontrado!");
        }
    }

    public void MostrarItens(Cardapio Cardapio, Pedido pedido)
    {
        if (Cardapio.Itens.Count == 0)
        {
            Console.WriteLine("Nenhum item no pedido.");
            return;
        }

        foreach (var item in Cardapio.Itens)
        {
            Console.WriteLine($"Código: {item.Codigo} - {item.Descricao} - Quantidade: {item.Quantidade} - Subtotal: {item.Subtotal}");
        }
    }

    public void PagarPedido(List<Pedido> pedidos)
    {
        MostrarPedidos(pedidos);
        int id;
        Console.WriteLine("ID do pedido: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Valor inválido. Digite um número válido:");
        }

        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
        if (pedido != null)
        {
            Console.WriteLine($"Valor total: {pedido.ValorTotal}");

            bool dividir;
            Console.WriteLine("Dividir conta? (True/False)");
            while (!bool.TryParse(Console.ReadLine(), out dividir))
            {
                Console.WriteLine("Valor inválido. Digite True ou False:");
            }

            bool confirmar;
            Console.WriteLine("Confirmar pagamento? (True/False)");
            while (!bool.TryParse(Console.ReadLine(), out confirmar))
            {
                Console.WriteLine("Valor inválido. Digite True ou False:");
            }

            try
            {
                pedido.Pagar(dividir, confirmar);
                if (confirmar)
                {
                    Console.WriteLine("Pedido pago!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Pedido não encontrado!");
        }
    }
    public void FiltrarPorPeriodo(Relatorio relatorio, List<Pedido> pedidos)
    {
        DateTime inicio;
        Console.WriteLine("Data início (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
        {
            Console.WriteLine("Data inválida. Digite uma data válida:");
        }

        DateTime fim;
        Console.WriteLine("Data fim (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out fim))
        {
            Console.WriteLine("Data inválida. Digite uma data válida:");
        }

        var pedidosFiltrados = relatorio.FiltrarPorPeriodo(pedidos, inicio, fim);
        Console.WriteLine($"Pedidos no período {inicio} a {fim}:");
        foreach (var p in pedidosFiltrados)
        {
            Console.WriteLine($"ID: {p.IdPedido}, Cliente: {p.Cliente?.Nome ?? "Anônimo"}, Total: {p.ValorTotal}, Pago: {p.Pago}");
        }
    }

    public void FiltrarPorCliente(Relatorio relatorio, List<Pedido> pedidos)
    {
        Console.WriteLine("Nome do cliente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        var pedidosFiltrados = relatorio.FiltrarPorCliente(pedidos, nome);
        Console.WriteLine($"Pedidos do cliente {nome}:");
        foreach (var p in pedidosFiltrados)
        {
            Console.WriteLine($"ID: {p.IdPedido}, Cliente: {p.Cliente?.Nome ?? "Anônimo"}, Total: {p.ValorTotal}, Pago: {p.Pago}");
        }
    }

    public void FiltrarPorClientePeriodo(Relatorio relatorio, List<Pedido> pedidos)
    {
        Console.WriteLine("Nome do cliente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        DateTime inicio;
        Console.WriteLine("Data início (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
        {
            Console.WriteLine("Data inválida. Digite uma data válida:");
        }

        DateTime fim;
        Console.WriteLine("Data fim (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out fim))
        {
            Console.WriteLine("Data inválida. Digite uma data válida:");
        }

        var pedidosFiltrados = relatorio.FiltrarPorClientePeriodo(pedidos, nome, inicio, fim);
        Console.WriteLine($"Pedidos do cliente {nome} no período {inicio} a {fim}:");
        foreach (var p in pedidosFiltrados)
        {
            Console.WriteLine($"ID: {p.IdPedido}, Cliente: {p.Cliente?.Nome ?? "Anônimo"}, Total: {p.ValorTotal}, Pago: {p.Pago}");
        }
    }

    public void CalcularConsumoItem(Relatorio relatorio, List<Pedido> pedidos)
    {
        int cod;
        Console.WriteLine("Código do item: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Digite um número válido:");
        }

        int total;
        var consumo = relatorio.CalcularConsumoItem(pedidos, cod, out total);
        Console.WriteLine($"Consumo do item {cod}:");
        foreach (var c in consumo)
        {
            Console.WriteLine($"ID Pedido: {c.IdPedido}, Quantidade: {c.Quantidade}");
        }
        Console.WriteLine($"Total consumido: {total}");
    }
}