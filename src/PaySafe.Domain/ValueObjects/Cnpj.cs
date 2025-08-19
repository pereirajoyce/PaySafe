namespace PaySafe.Domain.ValueObjects
{
    public class Cnpj
    {
        public string Numero { get; private set; } // apenas dígitos (14)

        protected Cnpj() { }

        public Cnpj(string numero)
        {
            numero = Normalizar(numero);

            if (!ValidarCnpj(numero))
                throw new ArgumentException("CNPJ inválido.", nameof(numero));

            Numero = numero;
        }

        public static bool TryParse(string? valor, out Cnpj? cnpj)
        {
            cnpj = null;
            var normalizado = Normalizar(valor);

            if (!ValidarCnpj(normalizado)) return false;

            cnpj = new Cnpj(normalizado);
            return true;
        }

        public static Cnpj Parse(string valor) => new(valor);

        public string Formatado() =>
            string.IsNullOrEmpty(Numero) ? string.Empty
            : $"{Numero[..2]}.{Numero.Substring(2, 3)}.{Numero.Substring(5, 3)}/{Numero.Substring(8, 4)}-{Numero.Substring(12, 2)}";

        public override string ToString() => Formatado();

        public static bool ValidarCnpj(string? cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return false;

            cnpj = Normalizar(cnpj);
            if (cnpj.Length != 14) return false;

            if (cnpj.All(c => c == cnpj[0])) return false;

            var dv1 = CalcularDigitoVerificador(cnpj[..12]);
            var dv2 = CalcularDigitoVerificador(cnpj[..13]);

            return cnpj[12] == dv1 && cnpj[13] == dv2;
        }

        private static char CalcularDigitoVerificador(string baseNumerica)
        {
            var pesos = baseNumerica.Length == 12
                ? new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }
                : new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var soma = baseNumerica
                .Select((ch, i) => (ch - '0') * pesos[i])
                .Sum();

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;
            return (char)('0' + digito);
        }

        private static string Normalizar(string? valor) =>
            new((valor ?? string.Empty).Where(char.IsDigit).ToArray());

        public override bool Equals(object? obj) => Equals(obj as Cnpj);

        public bool Equals(Cnpj? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Numero == other.Numero;
        }

        public override int GetHashCode() => Numero.GetHashCode(StringComparison.Ordinal);

        public static bool operator ==(Cnpj? left, Cnpj? right) =>
            left is null ? right is null : left.Equals(right);

        public static bool operator !=(Cnpj? left, Cnpj? right) => !(left == right);
    }
}
