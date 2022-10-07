namespace Dominio
{
    public class Parceiro
    {
        public int IdParceiro { get; set; }
        public int IdCidade { get; set; }
        public string TpPessoa { get; set; } = string.Empty;
        public string TipoPessoa
        {
            get
            {
                if (TpPessoa.Trim().ToUpper().Equals("F"))
                    return "FISICA";
                else if (TpPessoa.Trim().ToUpper().Equals("J"))
                    return "JURIDICA";
                else return string.Empty;
            }
        }
        public string NrDoc { get; set; } = string.Empty;
        public string RazaoSocial { get; set; } = string.Empty;
        public string Fantasia { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string IE { get; set; } = string.Empty;
        public string Contato { get; set; } = string.Empty;
        public string Fone { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Franqueadora { get; set; }
        public bool Inativo { get; set; }
        public Cidade? Cidade { get; set; }
        public IEnumerable<Operador>? Operadores { get; set; } 
    }
}
