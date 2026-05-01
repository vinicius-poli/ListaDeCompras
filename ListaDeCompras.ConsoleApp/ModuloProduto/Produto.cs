using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }
    public string UnidadeMedida { get; private set; }
    public string PrecoAproximado { get; private set; }

    public Produto(string nome, Categoria categoria, string unidadeMedida, string precoAproximado)
    {
        Nome = nome;
        Categoria = categoria;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length == 0 || Nome.Length > 50)
            erros += "O campo \"Nome\" deve conter entre 0 e 50 caracteres;";

        if (Categoria == null)
            erros += "O campo \"Categoria\" deve conter uma caixa válida;";

        if (string.IsNullOrWhiteSpace(UnidadeMedida))
            erros += "O campo \"Unidade de Medida\" deve ser preenchido;";

        if (string.IsNullOrWhiteSpace(PrecoAproximado))
            erros += "O campo \"Preco Aproximado\" deve ser preenchido;";        

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
    
    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        PrecoAproximado = produtoAtualizado.PrecoAproximado;
    }
}
