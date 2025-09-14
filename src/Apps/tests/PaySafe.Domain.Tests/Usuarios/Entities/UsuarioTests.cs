using FizzWare.NBuilder;
using FluentAssertions;
using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.Usuarios.Entities;
using PaySafe.Domain.ValueObjects;
using Xunit;

namespace PaySafe.Domain.Tests.Usuarios.Entities;

public class UsuarioTests
{
    private readonly Usuario sut;
    private readonly Empresa empresaValida;

    public UsuarioTests()
    {
        empresaValida = Builder<Empresa>.CreateNew().Build();

        sut = Builder<Usuario>.CreateNew().With(x => x.Empresa, empresaValida).Build();
    }

    public class Construtor : UsuarioTests
    {
        [Fact]
        public void Quando_ParametrosValidos_Espero_InstanciarUsuario()
        {
            Cpf cpf = new("83928243004");
            Email email = new("teste@email.com");

            UsuarioCommand command = Builder<UsuarioCommand>.CreateNew()
                .With(x => x.Cpf, cpf)
                .With(x => x.Email, email)
                .Build();

            Usuario usuario = new(command, empresaValida);

            usuario.Nome.Should().Be(command.Nome);
            usuario.Sobrenome.Should().Be(command.Sobrenome);
            usuario.Cpf.Numero.Should().Be(command.Cpf.Numero);
            usuario.Email.Endereco.Should().Be(command.Email.Endereco);
            usuario.Empresa.Should().Be(empresaValida);
            usuario.Telefone.Should().Be(command.Telefone);
            usuario.Excluido.Should().BeFalse();
        }
    }

    public class SetNomeMethod : UsuarioTests
    {
        [Fact]
        public void Quando_NomeValido_Deve_AtualizarNome()
        {
            sut.SetNome("João");
            sut.Nome.Should().Be("João");
        }

        [Fact]
        public void Quando_NomeInvalido_Deve_LancarExcecao()
        {
            Action act = () => sut.SetNome("");
            act.Should().Throw<AtributoObrigatorioException>()
               .WithMessage("*nome*");
        }

        public class SetSobrenomeMethod : UsuarioTests
        {
            [Fact]
            public void Quando_SobrenomeValido_Deve_AtualizarSobrenome()
            {
                sut.SetSobrenome("Silva");
                sut.Sobrenome.Should().Be("Silva");
            }

            [Fact]
            public void Quando_SobrenomeInvalido_Deve_LancarExcecao()
            {
                Action act = () => sut.SetSobrenome(" ");
                act.Should().Throw<AtributoObrigatorioException>()
                   .WithMessage("*sobrenome*");
            }
        }

        public class SetCpfMethod : UsuarioTests
        {
            [Fact]
            public void Quando_CpfValido_Deve_AtualizarCpf()
            {
                var cpf = new Cpf("98765432100");
                sut.SetCpf(cpf);
                sut.Cpf.Numero.Should().Be("98765432100");
            }
        }

        public class SetEmpresaMethod : UsuarioTests
        {
            [Fact]
            public void Quando_EmpresaValida_Deve_AtualizarEmpresa()
            {
                var novaEmpresa = Builder<Empresa>.CreateNew().Build();
                sut.SetEmpresa(novaEmpresa);
                sut.Empresa.Should().Be(novaEmpresa);
            }
        }

        public class SetEmailMethod : UsuarioTests
        {
            [Fact]
            public void Quando_EmailValido_Deve_AtualizarEmail()
            {
                var email = new Email("novo@teste.com");
                sut.SetEmail(email);
                sut.Email.Endereco.Should().Be("novo@teste.com");
            }
        }

        public class SetTelefoneMethod : UsuarioTests
        {
            [Fact]
            public void Quando_TelefoneValido_Deve_AtualizarTelefone()
            {
                sut.SetTelefone("11999999999");
                sut.Telefone.Should().Be("11999999999");
            }
        }

        public class SetExcluidoMethod : UsuarioTests
        {
            [Fact]
            public void Quando_Chamado_Deve_AlterarFlagExcluido()
            {
                sut.SetExcluido();
                sut.Excluido.Should().BeTrue();
            }
        }
    }
}