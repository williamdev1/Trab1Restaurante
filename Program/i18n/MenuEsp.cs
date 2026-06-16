using System;

namespace Program;

public class MenuEsp : IMenu
{
    public List<ItemPedido> ItensEsp { get; set; } = new List<ItemPedido>();
    public void ExibirMenu()
    {
        Console.WriteLine("¡Bienvenido!");
        Console.WriteLine("1. Gestión");
        Console.WriteLine("2. Pedidos");
        Console.WriteLine("3. Informes");
        Console.WriteLine("4. Salir");
        Console.WriteLine("5. Cambiar idioma");
    }
    public void Gerenciamento()
    {
        Console.WriteLine("1 - Registrar artículo");
        Console.WriteLine("2 - Editar artículo");
        Console.WriteLine("3 - Eliminar artículo");
        Console.WriteLine("4 - Listar artículos");
        Console.WriteLine("0 - Volver");
    }

    public void Pedidos()
    {
        Console.WriteLine("1 - Nuevo pedido");
        Console.WriteLine("2 - Editar pedido");
        Console.WriteLine("3 - Pagar pedido");
        Console.WriteLine("0 - Volver");
    }

    public void Relatorios()
    {
        Console.WriteLine("Seleccione el informe.");
        Console.WriteLine("1 - Por período");
        Console.WriteLine("2 - Por cliente");
        Console.WriteLine("3 - Cliente por período");
        Console.WriteLine("4 - Consumo por artículo");
        Console.WriteLine("0 - Volver");
    }
    public void TrocarIdioma()
    {
        Console.WriteLine("¿Qué idioma desea seleccionar?");
        Console.WriteLine("1. Portugués");
        Console.WriteLine("2. Inglés");
    }
    public void CadastrarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Contraseña: ");
        string senha = Console.ReadLine() ?? string.Empty;
        if (senha != "0000")
        {
            Console.WriteLine("¡Acceso denegado!");
            return;
        }

        Console.WriteLine("¡Acceso concedido!");

        int cod;
        Console.WriteLine("Código: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
        }

        Console.WriteLine("Categoría (Entradas, Bebidas, PlatosPrincipales, Postres): ");
        string catStr = Console.ReadLine() ?? string.Empty;
        Categoria cat;
        while (!Categoria.TryParse(catStr, out cat))
        {
            Console.WriteLine("¡Categoría inválida!");
        }

        bool ofer;
        Console.WriteLine("Ofrecido (True/False): ");
        while (!bool.TryParse(Console.ReadLine(), out ofer))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese True o False:");
        }

        Console.WriteLine("Descripción: ");
        string desc = Console.ReadLine() ?? string.Empty;

        decimal preco;
        Console.WriteLine("Precio: ");
        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese un número decimal válido:");
        }
        
        try
        {
            Cardapio.CadastrarItem(cod, cat, ofer, desc, "", preco);
            Console.WriteLine("¡Artículo registrado con éxito!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }
    public void EditarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Contraseña: ");
        string senha = Console.ReadLine() ?? string.Empty;
        if (senha != "0000")
        {
            Console.WriteLine("¡Acceso denegado!");
            return;
        }

        Console.WriteLine("¡Acceso concedido!");

        int cod;
        Console.WriteLine("Código del artículo a editar: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
        }

        Console.WriteLine("Nueva categoría (Entradas, Bebidas, PlatosPrincipales, Postres): ");
        string catStr = Console.ReadLine() ?? string.Empty;
        Categoria cat;
        while (!Categoria.TryParse(catStr, out cat))
        {
            Console.WriteLine("¡Categoría inválida!");
        }

        bool ofer;
        Console.WriteLine("Nuevo estado de oferta (True/False): ");
        while (!bool.TryParse(Console.ReadLine(), out ofer))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese True o False:");
        }

        Console.WriteLine("Nueva descripción: ");
        string desc = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Nueva descripción en inglés: ");
        string descEn = Console.ReadLine() ?? string.Empty;

        decimal preco;
        Console.WriteLine("Nuevo precio: ");
        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese un número decimal válido:");
        }

        if (Cardapio.EditarItem(cod, cat, ofer, desc, descEn, preco))
        {
            Console.WriteLine("¡Artículo editado con éxito!");
        }
        else
        {
            Console.WriteLine("¡Artículo no encontrado!");
        }
    }
    public void DeletarItem(Cardapio Cardapio)
    {
        Console.WriteLine("Contraseña: ");
            string senha = Console.ReadLine() ?? string.Empty;
            if (senha != "0000")
            {
                Console.WriteLine("¡Acceso denegado!");
                return;
            }

            Console.WriteLine("¡Acceso concedido!");

            int cod;
            Console.WriteLine("Código del artículo a eliminar: ");
            while (!int.TryParse(Console.ReadLine(), out cod))
            {
                Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
            }

            if (Cardapio.DeletarItem(cod))
            {
                Console.WriteLine("¡Artículo eliminado con éxito!");
            }
            else
            {
                Console.WriteLine("¡Artículo no encontrado!");
            }
    }
    public void ListarItem(Cardapio Cardapio)
    {
        
        foreach (var item in Cardapio.Itens)
        {   
            Console.WriteLine($"Código: {item.Codigo} - Descripción: {item.Descricao} - Precio: {item.Preco}");
        }
    }
    public void ListarItensOferecidos(Cardapio Cardapio)
    {
        foreach (var item in Cardapio.Itens.Where(i => i.Oferecido))
        {
            Console.WriteLine($"Código: {item.Codigo} - Descripción: {item.Descricao} - Precio: {item.Preco}");
        }
    }

    public void CadastrarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes)
    {
        Pedido pedido = new Pedido();
        pedidos.Add(pedido);
        ListarItensOferecidos(cardapio);

        int cod;
        Console.WriteLine("Código: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
        }

        var item = cardapio.Itens.Find(i => i.Codigo == cod && i.Oferecido);
        if (item != null)
        {
            int qtd;
            Console.WriteLine("Cantidad: ");
            while (!int.TryParse(Console.ReadLine(), out qtd))
            {
                Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
            }

            pedido.AdicionarItem(item, qtd);
            Console.WriteLine("¡Artículo agregado!");
        }
        else
        {
            Console.WriteLine("¡Artículo no encontrado!");
        }

        bool registrado;
        Console.WriteLine("¿Cliente registrado? (True/False)");
        while (!bool.TryParse(Console.ReadLine(), out registrado))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese True o False:");
        }

        if (registrado)
        {
            Console.WriteLine("Nombre del cliente: ");
            string nomeCliente = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Correo electrónico del cliente: ");
            string emailCliente = Console.ReadLine() ?? string.Empty;
            foreach (var cliente in clientes)
            {
                if (cliente.Nome == nomeCliente && cliente.Email == emailCliente)
                {
                    pedido.Cliente = cliente;
                    Console.WriteLine("¡Cliente vinculado al pedido!");
                    break;
                }
            }
        }
    }
    public void MostrarPedidos(List<Pedido> pedidos)
    {
        if (pedidos.Count == 0)
        {
            Console.WriteLine("No se han creado pedidos aún.");
        }
        foreach (var pedido in pedidos)
        {
            Console.WriteLine($"ID: {pedido.IdPedido}, Cliente: {pedido.Cliente?.Nome ?? "Anónimo"}, Total: {pedido.ValorTotal}, Pagado: {pedido.Pago}");
        }
    }

    public void EditarPedido(List<Pedido> pedidos, Cardapio cardapio, List<Pessoa> clientes)
    {
        MostrarPedidos(pedidos);
        int id;
        Console.WriteLine("ID del pedido: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
        }

        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
        if (pedido != null)
        {
            MostrarItens(cardapio, pedido);
            Console.WriteLine("1. Agregar artículo");
            Console.WriteLine("2. Eliminar artículo");
            int op;
            while (!int.TryParse(Console.ReadLine(), out op) || (op != 1 && op != 2))
            {
                Console.WriteLine("Opción inválida. Por favor ingrese 1 o 2:");
            }
            if (op == 1)
            {
                ListarItensOferecidos(cardapio);
                int cod;
                Console.WriteLine("Código: ");
                while (!int.TryParse(Console.ReadLine(), out cod))
                {
                    Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
                }
                
                int qtd;
                Console.WriteLine("Cantidad: ");
                while (!int.TryParse(Console.ReadLine(), out qtd))
                {
                    Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
                }

                try
                {
                    pedido.Editar(cardapio, op, cod, qtd);
                    Console.WriteLine("¡Operación completada!");
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
                Console.WriteLine("Código: ");
                while (!int.TryParse(Console.ReadLine(), out cod))
                {
                    Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
                }
                
                int qtd;
                Console.WriteLine("Cantidad: ");
                while (!int.TryParse(Console.ReadLine(), out qtd))
                {
                    Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
                }

                try
                {
                    pedido.Editar(cardapio, op, cod, qtd);
                    Console.WriteLine("¡Operación completada!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        else
        {
            Console.WriteLine("¡Pedido no encontrado!");
        }
    }
    public void MostrarItens(Cardapio Cardapio, Pedido pedido)
    {
        if (Cardapio.Itens.Count == 0)
        {
            Console.WriteLine("No hay artículos en el pedido.");
            return;
        }

        foreach (var item in Cardapio.Itens)
        {
            Console.WriteLine($"Código: {item.Codigo} - {item.Descricao} - Cantidad: {item.Quantidade} - Subtotal: {item.Subtotal}");
        }
    }

    public void PagarPedido(List<Pedido> pedidos)
    {
        MostrarPedidos(pedidos);
        int id;
        Console.WriteLine("ID del pedido: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Valor inválido. Por favor ingrese un número válido:");
        }

        Pedido pedido = pedidos.Find(p => p.IdPedido == id);
        if (pedido != null)
        {
            Console.WriteLine($"Valor total: {pedido.ValorTotal}");

            bool dividir;
            Console.WriteLine("¿Dividir la cuenta? (True/False)");
            while (!bool.TryParse(Console.ReadLine(), out dividir))
            {
                Console.WriteLine("Valor inválido. Por favor ingrese True o False:");
            }

            bool confirmar;
            Console.WriteLine("¿Confirmar el pago? (True/False)");
            while (!bool.TryParse(Console.ReadLine(), out confirmar))
            {
                Console.WriteLine("Valor inválido. Por favor ingrese True o False:");
            }

            try
            {
                pedido.Pagar(dividir, confirmar);
                if (confirmar)
                {
                    Console.WriteLine("¡Pedido pagado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("¡Pedido no encontrado!");
        }
    }
    public void FiltrarPorPeriodo(Relatorio relatorio, List<Pedido> pedidos)
    {
        DateTime inicio;
        Console.WriteLine("Fecha de inicio (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
        {
            Console.WriteLine("Fecha inválida. Ingrese una fecha válida:");
        }

        DateTime fim;
        Console.WriteLine("Fecha de fin (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out fim))
        {
            Console.WriteLine("Fecha inválida. Ingrese una fecha válida:");
        }

        var pedidosFiltrados = relatorio.FiltrarPorPeriodo(pedidos, inicio, fim);
        Console.WriteLine($"Pedidos en el período {inicio} a {fim}:");
        foreach (var p in pedidosFiltrados)
        {
            Console.WriteLine($"ID: {p.IdPedido}, Cliente: {p.Cliente?.Nome ?? "Anónimo"}, Total: {p.ValorTotal}, Pagado: {p.Pago}");
        }
    }

    public void FiltrarPorCliente(Relatorio relatorio, List<Pedido> pedidos)
    {
        Console.WriteLine("Nombre del cliente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        var pedidosFiltrados = relatorio.FiltrarPorCliente(pedidos, nome);
        Console.WriteLine($"Pedidos para el cliente {nome}:");
        foreach (var p in pedidosFiltrados)
        {
            Console.WriteLine($"ID: {p.IdPedido}, Cliente: {p.Cliente?.Nome ?? "Anónimo"}, Total: {p.ValorTotal}, Pagado: {p.Pago}");
        }
    }

    public void FiltrarPorClientePeriodo(Relatorio relatorio, List<Pedido> pedidos)
    {
        Console.WriteLine("Nombre del cliente: ");
        string nome = Console.ReadLine() ?? string.Empty;

        DateTime inicio;
        Console.WriteLine("Fecha de inicio (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out inicio))
        {
            Console.WriteLine("Fecha inválida. Ingrese una fecha válida (yyyy-MM-dd):");
        }

        DateTime fim;
        Console.WriteLine("Fecha de fin (yyyy-MM-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out fim))
        {
            Console.WriteLine("Fecha inválida. Ingrese una fecha válida (yyyy-MM-dd):");
        }

        var pedidosFiltrados = relatorio.FiltrarPorClientePeriodo(pedidos, nome, inicio, fim);
        Console.WriteLine($"Pedidos para el cliente {nome} en el período {inicio} a {fim}:");
        foreach (var p in pedidosFiltrados)
        {
            Console.WriteLine($"ID: {p.IdPedido}, Cliente: {p.Cliente?.Nome ?? "Anónimo"}, Total: {p.ValorTotal}, Pagado: {p.Pago}");
        }
    }

    public void CalcularConsumoItem(Relatorio relatorio, List<Pedido> pedidos)
    {
        int cod;
        Console.WriteLine("Código: ");
        while (!int.TryParse(Console.ReadLine(), out cod))
        {
            Console.WriteLine("Valor inválido. Ingrese un número válido:");
        }

        int total;
        var consumo = relatorio.CalcularConsumoItem(pedidos, cod, out total);
        Console.WriteLine($"Consumo del artículo {cod}:");
        foreach (var c in consumo)
        {
            Console.WriteLine($"ID Pedido: {c.IdPedido}, Cantidad: {c.Quantidade}");
        }
        Console.WriteLine($"Total consumido: {total}");
    }
    
}
