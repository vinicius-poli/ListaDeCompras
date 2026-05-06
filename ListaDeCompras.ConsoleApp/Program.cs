﻿using System.Text.Json;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloLista;
using ListaDeCompras.ConsoleApp.Utilidades;

string caminhoDownloads = "C:\\Users\\Vinícius\\Downloads";
string caminhoArquivo = caminhoDownloads + "\\categoria.json";

Categoria categoria = new Categoria("Café", "Vermelha");
Categoria categoria2 = new Categoria("Padaria", "Branca");

List<Categoria> categorias = [categoria, categoria2];

JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
opcoesJson.WriteIndented = true;
opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

string jsonString = JsonSerializer.Serialize(categorias, opcoesJson);

File.WriteAllText(caminhoArquivo, jsonString);

return;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ApresentarMenuOpcoesPrincipal();

    if (telaSelecionada == null)
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        string? opcaoSubMenu = telaSelecionada.ObterOpcaoMenu();

        if (opcaoSubMenu == "S")
        {
            Console.Clear();
            break;
        }

        if (telaSelecionada is ITelaCrud telaCrud)
        {
            if (opcaoSubMenu == "1")
                telaCrud.Cadastrar();

            else if (opcaoSubMenu == "2")
                telaCrud.Editar();

            else if (opcaoSubMenu == "3")
                telaCrud.Excluir();

            else if (opcaoSubMenu == "4")
                telaCrud.VisualizarTodos(deveExibirCabecalho: true);

            if (telaCrud is TelaLista telaLista)
            {
                if (opcaoSubMenu == "5")
                    telaLista.AdicionarItem();

                else if (opcaoSubMenu == "6")
                    telaLista.RemoverItem();

                else if (opcaoSubMenu == "7")
                    telaLista.VisualizarItens();
            }
        }
    }
}