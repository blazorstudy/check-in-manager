using CheckInManager.Core.Models;

namespace CheckInManager.Core.Tests.Models
{
    [TestClass]
    public class MeetUpNameTagModelTests
    {
        [TestMethod]
        public void Given_Type_When_Initiated_Then_Return_Default()
        {
            var model = new MeetUpNameTagModel();

            Assert.IsNull(model.Name);
            Assert.AreEqual("개인", model.Company, ignoreCase: true);
        }

        [DataTestMethod]
        [DataRow("hello", "world")]
        public void Given_Values_When_Initiated_Then_Return_Values(string name, string company)
        {
            var model = new MeetUpNameTagModel
            {
                Name = name,
                Company = company
            };

            Assert.AreEqual(name, model.Name);
            Assert.AreEqual(company, model.Company);
        }
    }
}
