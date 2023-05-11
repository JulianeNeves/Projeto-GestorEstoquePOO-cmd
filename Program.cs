using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projeto3
{
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu {Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}
        enum Escolha { ProdutoFisico = 1, Ebook, Cursos}
        static void Main(string[] args)
        {
            Carregar();
            bool escolherSair = false;

            while(escolherSair==false)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar entrada\n5-Registrar Saida\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if(opInt >0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;

                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolherSair = true;
                            break;
                    }
                }
                else
                {
                    escolherSair = true;
                }
                Console.Clear();
            }
        }//main

        static void Listagem()
        {
            int i = 0;
            Console.WriteLine("Lista de produtos: ");

            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine($"Id: {i}");
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }
           
        static void Remover()
        {
            Listagem();
            Console.WriteLine("digite o id do produto que quer remover: ");
            int id = int.Parse(Console.ReadLine());

            if(id>=0 && id< produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("digite o id do produto que quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());

            if(id>=0 && id< produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("digite o id do produto que quer dar baixa: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de produtos: ");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Cursos");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);
            Escolha escolher = (Escolha)escolhaInt;

            switch (escolher)
            {
                case Escolha.ProdutoFisico:
                    CadastrarPFisico();
                    break;
                case Escolha.Ebook:
                    CadastrarEbook();
                    break;
                case Escolha.Cursos:
                    CadastrarCursos();
                    break;
            }
        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrar produtos fisicos: ");
            Console.WriteLine("nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrar Ebook: ");
            Console.WriteLine("nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("autor: ");
            string autor = Console.ReadLine();
            Console.WriteLine("preço: ");
            float preco = float.Parse(Console.ReadLine());

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }


        static void CadastrarCursos()
        {
            Console.WriteLine("Cadastrar Ebook: ");
            Console.WriteLine("nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("autor: ");
            string autor = Console.ReadLine();
            Console.WriteLine("preço: ");
            float preco = float.Parse(Console.ReadLine());

            Curso cursos = new Curso(nome, preco, autor);
            produtos.Add(cursos);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.bat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            encoder.Serialize(stream, produtos);

            stream.Close(); // toda vez que abre uma stream tem que fechar
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.bat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }
    }
}

