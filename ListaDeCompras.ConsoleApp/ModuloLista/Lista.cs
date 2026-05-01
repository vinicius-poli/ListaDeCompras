using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class Lista : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataAbertura { get; private set; } = DateTime.Now;

    public Lista(string nome)
    {
        Nome = nome;        
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 3 || Nome.Length > 50)
            erros += "O campo \"Nome\" deve conter entre 3 e 50 caracteres;";
 
        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Lista listaAtualizada = (Lista)entidadeAtualizada;

        Nome = listaAtualizada.Nome;
        DataAbertura = DateTime.Now;
    }
}