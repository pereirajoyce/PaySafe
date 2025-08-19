namespace PaySafe.Domain.ValueObjects
{
    public class Cpf
    {
        public string Numero { get; private set; }

        protected Cpf() { }

        public Cpf(string numero)
        {
            if (string.IsNullOrEmpty(numero) || !ValidarCpf(numero))
                throw new ArgumentException("CPF inválido.");

            Numero = numero;
        }

        private static bool ValidarCpf(string cpf)
        {
            cpf = new string([.. cpf.Where(char.IsDigit)]);

            if (cpf.Length != 11)
                return false;

            if (cpf.All(c => c == cpf[0]))
                return false;

            var primeiroDigito = CalcularDigitoVerificador(cpf[..9]);
            var segundoDigito = CalcularDigitoVerificador(cpf[..10]);

            return cpf[9] == primeiroDigito && cpf[10] == segundoDigito;
        }

        private static char CalcularDigitoVerificador(string cpfBase)
        {
            var multiplicadores = cpfBase.Length == 9
                ? [10, 9, 8, 7, 6, 5, 4, 3, 2]
                : new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var soma = cpfBase
                .Select((t, i) => int.Parse(t.ToString()) * multiplicadores[i])
                .Sum();

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;

            return digito.ToString()[0];
        }
    }
}
