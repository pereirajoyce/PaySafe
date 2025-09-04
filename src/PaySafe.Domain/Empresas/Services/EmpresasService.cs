using PaySafe.Domain.Empresas.Commands;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Empresas.Repositories;
using PaySafe.Domain.Empresas.Services.Interfaces;
using PaySafe.Domain.Planos.Entities;
using PaySafe.Domain.Planos.Services.Interfaces;

namespace PaySafe.Domain.Empresas.Services
{
    public class EmpresasService(IEmpresasRepository empresasRepository, IPlanosService planosService) : IEmpresasService
    {
        public async Task<Empresa> EditarAsync(Guid guid, EmpresaEditarCommand command, CancellationToken cancellationToken)
        {
            Empresa empresa = await ValidarAsync(guid, cancellationToken);
            Plano plano = await planosService.ValidarAsync(command.Plano, cancellationToken);

            empresa.SetNomeFantasia(command.NomeFantasia);
            empresa.SetRazaoSocial(command.RazaoSocial);
            empresa.SetCnpj(command.Cnpj);
            empresa.SetPlano(plano);

            return empresa;
        }

        public async Task<Empresa> InserirAsync(EmpresaCommand command, CancellationToken cancellationToken)
        {
            Plano plano = await planosService.ValidarAsync(command.Plano, cancellationToken);
            Empresa empresa = new(command, plano);

            await empresasRepository.InserirAsync(empresa, cancellationToken);

            return empresa;
        }

        public async Task<Empresa> ValidarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var empresa =  await empresasRepository.RecuperarAsync(guid, cancellationToken);

            if (empresa == null)
                throw new KeyNotFoundException("Empresa não encontrada.");

            return empresa;
        }

        public async Task<Empresa> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var empresa = await empresasRepository.RecuperarAsync(guid, cancellationToken);

            return empresa;
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            var empresa = await ValidarAsync(guid, cancellationToken);

            await empresasRepository.ExcluirAsync(empresa, cancellationToken);
        }
    }
}
