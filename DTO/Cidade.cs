namespace Dominio
{
    public class Cidade
    {
        public int Cd_cidade { get; set; }
        public string Ds_cidade { get; set; } = string.Empty;
        public int Cd_uf { get; set; }
        public UF? Uf { get; set; } = null;
    }
}
