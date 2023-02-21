using Octokit;

namespace Repositorios.Servicos.Extensoes
{
    public static class LinguagemExtensao
    {
        public static Language ObterEnumeradorDeLinguagem(this string texto)
        {
            try
            {
                return (Language)Enum.Parse(typeof(Language), texto);
            }
            catch (Exception)
            {
                throw new ArgumentException("Não foi possível identificar a linguagem solicitada!");
            }
        }

        public static string? ObterTextoEnumerador(this Language linguagem) =>
            Enum.GetName(typeof(Language), linguagem);
    }
}
