using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System.Collections.Generic;

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

            Approvals.Verify(output);
        }
        [Test]
        public void SulfurasQuailtyIsAlways80()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader(""));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();
           
        }
    }
}
