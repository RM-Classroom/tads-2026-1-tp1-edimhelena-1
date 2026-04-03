namespace TADS_TP.Models
{
    public class PagamentoModel
    {
        public int Id { get; set; }
        
        public DateTime DataPagamento { get; set; }

        public double Valor { get; set; }

        public string Status { get; set; }

        public int AluguelId { get; set; }
        public AluguelModel Aluguel { get; set; }
    }
}
