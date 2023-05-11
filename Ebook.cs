using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable] //serve para que esse codigo pode ser salvo em arquivos
    class Ebook: Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("NÃO É POSSIVEL DAR ENTRADA EM EBOOK, POIS É UM PRODUTO DIGITAL");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no Ebook {nome}");
            Console.WriteLine("Digite a quantide de vendas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
           vendas = vendas + entrada;
            Console.WriteLine("Vendas Registrada! ");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:{nome}");
            Console.WriteLine($"Autor:{autor}");
            Console.WriteLine($"Preco:{preco}");
            Console.WriteLine($"Vendas:{vendas}");
            Console.WriteLine("============================");
        }
    }
}
