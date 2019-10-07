using Xunit;
using DiamondKata.service;

namespace DKTests
{
    public class TestManagementSvc
    {
        [Fact]
        public void TestStartGeneratesCompletedMatrix()
        {
            // arrange
            var letterLookup = new LetterLookupSvc("B");
            var managementSvc = new ManagementSvc();

            // act
            var result = managementSvc.Start(letterLookup);

            // assert
            Assert.Equal(9, result.Length);
        }
    }
}
