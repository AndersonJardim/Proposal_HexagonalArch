using Moq;
using ProjetoContrato.Application.Services;
using ProjetoContrato.Domain.Entities;
using ProjetoContrato.Domain.Ports;

namespace ProjetoContrato.Tests.Application
{
    public class ContractServiceManagerTest
    {
        private readonly Mock<IContractRepository> _mockContractRepository;
        private readonly ContractServiceManager _contractServiceManager;

        public ContractServiceManagerTest()
        {
            _mockContractRepository = new Mock<IContractRepository>();
            _contractServiceManager = new ContractServiceManager(_mockContractRepository.Object);
        }

        [Fact]
        public async Task GetContract_ShouldReturnContract_WhenContractExists()
        {
            // Arrange            
            _mockContractRepository
                .Setup(x => x.GetAll())
                .ReturnsAsync(It.IsAny<IEnumerable<Contract>>)
                .Verifiable();
            
            // Act
            var result = _contractServiceManager.GetAllContractsAsync();

            // Assert
            _mockContractRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetContract_ShouldThrowException_WhenContractDoesNotExist()
        {
            // Arrange            
            _mockContractRepository
                .Setup(x => x.GetAll())
                .ReturnsAsync(It.IsAny<IEnumerable<Contract?>>)
                .Verifiable();

            // Act
            var result = Assert.ThrowsAsync<Exception>(() => 
                _contractServiceManager.GetAllContractsAsync());

            // Assert
            _mockContractRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
