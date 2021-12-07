using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using GildedRoseKata;

namespace GildedRoseTests
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void Verify()
        {
            // Approvals.Verify("hi....");
        }
    }
}
