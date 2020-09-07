using Aplicacao.DTO;
using Aplicacao.Service;
using Dominio.Aggregates.UsuarioAgg;
using Dominio.Repositories;
using Infraestrutura.Transversal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace Aplicacao.Teste.Steps
{
    [Binding]
    public sealed class UsuarioStepDefinitions
    {
        private readonly Mock<ICriptografiaService> _criptografiaService = new Mock<ICriptografiaService>();
        private readonly Mock<IUsuarioRepository> _usuarioRepository = new Mock<IUsuarioRepository>();

        private UsuarioDTO usuarioDTO;
        private string Email;
        private string Senha;

        public UsuarioService ObterService()
        {
            return new UsuarioService(_criptografiaService.Object, _usuarioRepository.Object);
        }

        [Given("que o usuário informa o e-mail (.*)")]
        public void GivenEmail(string mail)
        {
            this.Email = mail;
        }

        [Given("a senha (.*)")]
        public void GivenPassword(string password)
        {
            this.Senha = password;
        }

        [When("submeter os dados")]
        public void WhenAreOneOperation()
        {
            usuarioDTO = new UsuarioDTO
            {
                Email = Email,
                Senha = Senha
            };

            _criptografiaService.Setup(o => o.Encriptar(It.IsAny<string>())).Returns(Guid.NewGuid().ToString());

            var service = ObterService();

            using var context = new DateTimeProviderContext(new DateTime(2005, 10, 15, 22, 13, 45));
            usuarioDTO = service.CriarUsuario(usuarioDTO);
        }

        [Then("a conta será criada e uma identificação aleatória será gerada")]
        public void ThenTheResultShouldBe()
        {
            Assert.AreEqual(usuarioDTO.Email, Email);
            Assert.AreNotEqual(usuarioDTO.Senha, Senha);
            Assert.IsInstanceOfType(usuarioDTO.Id, typeof(Guid));
            Assert.AreEqual(usuarioDTO.DataCriacao, new DateTime(2005, 10, 15, 22, 13, 45));

            _criptografiaService.Verify(o => o.Encriptar(It.IsAny<string>()), Times.Once);
            _usuarioRepository.Verify(o => o.Salvar(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
