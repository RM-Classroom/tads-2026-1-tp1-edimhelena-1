namespace TADS_TP.DTOs
{
    public class PagamentoRequestDTO
    {
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public string Status { get; set; }
        public int AluguelId { get; set; }
    }
}
