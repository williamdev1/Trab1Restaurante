using System;

namespace Program;

public class ItemPedido
{   
    public int Codigo { get; set; }
    public Categoria Categoria { get; set; }
    public bool Oferecido { get; set; }
    public Dictionary<string, string> Descricao { get; set; }
    //public string DescricaoEn { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    public decimal Subtotal => Preco * Quantidade;
    public string DescricaoEm(string idioma)
    {
        if (Descricao.ContainsKey(idioma))
        {
            return Descricao[idioma];
        }
        else
        {
            return Descricao["pt"];
        }
    }
}
