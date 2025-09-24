using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Empresas.Services.Interfaces;
using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.Usuarios.Entities;
using PaySafe.Domain.Usuarios.Repositories;
using PaySafe.Domain.Usuarios.Services.Interfaces;

namespace PaySafe.Domain.Usuarios.Services
{
    public class UsuariosService(IUsuariosRepository usuariosRepository, IEmpresasService empresasService) : IUsuariosService
    {
        private readonly IUsuariosRepository usuariosRepository = usuariosRepository;

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            Usuario usuario = await ValidarAsync(guid, cancellationToken);

            usuario.SetExcluido();

            await usuariosRepository.EditarAsync(usuario, cancellationToken);
        }

        public async Task<Usuario> EditarAsync(Guid guid, UsuarioEditarCommand command, CancellationToken cancellationToken)
        {
            Usuario usuario = await ValidarAsync(guid, cancellationToken);

            usuario.SetNome(command.Nome ?? usuario.Nome);
            usuario.SetSobrenome(command.Sobrenome ?? usuario.Sobrenome);
            usuario.SetLogin(command.Login ?? usuario.Login);
            usuario.SetSenha(command.Senha ?? usuario.Senha);
            usuario.SetCpf(command.Cpf ?? usuario.Cpf);
            usuario.SetTelefone(command.Telefone ?? usuario.Telefone);
            usuario.SetEmail(command.Email ?? usuario.Email);

            await usuariosRepository.EditarAsync(usuario, cancellationToken);

            return usuario;
        }

        public async Task<Usuario> InserirAsync(UsuarioCommand command, CancellationToken cancellationToken)
        {
            Empresa empresa = await empresasService.ValidarAsync(command.Empresa, cancellationToken);

            Usuario usuario = new(command, empresa);

            await usuariosRepository.InserirAsync(usuario, cancellationToken);

            return usuario;
        }

        public async Task<Usuario> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await usuariosRepository.RecuperarAsync(guid, cancellationToken);
        }

        public async Task<Usuario> ValidarAsync(Guid guid, CancellationToken cancellationToken)
        {
            Usuario usuario = await usuariosRepository.RecuperarAsync(guid, cancellationToken);

            if (usuario == null || usuario.Excluido)
                throw new RecursoNaoEncontradoException(nameof(usuario));

            return usuario;
        }
    }
}
