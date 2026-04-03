namespace TADS_TP.Models
{
    public class FabricanteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }

        public List<VeiculoModel> Veiculos { get; set; }
    }
}
