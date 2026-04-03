namespace TADS_TP.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public List<AluguelModel> Alugueis { get; set; }
    }
}
