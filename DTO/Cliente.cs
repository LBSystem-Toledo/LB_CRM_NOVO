namespace Dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int IdCidade { get; set; }
        public Cidade? Cidade { get; set; } = null;
        public int IdAtividade { get; set; }
        public Atividade? Atividade { get; set; } = null;
        public int IdParceiro { get; set; }
        public Parceiro? Parceiro { get; set; } = null;
        public int IdPacote { get; set; }
        public Pacote? Pacote { get; set; } = null;
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
        public string Obs { get; set; } = string.Empty;
        public int NrSeqLic { get; set; }
        public DateTime? DtLicenca { get; set; } = null;
        public bool Mobile { get; set; }
        public int QtMobile { get; set; }
        public bool Inativo { get; set; }
        public IEnumerable<ClienteProcesso>? Processos { get; set; }
        public IEnumerable<UsuarioCliente>? Usuarios { get; set; }
    }
}
