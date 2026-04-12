namespace TADS_TP.DTOs
{
    public class AluguelRequestDTO
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double QuilometragemInicial { get; set; }
        public decimal ValorDiaria { get; set; }
        public int VeiculoId { get; set; }
        public int ClienteId { get; set; }
    }
}
