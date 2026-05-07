using System;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class RepositorioListaEmArquivo : RepositorioBaseEmArquivo<Lista>
{
    public RepositorioListaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Lista> CarregarRegistros()
    {
        return contexto.Listas;
    }
}
