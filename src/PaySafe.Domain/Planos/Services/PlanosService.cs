using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Planos.Commands;
using PaySafe.Domain.Planos.Entities;
using PaySafe.Domain.Planos.Repositories;
using PaySafe.Domain.Planos.Services.Interfaces;

namespace PaySafe.Domain.Planos.Services
{
    public class PlanosService(IPlanosRepository planosRepository) : IPlanosService
    {

        public async Task<Plano> EditarAsync(Guid guid, PlanoEditarCommand command, CancellationToken cancellationToken)
        {
            var plano = await planosRepository.RecuperarAsync(guid, cancellationToken);

            if (plano is null)
                throw new RecursoNaoEncontradoException(nameof(plano));

            plano.SetNome(command.Nome ?? plano.Nome);
            plano.SetVolume(command.Volume ?? plano.Volume);
            plano.SetValorExcedente(command.ValorExcedente ?? plano.ValorExcedente);
            plano.SetMensalidade(command.Mensalidade ?? plano.Mensalidade);
            plano.SetMaximoGrupos(command.MaximoGrupos ?? plano.MaximoGrupos);
            plano.SetMaximoUsuarios(command.MaximoUsuarios ?? plano.MaximoUsuarios);

            return plano;
        }

        public async Task<Plano> InserirAsync(PlanoCommand command, CancellationToken cancellationToken)
        {
            var plano = new Plano(command);
            await planosRepository.InserirAsync(plano, cancellationToken);

            return plano;
        }

        public async Task<Plano> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var plano = await planosRepository.RecuperarAsync(guid, cancellationToken);

            return plano;
        }

        public async Task<Plano> ValidarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var plano = await planosRepository.RecuperarAsync(guid, cancellationToken);

            if (plano is null)
                throw new RecursoNaoEncontradoException(nameof(plano));

            return plano;
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            var plano = await planosRepository.RecuperarAsync(guid, cancellationToken);

            if (plano is null)
                throw new RecursoNaoEncontradoException(nameof(plano));

            await planosRepository.ExcluirAsync(plano, cancellationToken);
        }
    }
}
