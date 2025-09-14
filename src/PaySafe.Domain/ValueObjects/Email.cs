using PaySafe.CrossCutting.Exceptions;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PaySafe.Domain.ValueObjects
{
    public partial class Email
    {
        public string Endereco { get; private set; }

        protected Email() { }

        public Email(string endereco)
        {
            if (string.IsNullOrEmpty(endereco) || !ValidarEmail(endereco))
                throw new AtributoInvalidoException(nameof(endereco));

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
