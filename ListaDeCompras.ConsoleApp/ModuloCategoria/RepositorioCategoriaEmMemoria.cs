using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Memoria;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class RepositorioCategoriaEmMemoria : RepositorioBaseEmMemoria<Categoria>, IRepositorio<Categoria>; //Porque está dando o erro: 'RepositorioCategoriaEmMemoria' does not implement interface member 'IRepositorio<Categoria>.Excluir(Categoria)'?
