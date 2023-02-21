namespace Repositorios.Dominio.Entidades
{
    public class Repositorio : EntidadeBase
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public string Proprietario { get; set; }
        public string HtmlUrl { get; set; }
        public string Descricao { get; set; }
        public string Linguagem { get; set; }
        public int QuantidadeEstrelas { get; set; }
    }
}