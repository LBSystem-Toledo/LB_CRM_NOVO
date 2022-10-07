namespace Dominio
{
    public class Processo
    {
        public int IdProcesso { get; set; }
        public string DsProcesso { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public int? IdModulo { get; set; }
    }
}
