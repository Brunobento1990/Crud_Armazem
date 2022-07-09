using System;
using System.Collections.Generic;
using System.Text;

namespace Programa_Estoque
{
    public class Produto
    {
        private static int BaseID = 1;
        public int Id { get; }
        public string Descricao { get; set; }
        public string PaisOrigem { get; set; }
        public string DataRegistro { get; set; }
        public Produto()
        {
            this.Id = BaseID;
            BaseID++;
        }
    }
}
