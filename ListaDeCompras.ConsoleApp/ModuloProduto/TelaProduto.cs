using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;



namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class TelaProduto : TelaBase<Produto>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioCategoriaEmMemoria repositorioCategoria;
    
    public TelaProduto(RepositorioProdutoEmMemoria repositorioProduto, RepositorioCategoriaEmMemoria repositorioCategoria) : base("Produto", repositorioProduto)
    {
        this.repositorioCategoria = repositorioCategoria;        
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Produtos");

        List<Produto> produtos = repositorio.SelecionarTodos();

        if (produtos.Count == 0)
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
            "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
            "Id", "Nome", "Categoria", "Unidade de Medida", "Preço Aproximado"
        );

        foreach (Produto p in produtos)
        {            
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                p.Id, p.Nome, p.Categoria.Nome, p.UnidadeMedida, p.PrecoAproximado.ToString("C2")
            );
        }        

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        string idSelecionado = SelecionarCategoria();

        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(idSelecionado);

        Console.Write("Digite a unidade de medida do produto: ");
        string unidadeMedida = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o preço aproximado do produto: ");
        decimal precoAproximado = Convert.ToDecimal(Console.ReadLine());      

        return new Produto(nome, categoriaSelecionada, unidadeMedida, precoAproximado);
    }

    private string SelecionarCategoria()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        Console.WriteLine("---------------------------------");
  

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

       
        foreach (Categoria c in categorias)
        {
            string corSelecionada = c.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );                    
        }

        Console.ResetColor();

        Console.WriteLine("---------------------------------");
        
        string? idSelecionado;

        do
        {
            Console.Write("Digite o ID da categoria em que deseja classificar o produto: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        return idSelecionado;
    }
}
