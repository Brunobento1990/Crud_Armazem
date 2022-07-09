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
            CadastrarFuncionario,
            CadastrarProdutoArmazem,
            CasdastrarFuncArmazem,
            RemoverProdutoArmazem,
            RemoverfuncArmazem,
            AlterarArmazem,
            RemoverArmazem

        }
        static List<Produto> produtos = new List<Produto>();
        static List<Armazem> armazens = new List<Armazem>();
        static List<Funcionario> funcionarios = new List<Funcionario>();
        static void Main(string[] args)
        {

             Opcao Operacao;
            do
            {
                Console.WriteLine("1- Cadastrar produto:");
                Console.WriteLine("2- Cadastrar armazem:");
                Console.WriteLine("3- Cadastrar cadastra funcionário:");
                Console.WriteLine("4- Cadastrar produto no armazem:");
                Console.WriteLine("5- Cadastrar funcionário no armazem:");
                Console.WriteLine("6- Remover produto no armazem:");
                Console.WriteLine("6- Remover funcionário do armazem:");
                Console.WriteLine("7- Alterar armazem:");
                Console.WriteLine("8- Remover um armazem:");
                Console.WriteLine("0- Sair:");
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
                if (Operacao == Opcao.CadastrarFuncionario)
                {
                    Funcionario funcionario = new Funcionario();
                    Console.WriteLine("- Informe o nome do funcionário:");
                    funcionario.Nome = Console.ReadLine();
                    Console.WriteLine("- Informe a data de nascimento de " + funcionario.Nome);
                    funcionario.DataNascimento = Console.ReadLine();
                    funcionarios.Add(funcionario);
                    Console.WriteLine("- Funcionário cadastrado com sucesso !");
                }
                if (Operacao == Opcao.CasdastrarFuncArmazem)
                {
                    Console.WriteLine("- Informe o nome do armazem que será cadastrado o funcionário:");
                    string acharArmazem = Console.ReadLine();
                    Armazem armazem = AcharArmazem(armazens,acharArmazem);
                    if (armazem != null)
                    {
                        Console.WriteLine("- Informe o nome do funcionário:");
                        string nome = Console.ReadLine();
                        Funcionario funcionario = AcharFuncionario(funcionarios,nome);
                        if (funcionario != null)
                        {
                            armazem.Funcionarios.Add(funcionario);
                            Console.WriteLine($"{funcionario.Nome} cadastrado no armazem {armazem.Nome} !");
                        }
                        else
                        {
                            Console.WriteLine("- Funcionario não encontrado !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("- Armazem não encontrado !");
                    }
                }
                if (Operacao == Opcao.RemoverfuncArmazem)
                {
                    Console.WriteLine("- Informe o nome do armazem que será removido o funcionário:");
                    string nomeArmazem = Console.ReadLine();
                    Armazem armazem = AcharArmazem(armazens,nomeArmazem);
                    if (armazem != null)
                    {
                        Console.WriteLine("- Informe o nome do funcionário:");
                        string nome = Console.ReadLine();
                        Funcionario funcionario = AcharFuncionario(funcionarios, nome);
                        if (funcionario != null)
                        {
                            armazem.Funcionarios.Remove(funcionario);
                            Console.WriteLine($"{funcionario.Nome} removido no armazem {armazem.Nome} !");
                        }
                        else
                        {
                            Console.WriteLine("- Funcionario não encontrado !");
                        }
                    }
                    else
                    {
                        Console.WriteLine("- Armazem não encontrado !");
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
        static Funcionario AcharFuncionario(List<Funcionario> funcionarios, string nome)
        {
            var funcionario = funcionarios.SingleOrDefault(x => x.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase));
            return funcionario;
        }
    }   
}
