namespace TADS_TP.Models
{
    public class AluguelModel
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public double QuilometragemInicial { get; set; }
        public double QuilometragemFinal { get; set; }

        public double ValorDiaria { get; set; }
        public double ValorTotal { get; set; }

        public DateTime? DataDevolucao { get; set; }

        public int VeiculoId { get; set; }
        public VeiculoModel Veiculo { get; set; }

        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }

        public List<PagamentoModel> Pagamentos { get; set; }
    }
}
