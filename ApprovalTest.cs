using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));
            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            // Change here in the approval test :
            // I saved the output of the program in a txt file, and I compare it to the output of the test
            // Logically, the approval test should not be changed anymore, as we want still the same result but coded in a better way

            string text = System.IO.File.ReadAllText("../../Test.txt");
            Assert.AreEqual(output, text);
        }
    }
}