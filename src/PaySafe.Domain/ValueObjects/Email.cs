using System.Text.RegularExpressions;

namespace PaySafe.Domain.ValueObjects
{
    public partial class Email
    {
        public string Endereco { get; private set; }

        protected Email() { }

        public Email(string endereco)
        {
            if (string.IsNullOrEmpty(endereco) || !ValidarEmail(endereco))
                throw new ArgumentException("E-mail inválido.");

            Endereco = endereco;
        }

        private static bool ValidarEmail(string email)
        {
            return EmailRegex().IsMatch(email);
        }

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex EmailRegex();
    }
}
