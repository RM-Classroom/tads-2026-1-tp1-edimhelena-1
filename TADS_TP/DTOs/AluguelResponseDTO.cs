namespace TADS_TP.DTOs
{
    public class AluguelResponseDTO
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorTotal { get; set; }

        public string ClienteNome { get; set; }
        public string VeiculoModelo { get; set; }
    }
}
