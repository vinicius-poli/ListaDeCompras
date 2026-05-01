using System;
using ListaDeCompras.ConsoleApp.ModuloLista;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloItem;

public class TelaItem
{
    private RepositorioProduto repositorioProduto;
    private RepositorioLista repositorioLista;


    protected TelaItem(RepositorioItem repositorioItem, RepositorioProduto repositorioProduto, RepositorioLista repositorioLista)
    {        
        this.repositorioProduto = repositorioProduto;
        this.repositorioLista = repositorioLista;
    }
}
