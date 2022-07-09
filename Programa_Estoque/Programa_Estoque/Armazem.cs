using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Programa_Estoque
{
    public class Armazem
    {
        private static int BaseId = 1;
        public int Id { get; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Produto> Produtos = new List<Produto>();
        public Armazem()
        {
            this.Id = BaseId;
            BaseId++;
        }
    }
}
