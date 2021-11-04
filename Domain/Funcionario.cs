using System;

namespace AppNetCore5.Domain
{
    public class Funcionario : Base
    {     
        public DateTime Data_Admissao { get; set; }       
    }

    public class FuncionarioPost
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Data_Admissao { get; set; }
    }
}
