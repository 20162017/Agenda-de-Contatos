namespace ManipulandoArquivosTexto
{
    class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5}", Nome, Email, Telefone, Endereco, Bairro, Estado);
        }
    }
}
