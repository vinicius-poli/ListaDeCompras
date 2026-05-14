using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class RepositorioListaEmArquivo : RepositorioBaseEmArquivo<Lista>, IRepositorio<Lista>
{
    public RepositorioListaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Lista> CarregarRegistros()
    {
        return contexto.Listas;
    }
}
