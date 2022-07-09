using System;
using System.Collections.Generic;
using System.Linq;

namespace Programa_Estoque
{
    class Program
    {
        enum Opcao
        {
            Sair,
            CadastrarProduto,
            CadastrarArmazem,
            CadastrarProdutoArmazem,
            RemoverProdutoArmazem,
            AlterarArmazem,
            RemoverArmazem

        }
        static List<Produto> produtos = new List<Produto>();
        static List<Armazem> armazens = new List<Armazem>();
        static void Main(string[] args)
        {

             Opcao Operacao;
            do
            {
                Console.WriteLine("1- Cadastrar produto:");
                Console.WriteLine("2- Cadastrar estoque:");
                Console.WriteLine("3- Cadastrar produto no armazem:");
                Console.WriteLine("4- Remover produto no armazem:");
                Console.WriteLine("5- Alterar armazem:");
                Console.WriteLine("6- Remover um armazem:");
                Operacao = (Opcao)Convert.ToInt32(Console.ReadLine());
                if (Operacao == Opcao.CadastrarProduto)
                {
                    Produto produto = new Produto();
                    Console.WriteLine("- Qual a descrição do produto ?");
                    produto.Descricao = Console.ReadLine();
                    Console.WriteLine("- Qual o país de origem do produto:" + produto.Descricao);
                    produto.PaisOrigem = Console.ReadLine();
                    Console.WriteLine("- Qual a data de registro ?");
                    produto.DataRegistro = Console.ReadLine();
                    Console.WriteLine("- Produto com id " + produto.Id + " cadastrado com sucesso !");
                    produtos.Add(produto);
                }
                if (Operacao == Opcao.CadastrarArmazem)
                {
                    Armazem armazem = new Armazem();
                    Console.WriteLine("- Qual nome do armazem ?");
                    armazem.Nome = Console.ReadLine();
                    Console.WriteLine("- Qual o endereço do armazem " + armazem.Nome);
                    armazem.Endereco = Console.ReadLine();
                    armazens.Add(armazem);
                    Console.WriteLine("- Armazem com id " + armazem.Id + " cadastrado com sucesso !");
                }
                if (Operacao == Opcao.CadastrarProdutoArmazem)
                {
                    Console.WriteLine("- Informe o nome do armazem:");
                    string nomeArmazem = Console.ReadLine();
                    Armazem armazem =  AcharArmazem(armazens,nomeArmazem);
                    if (armazem != null)
                    {
                        Console.WriteLine("- Qual a descrição do produto ?");
                        string nomeProduto = Console.ReadLine();
                        Produto produto = AcharProduto(produtos,nomeProduto);
                        if (produto != null)
                        {
                            armazem.Produtos.Add(produto);
                            Console.WriteLine("- Produto cadastrado no armazem :" + armazem.Nome);
                        }
                        else
                        {
                            Console.WriteLine("- Produto " + nomeProduto +" não encontrado !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("- Armazem "+ nomeArmazem  + " não encontrado !");
                    }
                }
                if (Operacao == Opcao.RemoverProdutoArmazem)
                {
                    Console.WriteLine("- informe o nome do armazem !");
                    string nomeArmazem = Console.ReadLine();
                    Armazem armazem = AcharArmazem(armazens,nomeArmazem);
                    if (armazem != null)
                    {
                        Console.WriteLine("- Informe a descrição do produto a ser removido do armazem :" + armazem.Nome);
                        string nomeProduto = Console.ReadLine();
                        Produto produto = AcharProduto(produtos, nomeProduto);
                        if (produto != null)
                        {
                            armazem.Produtos.Remove(produto);
                            Console.WriteLine("- Produto :" + produto.Descricao + " removido !");
                        }
                        else
                        {
                            Console.WriteLine("- Produto " + nomeProduto + " não encontrado !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("- Armazem " + nomeArmazem + " não encontrado !");
                    }
                }
                if (Operacao == Opcao.AlterarArmazem)
                {
                    Console.WriteLine("- Informe o nome do armazem a ser alterado:");
                    string armazemAltera = Console.ReadLine();
                    Armazem armazem = AcharArmazem(armazens, armazemAltera);
                    if (armazem != null)
                    {
                        Console.WriteLine("- Informe o novo nome do armazem:");
                        armazem.Nome = Console.ReadLine();
                        Console.WriteLine("- Informe o novo endereço do armazem:");
                        armazem.Endereco = Console.ReadLine();
                        Console.WriteLine("- Armazem alterado com sucesso:");
                    }
                    else
                    {
                        Console.WriteLine("- Armazem " + armazemAltera + " não encontrado !");
                    }
                }
                if (Operacao == Opcao.RemoverArmazem)
                {
                    Console.WriteLine("- Informe o nome do armazem a ser removido:");
                    string armazemRemove = Console.ReadLine();
                    Armazem armazem = AcharArmazem(armazens,armazemRemove);
                    if (armazem != null)
                    {
                        armazens.Remove(armazem);
                        Console.WriteLine("- Armazem removido !");
                    }
                    else
                    {
                        Console.WriteLine("- Armazem "+ armazemRemove + " não encontrado !");
                    }
                }
            } while (Operacao != Opcao.Sair);
        }
        static Armazem AcharArmazem(List<Armazem>armazem,string nome)
        {
            var armazemEcontrado = armazem.SingleOrDefault(x => x.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase));
            return armazemEcontrado;
        }
        static Produto AcharProduto(List<Produto> produtos, string nome) 
        {
            var produto = produtos.SingleOrDefault(x => x.Descricao.Contains(nome,StringComparison.CurrentCultureIgnoreCase));
            return produto;
        }
    }   
}
