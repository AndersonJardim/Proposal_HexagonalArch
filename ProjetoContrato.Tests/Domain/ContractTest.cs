using ProjetoContrato.Domain.Entities;

namespace ProjetoContrato.Tests.Domain
{
    public class ContractTest
    {
        [Fact]
        public void Contract_ShouldHaveValidProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var contract = new Contract
            (
                id,
                "Test Contract",
                1
            );

            // Act & Assert
            Assert.Equal(id, contract.Id);
            Assert.Equal("Test Contract", contract.Name);
            Assert.Equal(1, contract.Status);
        }

        [Trait("Category", "Contratos")]
        [Trait("Method", nameof(Contract))]
        [Fact]
        public void Contract_ShouldHaveGuidId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var contract = new Contract
            (
                id,
                "Test Contract",
                1
            );

            // Act & Assert
            Assert.Equal(id, contract.Id);
            Assert.IsType<Guid>(contract.Id);
        }
    }
}
