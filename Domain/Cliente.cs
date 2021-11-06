using System;
using System.ComponentModel.DataAnnotations;

namespace AppNetCore5.Domain
{
    public class Cliente : Base
    {      
        public DateTime Data_Inclusao { get; set; }
    }

    public class ClientePost
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Data_Inclusao { get; set; }
        
    }
}
