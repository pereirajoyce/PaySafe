namespace PaySafe.Domain.Provedores.Repository
{
    public interface ICieloRepository
    {
        Task<HttpResponseMessage> ConsultarBinDoCartaoAsync(string bin, CancellationToken cancellationToken);
    }
}