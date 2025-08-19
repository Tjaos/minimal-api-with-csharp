namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Nome = "Fusca";
        veiculo.Ano = 1970;

        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Fusca", veiculo.Nome);
        Assert.AreEqual(1970, veiculo.Ano);
    }
}