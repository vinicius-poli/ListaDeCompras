using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class TelaLista : TelaBase<Lista>, ITelaOpcoes, ITelaCrud
{
    public TelaLista(RepositorioLista repositorio) : base("Lista", repositorio)
    {
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Listas");

        List<Lista> listas = repositorio.SelecionarTodos();

        if (listas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhum registro.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20}",
            "Id", "Nome", "Última Modificação"
        );

        foreach (Lista l in listas)
        {            
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20}",
                l.Id, l.Nome, l.DataAbertura.ToShortDateString()
            );
        }

        Console.ResetColor();

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Lista ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da lista: ");
        string nome = Console.ReadLine() ?? string.Empty;

        
        return new Lista(nome);
    }
}