﻿using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class B64EncodeTests
    {
        #region Test Initialization and Cleanup
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) { }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void ClassCleanup() { }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestMethodInitialize() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestMethodCleanup() { }
        #endregion

        [TestMethod]
        public void B64Encode_Given_EmptyString_Then_EmptyStringReturn()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToEncode", string.Empty },
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<B64Encode>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["B64EncodedString"]);
        }

        [TestMethod]
        public void B64Encode_Given_String_Then_B64StringReturn()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToEncode", "Hello World!" },
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "SGVsbG8gV29ybGQh";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<B64Encode>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["B64EncodedString"]);
        }
    }
}