using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloProduto;
using ListaDeCompras.ConsoleApp.ModuloLista;

namespace ListaDeCompras.ConsoleApp.ModuloItem;

public class Item
{
    public int Quantidade { get; private set; }

    public Produto Produto { get; private set;}

    public Lista Lista { get; private set;}

    public Item(int quantidade, Produto produto, Lista lista)
    {
        Quantidade = quantidade;
        Produto = produto;
        Lista = lista;
    }

    public string[] Validar()
    {
        string erros = string.Empty;
        
        if (Quantidade <= 0)
            erros += "O campo \"Categoria\" deve ter valor maior que 1;";  
        
        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
