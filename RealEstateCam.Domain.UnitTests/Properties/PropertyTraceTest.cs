using FluentAssertions;
using RealEstateCam.Domain.Entities.Properties;
using Xunit;

namespace RealEstateCam.Domain.UnitTests.Properties
{
    public class PropertyTraceTest
    {
        [Fact]
        public void CreatePropertyTrace_ShouldReturnPropertyTrace()
        {
            // Arrange

            // Act
            var propertyTrace = PropertyTrace.Create(
                PropertyTraceMock.DateSale,
                PropertyTraceMock.Name,
                PropertyTraceMock.Value,
                PropertyTraceMock.Tax,
                PropertyTraceMock.IdProperty
            );

            // Assert
            propertyTrace.DateSale.Should().Be(PropertyTraceMock.DateSale);
            propertyTrace.Name.Should().Be(PropertyTraceMock.Name);
            propertyTrace.Value.Should().Be(PropertyTraceMock.Value);
            propertyTrace.Tax.Should().Be(PropertyTraceMock.Tax);
            propertyTrace.IdProperty.Should().Be(PropertyTraceMock.IdProperty);
        }
    }
}