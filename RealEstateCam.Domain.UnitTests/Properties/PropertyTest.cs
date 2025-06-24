using FluentAssertions;
using RealEstateCam.Domain.Entities.Properties;
using Xunit;

namespace RealEstateCam.Domain.UnitTests.Properties
{
    public class PropertyTest
    {
        [Fact]
        public void CreateProperty_ShouldReturnProperty()
        {
            // Arrange

            // Act
            var property = Property.Create(
                PropertyMock.Name,
                PropertyMock.Address,
                PropertyMock.Price,
                PropertyMock.CodeInternal,
                PropertyMock.Year,
                PropertyMock.IdOwner
            );

            // Assert
            property.Name.Should().Be(PropertyMock.Name);
            property.Address.Should().Be(PropertyMock.Address);
            property.Price.Should().Be(PropertyMock.Price);
            property.CodeInternal.Should().Be(PropertyMock.CodeInternal);
            property.Year.Should().Be(PropertyMock.Year);
            property.IdOwner.Should().Be(PropertyMock.IdOwner);
        }
    }
}