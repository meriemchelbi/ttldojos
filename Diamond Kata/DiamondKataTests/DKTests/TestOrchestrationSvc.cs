using Xunit;
using DiamondKata.service;

namespace DKTests
{
    public class TestOrchestrationSvc
    {
        [Fact]
        public void TestStartGeneratesCompletedMatrix()
        {
            // arrange
            var letterLookup = new LetterLookupSvc("B");
            var managementSvc = new OrchestrationSvc();

            // act
            var result = managementSvc.Start(letterLookup);

            // assert
            Assert.Equal(9, result.Length);
        }
    }
}
