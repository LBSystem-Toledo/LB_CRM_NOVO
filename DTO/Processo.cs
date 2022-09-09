namespace Dominio
{
    public class Processo
    {
        public int Id { get; set; }
        public string Ds_processo { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public int ModuloId { get; set; }
        public Modulo? Modulo { get; set; } = null;
    }
}
