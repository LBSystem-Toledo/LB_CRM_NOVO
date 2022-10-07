namespace Dominio
{
    public class ClienteProcesso
    {
        public int? IdProcesso { get; set; } = null;
        public int? IdCliente { get; set; } = null;
        public DateTime? DtIni { get; set; } = null;
        public DateTime? DtFin { get; set; } = null;
        public string MotivoInativo { get; set; } = string.Empty;
        public bool Inativo { get; set; }
        public Processo? Processo { get; set; }
    }
}
