using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AppNetCore5.Domain
{
    public class Base
    {       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
