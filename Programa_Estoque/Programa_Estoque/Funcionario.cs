using System;
using System.Collections.Generic;
using System.Text;

namespace Programa_Estoque
{
    public class Funcionario
    {
        private static int BaseID = 1;
        public int Id { get; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public Funcionario()
        {
            this.Id = BaseID;
            BaseID++;
        }
    }
}
