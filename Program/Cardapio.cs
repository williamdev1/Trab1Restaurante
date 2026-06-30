using System;

namespace Program;

public class Cardapio
{
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

    public void CadastrarItem(int codigo, Categoria categoria, bool oferecido, Dictionary<string, string> descricao, decimal preco)
    {
        ItemPedido item = new ItemPedido();
        item.Codigo = codigo;
        item.Categoria = categoria;
        item.Oferecido = oferecido;
        item.Descricao = descricao;
        item.Preco = preco;
        Itens.Add(item);
    }

    public bool EditarItem(int codigo, Categoria categoria, bool oferecido, Dictionary<string, string> descricao, decimal preco)
    {
        foreach (var item in Itens)
        {
            if (item.Codigo == codigo)
            {
                item.Categoria = categoria;
                item.Oferecido = oferecido;
                item.Descricao = descricao;
                item.Preco = preco;
                return true;
            }
        }

        return false;
    }

    public bool DeletarItem(int codigo)
    {
        foreach (var item in Itens)
        {
            if (item.Codigo == codigo)
            {
                Itens.Remove(item);
                return true;
            }
        }

        return false;
    }

    // public void ListarItem(string lang = "pt")
    // {
    //     string code;
    //     string categoria;
    //     string oferecido;
    //     string descricao;
    //     string preco;

    //     if (lang == "en")
    //     {
    //         code = "Code";
    //         categoria = "Category";
    //         oferecido = "Offered";
    //         descricao = "Description";
    //         preco = "Price";
    //     }
    //     else
    //     {
    //         code = "Código";
    //         categoria = "Categoria";
    //         oferecido = "Oferecido";
    //         descricao = "Descrição";
    //         preco = "Preço";
    //     }

    //     foreach (var item in Itens.Where(i => i.Oferecido))
    //     {   
    //         string desc;
    //         if (lang == "en")
    //         {
    //             desc = item.DescricaoEn;
    //             code = "Code";
    //         }
    //         else
    //         {
    //             desc = item.Descricao;
    //             code = "Código";
    //         }

    //         Console.WriteLine($"{code}: {item.Codigo} - {desc} - {item.Preco}");
    //     }
    //     }

    // public void ListarItensOferecidos(string lang = "pt")
    // {
    //     foreach (var item in Itens.Where(i => i.Oferecido))
    //     {
    //         string desc;
    //         string code;

    //         if (lang == "en")
    //         {
    //             desc = item.DescricaoEn;
    //             code = "Code";
    //         }
    //         else
    //         {
    //             desc = item.Descricao;
    //             code = "Código";
    //         }

    //         Console.WriteLine($"{code}: {item.Codigo} - {desc} - {item.Preco}");
    //     }
    // }

    // public void InicializarMock()
    // {
    //     Itens.Add(new ItemPedido { Codigo = 1, Categoria = Categoria.Entradas, Oferecido = true, Descricao = "Salada Caesar", DescricaoEn = "Caesar Salad", Preco = 18.50m });
    //     Itens.Add(new ItemPedido { Codigo = 2, Categoria = Categoria.Entradas, Oferecido = true, Descricao = "Bruschetta", DescricaoEn = "Bruschetta", Preco = 15.00m });
    //     Itens.Add(new ItemPedido { Codigo = 3, Categoria = Categoria.Entradas, Oferecido = true, Descricao = "Pão", DescricaoEn = "Bread", Preco = 22.00m });

    //     Itens.Add(new ItemPedido { Codigo = 4, Categoria = Categoria.Bebidas, Oferecido = true, Descricao = "Suco de Laranja", DescricaoEn = "Orange Juice", Preco = 7.00m });
    //     Itens.Add(new ItemPedido { Codigo = 5, Categoria = Categoria.Bebidas, Oferecido = true, Descricao = "Água", DescricaoEn = "Water", Preco = 5.00m });
    //     Itens.Add(new ItemPedido { Codigo = 6, Categoria = Categoria.Bebidas, Oferecido = true, Descricao = "Cerveja", DescricaoEn = "Beer", Preco = 12.00m });

    //     Itens.Add(new ItemPedido { Codigo = 7, Categoria = Categoria.PratosPrincipais, Oferecido = true, Descricao = "Filé de Frango", DescricaoEn = "Chicken Breast", Preco = 28.90m });
    //     Itens.Add(new ItemPedido { Codigo = 8, Categoria = Categoria.PratosPrincipais, Oferecido = true, Descricao = "Bife à Parmegiana", DescricaoEn = "Parmesan Steak", Preco = 35.00m });
    //     Itens.Add(new ItemPedido { Codigo = 9, Categoria = Categoria.PratosPrincipais, Oferecido = true, Descricao = "Salmão", DescricaoEn = "Salmon", Preco = 40.00m });

    //     Itens.Add(new ItemPedido { Codigo = 10, Categoria = Categoria.Sobremesas, Oferecido = true, Descricao = "Pudim", DescricaoEn = "Pudding", Preco = 12.00m });
    //     Itens.Add(new ItemPedido { Codigo = 11, Categoria = Categoria.Sobremesas, Oferecido = true, Descricao = "Torta de Maçã", DescricaoEn = "Apple Pie", Preco = 14.00m });
    //     Itens.Add(new ItemPedido { Codigo = 12, Categoria = Categoria.Sobremesas, Oferecido = true, Descricao = "Mousse de Chocolate", DescricaoEn = "Chocolate Mousse", Preco = 10.00m });
    // }
}
