namespace TADS_TP.DTOs
{
    public class VeiculoResponseDTO
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Quilometragem { get; set; }
        public int FabricanteId { get; set; }
    }
}
