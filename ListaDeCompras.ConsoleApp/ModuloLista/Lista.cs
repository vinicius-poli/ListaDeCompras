using System.Buffers;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class Lista : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public StatusLista Status { get; private set; }
    public List<Item> Itens { get; private set; } = new List<Item>();
    public decimal TotalGasto
    {
        get
        {
            decimal totalGasto = 0;

            foreach (Item item in Itens)
                totalGasto += item.Preco;

            return totalGasto;
        }
    }

    public Lista()
    {
        
    }

    public Lista(string nome)
    {
        Nome = nome;
        DataAbertura = DateTime.Now;
        

        Abrir();
    }

    public void Abrir()
    {
        Status = StatusLista.Aberta;
    }

    public void Concluir()
    {
        Status = StatusLista.Concluída;
    }

    public void AdicionarItem(int quantidade, Produto produto)
    {
        Item item = new Item(quantidade, produto);

        Itens.Add(item);
    }

    public bool RemoverItem(string idItem)
    {
        foreach (Item item in Itens)
        {
            if (item.Id == idItem)
            {
                Itens.Remove(item);
                return true;
            }
        }

        return false;
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