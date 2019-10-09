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
            var OrchestrationSvc = new OrchestrationSvc();

            // act
            var result = OrchestrationSvc.Start(letterLookup);

            // assert
            Assert.Equal(9, result.Length);
        }
    }
}
