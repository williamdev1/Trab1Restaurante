using System;

namespace Program;

public class ItemPedido
{   
    public int Codigo { get; set; }
    public string Categoria { get; set; }
    public bool Oferecido { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public string[] CategoriasValidas = 
    {
        "bebida",
        "entrada",
        "principal",
        "sobremesa"

    };

}
