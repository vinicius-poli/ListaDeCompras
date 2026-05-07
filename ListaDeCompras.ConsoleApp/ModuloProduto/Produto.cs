using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public string UnidadeMedida { get; set; }
    public decimal PrecoAproximado { get; set; }

    public Produto()
    {
        
    }

    public Produto(string nome, Categoria categoria, string unidadeMedida, decimal precoAproximado)
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
            erros += "O campo \"Categoria\" deve conter uma categoria válida;";

        if (string.IsNullOrWhiteSpace(UnidadeMedida))
            erros += "O campo \"Unidade de Medida\" deve ser preenchido;";

        if (PrecoAproximado == 0)
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
