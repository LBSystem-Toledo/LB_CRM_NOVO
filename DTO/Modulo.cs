namespace Dominio
{
    public class Modulo
    {
        public int IdModulo { get; set; }
        public string DsModulo { get; set; } = string.Empty;
        public IEnumerable<Processo>? Processos { get; set; }
    }
}
