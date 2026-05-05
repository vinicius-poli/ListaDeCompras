using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloLista;

public class TelaLista : TelaBase<Lista>, ITelaOpcoes, ITelaCrud
{
    private readonly RepositorioProduto repositorioProduto;

    public TelaLista(RepositorioLista repositorioLista,
    RepositorioProduto repositorioProduto) : base("Lista de Compras", repositorioLista)
    {
        this.repositorioProduto = repositorioProduto;
    }

    public override string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"1 - Cadastrar lista de compras");
        Console.WriteLine($"2 - Editar  lista de compras");
        Console.WriteLine($"3 - Excluir lista de compras");
        Console.WriteLine($"4 - Visualizar listas de compras");
        Console.WriteLine($"5 - Adicionar item à lista de compras");
        Console.WriteLine($"6 - Remover item da lista de compras");
        Console.WriteLine($"7 - Visualizar itens de listas de compras");
        Console.WriteLine("S - Voltar para o início");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void AdicionarItem()
    {
        ExibirCabecalho("Adição de Item de Listas de Compras");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID da lista que deseja gerenciar (ou S para sair): ");
        string idSelecionado = Console.ReadLine() ?? string.Empty;

        if (idSelecionado.ToUpper() == "S" || string.IsNullOrWhiteSpace(idSelecionado))
            return;

        Lista? listaSelecionada = repositorio.SelecionarPorId(idSelecionado);

        if (listaSelecionada == null)
        {
            ExibirMensagem("Não foi possível encontrar a lista de compras selecionada.");
            return;
        }

        List<Item> itens = listaSelecionada.Itens;

        Console.WriteLine(
            "{0, -7} | {1, -30} | {2, -15} | {3, -15}",
            "Id", "Nome do Produto", "Quantidade", "Preço (R$)"
        );

        foreach (Item i in itens)
        {
            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -15}",
                i.Id, i.Produto.Nome, i.Quantidade, i.Preco.ToString("C2")
            );
        }

        Console.ResetColor();                

        Console.WriteLine("---------------------------------");
        VisualizarProdutos();
        Console.WriteLine("---------------------------------");

        Console.WriteLine("Digite o ID do produto que deseja adicionar (ou S para sair): ");
        string idProdutoSelecionado = Console.ReadLine() ?? string.Empty;

        if (idProdutoSelecionado.ToUpper() == "S")
            return;

        Produto? produtoSelecionado = repositorioProduto.SelecionarPorId(idProdutoSelecionado);

        if (produtoSelecionado == null)
        {
            ExibirMensagem("Não foi possível encontrar o produto selecionado.");
            return;
        }

        Console.WriteLine("Digite a quantidade do produto que deseja adicionar (ou S para sair): ");
        int quantidadeItens = Convert.ToInt32(Console.ReadLine());

        listaSelecionada.AdicionarItem(quantidadeItens, produtoSelecionado);

        ExibirMensagem($"O item \"{produtoSelecionado.Nome}\" foi adicionado à lista com sucesso!");
        
    }    

    public void RemoverItem()
    {
        ExibirCabecalho("Remoção de Item de Listas de Compras");

        VisualizarTodos(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID da lista que deseja gerenciar (ou S para sair): ");
        string idSelecionado = Console.ReadLine() ?? string.Empty;

        if (idSelecionado.ToUpper() == "S")
            return;

        Lista? listaSelecionada = repositorio.SelecionarPorId(idSelecionado);

        if (listaSelecionada == null)
        {
            ExibirMensagem("Não foi possível encontrar a lista de compras selecionada.");
            return;
        }

        VisualizarItens(listaSelecionada);

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID do item da lista que deseja remover (ou S para sair): ");
        string idItemSelecionado = Console.ReadLine() ?? string.Empty;

        if (idItemSelecionado.ToUpper() == "S")
            return;

        bool conseguiuRemover = listaSelecionada.RemoverItem(idItemSelecionado);

        if (!conseguiuRemover)
        {
            ExibirMensagem("Não é possível encontrar o item da lista.");
            return;
        }

        ExibirMensagem($"O item foi removido da lista com sucesso!");
    }

    public void VisualizarItens(Lista? listaSelecionada = null)
    {
        if (listaSelecionada == null)
        {
            ExibirCabecalho("Visualização de Item de Listas de Compras");

            VisualizarTodos(false);

            Console.WriteLine("---------------------------------");

            Console.Write("Digite o ID da lista que deseja gerenciar (ou S para sair): ");
            string idSelecionado = Console.ReadLine() ?? string.Empty;

            if (idSelecionado.ToUpper() == "S")
                return;

            listaSelecionada = repositorio.SelecionarPorId(idSelecionado);

            if (listaSelecionada == null)
            {
                ExibirMensagem("Não foi possível encontrar a lista de compras selecionada.");
                return;
            }
        }

        List<Item> itens = listaSelecionada.Itens;

        if (itens.Count == 0)
        {
            ExibirMensagem("Nenhum item registrado.");
            return;
        }
        else
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Itens atuais da lista \"{listaSelecionada.Nome}\"");
            Console.WriteLine("---------------------------------");

            Console.WriteLine(
                "{0, -7} | {1, -30} | {2, -15} | {3, -15}",
                "Id", "Nome do Produto", "Quantidade", "Preço (R$)"
            );

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (Item i in itens)
            {
                Console.WriteLine(
                    "{0, -7} | {1, -30} | {2, -15} | {3, -15}",
                    i.Id, i.Produto.Nome, i.Quantidade, i.Preco.ToString("C2")
                );
            }

            Console.ResetColor();
        }
        Console.WriteLine("---------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
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
            "{0, -7} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
            "Id", "Nome", "Última Modificação.", "Qtd Itens", "Total Gasto (R$)"
        );

        foreach (Lista l in listas)
        {            
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20}",
                l.Id, l.Nome, l.DataAbertura.ToShortDateString(), l.Itens.Count, l.TotalGasto.ToString("C2")
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

    private void VisualizarProdutos()
    { 
        List<Produto> produtos = repositorioProduto.SelecionarTodos();

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
    }
}