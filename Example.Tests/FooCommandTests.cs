using Example.Commands;
using Example.Output;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Tests
{
    [TestClass]
    public class FooCommandTests
    {
        [TestMethod]
        public void TrySomething()
        {
            // Arrange
            var app = new CommandLineApplication();
            var foo = new FooCommand(new Etc());
            foo.Register(app);

            // Act
            app.Execute("foo", "--quux", "12", "34");

            // Assert
            Assert.AreEqual("12", foo.QuuxOption.Value());
            Assert.AreEqual("34", foo.QuadArgument.Value);
        }
    }
}
