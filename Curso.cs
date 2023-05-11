using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable] //serve para que esse codigo pode ser salvo em arquivos
    class Curso:Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {vagas}");
            Console.WriteLine("Digite a quantide de vagas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas = vagas + entrada;
            Console.WriteLine("Vagas Registrada! ");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vagas no curso {vagas}");
            Console.WriteLine("Digite a quantide de vagas que você quer consumir: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas = vagas - entrada;
            Console.WriteLine("Saídas Registrada! ");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:{nome}");
            Console.WriteLine($"Autor:{autor}");
            Console.WriteLine($"Preco:{preco}");
            Console.WriteLine($"Vagas Restantes:{vagas}");
            Console.WriteLine("============================");
        }
    }
}
