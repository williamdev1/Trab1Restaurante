using System;

namespace Program;

public class ItemPedido
{   
    public int Codigo { get; set; }
    public Categoria Categoria { get; set; }
    public bool Oferecido { get; set; }
    public string Descricao { get; set; }
    public string DescricaoEn { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    public decimal Subtotal => Preco * Quantidade;
    private static readonly string[] CategoriasValidas = { "entradas", "bebidas", "pratos principais", "sobremesas" };

    public bool EhCategoriaValida()
    {
        foreach (var categoriaValida in CategoriasValidas)
        {
            if (string.Equals(categoriaValida, Categoria.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}
