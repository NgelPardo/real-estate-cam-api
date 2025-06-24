using RealEstateCam.Domain.Entities.Owners;
using Xunit;

namespace RealEstateCam.Domain.UnitTests.Owners
{
    public class OwnerTest
    {
        [Fact]
        public void CreateOwner_ShouldReturnValidOwner()
        {
            // Arrange

            // Act
            var owner = Owner.Create(
                OwnerMock.Name,
                OwnerMock.Address,
                OwnerMock.Photo,
                OwnerMock.Birthday
            );

            // Assert
            Assert.NotNull(owner);
            Assert.Equal(OwnerMock.Name, owner.Name);
            Assert.Equal(OwnerMock.Address, owner.Address);
            Assert.Equal(OwnerMock.Photo, owner.Photo);
            Assert.Equal(OwnerMock.Birthday, owner.Birthday);
        }
    }
}