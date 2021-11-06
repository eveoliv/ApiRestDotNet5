using System;

namespace AppNetCore5.Domain
{
    public class Trade
    {
        public long Tid { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public long Date { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateWin { get; set; }
        public string Ocorrencia { get; set; }
    }
}
