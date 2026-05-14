using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloProduto;
using ListaDeCompras.ConsoleApp.ModuloLista;

namespace ListaDeCompras.ConsoleApp.Utilidades;

public class TelaPrincipal
{
    private readonly IRepositorio<Categoria> repositorioCategoria;
    private readonly IRepositorio<Produto> repositorioProduto;
    private readonly IRepositorio<Lista> repositorioLista;

    public TelaPrincipal(
        IRepositorio<Categoria> repositorioCategoria, 
        IRepositorio<Produto> repositorioProduto, 
        IRepositorio<Lista> repositorioLista
    )
    {
        this.repositorioCategoria = repositorioCategoria;
        this.repositorioProduto = repositorioProduto;
        this.repositorioLista = repositorioLista;
    }

    public ITelaOpcoes? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar listas de compras");        
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);

        if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto, repositorioCategoria);

        if (opcaoMenuPrincipal == "3")
            return new TelaLista(repositorioLista, repositorioProduto);

        return null;
    }
}