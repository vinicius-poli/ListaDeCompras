using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloItem;

public class RepositorioItem
{   
    protected List<RepositorioItem> itens = new List<RepositorioItem>();

    public void AdicionarNaLista(RepositorioItem item)
    {
        itens.Add(item);
    }
    

}
