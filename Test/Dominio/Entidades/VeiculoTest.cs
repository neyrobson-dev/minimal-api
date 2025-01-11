using MinimalApi.Dominio.Entidades;

namespace Test.Dominio.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Id = 1;
            veiculo.Nome = "Rx7";
            veiculo.Marca = "Mazda";
            veiculo.Ano = 2015;

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Rx7", veiculo.Nome);
            Assert.AreEqual("Mazda", veiculo.Marca);
            Assert.AreEqual(2015, veiculo.Ano);
        }
    }
}
