using Xunit;
using FluentAssertions;
using FizzWare.NBuilder;
using PaySafe.Domain.Usuarios.Services;
using PaySafe.Domain.Usuarios.Repositories;
using PaySafe.Domain.Empresas.Services.Interfaces;
using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.Usuarios.Entities;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.ValueObjects;
using PaySafe.CrossCutting.Exceptions;
using NSubstitute;

namespace PaySafe.Domain.Tests.Usuarios.Services
{
    public class UsuariosServiceTests
    {
        private readonly IUsuariosRepository usuariosRepository;
        private readonly IEmpresasService empresasService;
        private readonly UsuariosService sut;
        private readonly CancellationToken cancellationToken = CancellationToken.None;

        public UsuariosServiceTests()
        {
            usuariosRepository = Substitute.For<IUsuariosRepository>();
            empresasService = Substitute.For<IEmpresasService>();
            sut = new UsuariosService(usuariosRepository, empresasService);
        }

        public class InserirAsyncMethod : UsuariosServiceTests
        {
            [Fact]
            public async Task Quando_CommandValido_Deve_InserirUsuario()
            {
                // Arrange
                var empresa = Builder<Empresa>.CreateNew()
                    .With(x => x.Cnpj, new Cnpj("14228975000186"))
                    .Build();

                var command = Builder<UsuarioCommand>.CreateNew()
                    .With(x => x.Cpf, new Cpf("19240748008"))
                    .With(x => x.Email, new Email("teste@teste.com"))
                    .Build();

                empresasService.ValidarAsync(command.Empresa, cancellationToken)
                    .Returns(empresa);

                // Act
                var usuario = await sut.InserirAsync(command, cancellationToken);

                // Assert
                usuario.Nome.Should().Be(command.Nome);
                usuario.Empresa.Should().Be(empresa);

                await usuariosRepository.Received(1).InserirAsync(usuario, cancellationToken);
            }
        }

        public class EditarAsyncMethod : UsuariosServiceTests
        {
            [Fact]
            public async Task Quando_CommandValido_Deve_AtualizarUsuario()
            {
                // Arrange
                var guid = Guid.NewGuid();
                var usuarioExistente = Builder<Usuario>.CreateNew()
                    .With(x => x.Guid, guid)
                    .With(x => x.Empresa, Builder<Empresa>.CreateNew().Build())
                    .With(x => x.Cpf, new Cpf("19240748008"))
                    .With(x => x.Email, new Email("teste@teste.com"))
                    .Build();

                var command = Builder<UsuarioEditarCommand>.CreateNew()
                    .With(x => x.Cpf, new Cpf("19240748008"))
                    .With(x => x.Email, new Email("novo@teste.com"))
                    .Build();

                usuariosRepository.RecuperarAsync(guid, cancellationToken)
                    .Returns(usuarioExistente);

                // Act
                var usuarioAtualizado = await sut.EditarAsync(guid, command, cancellationToken);

                // Assert
                usuarioAtualizado.Nome.Should().Be(command.Nome);
                usuarioAtualizado.Cpf.Numero.Should().Be(command.Cpf.Numero);
                usuarioAtualizado.Email.Endereco.Should().Be(command.Email.Endereco);

                await usuariosRepository.Received(1).EditarAsync(usuarioExistente, cancellationToken);
            }
        }

        public class ExcluirAsyncMethod : UsuariosServiceTests
        {
            [Fact]
            public async Task Quando_UsuarioExiste_Deve_MarcarComoExcluido()
            {
                // Arrange
                var guid = Guid.NewGuid();
                var usuario = Builder<Usuario>.CreateNew()
                    .With(x => x.Guid, guid)
                    .With(x => x.Empresa, Builder<Empresa>.CreateNew().Build())
                    .Build();

                usuariosRepository.RecuperarAsync(guid, cancellationToken)
                    .Returns(usuario);

                // Act
                await sut.ExcluirAsync(guid, cancellationToken);

                // Assert
                usuario.Excluido.Should().BeTrue();
                await usuariosRepository.Received(1).EditarAsync(usuario, cancellationToken);
            }
        }

        public class RecuperarAsyncMethod : UsuariosServiceTests
        {
            [Fact]
            public async Task Quando_UsuarioExiste_Deve_RetornarUsuario()
            {
                var guid = Guid.NewGuid();
                var usuario = Builder<Usuario>.CreateNew().With(x => x.Guid, guid).Build();

                usuariosRepository.RecuperarAsync(guid, cancellationToken)
                    .Returns(usuario);

                var result = await sut.RecuperarAsync(guid, cancellationToken);

                result.Should().Be(usuario);
            }
        }

        public class ValidarAsyncMethod : UsuariosServiceTests
        {
            [Fact]
            public async Task Quando_UsuarioNaoExiste_Deve_LancarExcecao()
            {
                usuariosRepository.RecuperarAsync(Arg.Any<Guid>(), cancellationToken)
                    .Returns((Usuario)null!);

                Func<Task> act = async () => await sut.ValidarAsync(Guid.NewGuid(), cancellationToken);

                await act.Should().ThrowAsync<RecursoNaoEncontradoException>();
            }

            [Fact]
            public async Task Quando_UsuarioExcluido_Deve_LancarExcecao()
            {
                var usuario = Builder<Usuario>.CreateNew().With(x => x.Excluido, true).Build();

                usuariosRepository.RecuperarAsync(Arg.Any<Guid>(), cancellationToken)
                    .Returns(usuario);

                Func<Task> act = async () => await sut.ValidarAsync(Guid.NewGuid(), cancellationToken);

                await act.Should().ThrowAsync<RecursoNaoEncontradoException>();
            }

            [Fact]
            public async Task Quando_UsuarioValido_Deve_RetornarUsuario()
            {
                var usuario = Builder<Usuario>.CreateNew().With(x => x.Excluido, false).Build();

                usuariosRepository.RecuperarAsync(Arg.Any<Guid>(), cancellationToken)
                    .Returns(usuario);

                var result = await sut.ValidarAsync(Guid.NewGuid(), cancellationToken);

                result.Should().Be(usuario);
            }
        }
    }
}
