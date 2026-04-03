namespace TADS_TP.Models
{
    public class VeiculoModel
    {
        public int Id { get; set; }

        public string Modelo { get; set; }

        public int Ano{ get; set; }
     
        public double Quilometragem { get; set; }

        public int FabricanteId { get; set; }

        public FabricanteModel Fabricante { get; set; }

        public List<AluguelModel> Alugueis { get; set; }
    }
}
