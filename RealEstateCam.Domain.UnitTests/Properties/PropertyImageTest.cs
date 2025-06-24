using FluentAssertions;
using RealEstateCam.Domain.Entities.Properties;
using Xunit;

namespace RealEstateCam.Domain.UnitTests.Properties
{
    public class PropertyImageTest
    {
        [Fact]
        public void CreatePropertyImage_ShouldReturnPropertyImage()
        {
            // Arrange

            // Act
            var propertyImage = PropertyImage.Create(
                PropertyImageMock.IdProperty,
                PropertyImageMock.File,
                PropertyImageMock.Enabled
            );

            // Assert
            propertyImage.IdProperty.Should().Be(PropertyImageMock.IdProperty);
            propertyImage.File.Should().Be(PropertyImageMock.File);
            propertyImage.Enabled.Should().Be(PropertyImageMock.Enabled);
        }
    }
}