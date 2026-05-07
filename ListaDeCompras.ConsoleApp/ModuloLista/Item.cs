using System.Security.Cryptography;
using ListaDeCompras.ConsoleApp.ModuloProduto;


namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class Item
{
    public string Id { get; set; }
    public int Quantidade { get; set; }

    public Produto Produto { get; set;}

    public decimal Preco
    {
        get
        {
            return Produto.PrecoAproximado * Quantidade;
        }
    }

    public Item()
    {
        
    }    

    public Item(int quantidade, Produto produto)
    {
        Id = Convert.ToHexString(RandomNumberGenerator.GetBytes(4)).ToLower().Substring(0, 7);

        Quantidade = quantidade;
        Produto = produto;        
    }
    

    public string[] Validar()
    {
        string erros = string.Empty;
        
        if (Quantidade <= 0)
            erros += "O campo \"Categoria\" deve ter valor maior que 1;";  
        
        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
