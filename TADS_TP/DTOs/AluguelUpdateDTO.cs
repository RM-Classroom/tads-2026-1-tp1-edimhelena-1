namespace TADS_TP.DTOs
{
    public class AluguelUpdateDTO
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double QuilometragemInicial { get; set; }
        public double QuilometragemFinal { get; set; }
        public double ValorDiaria { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
