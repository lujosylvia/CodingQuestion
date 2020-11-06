using CodingQuestion.Models;
using CodingQuestion.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CodingQuestion.Tests.Services
{

    [TestClass]
    public class ConsoleServiceTests
    {
        public Mock<IConsoleManager> _mockConsoleManager;
        public Mock<ConsoleService> _testConsoleService;
        public DenominationDataSet _testDataSet = TestData.GetTestDataSet();

        [TestInitialize]
        public void Initialize()
        {
            _mockConsoleManager = new Mock<IConsoleManager>();
            _testConsoleService = new Mock<ConsoleService>(_mockConsoleManager.Object);
        }

        [TestMethod, TestCategory("Small")]
        public void InputDataSets_NoDataSets_ReturnsEmptyList()
        {
            _mockConsoleManager
                .Setup(x => x.ReadSingleValue())
                .Returns(0);

            _testConsoleService.CallBase = true;

            var result = _testConsoleService.Object.InputDataSets().ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("Small")]
        public void InputDataSets_DataSetsAvailable_ReturnsPopulatedDataSets()
        {
            _testConsoleService.Setup(x => x.PopulateDataSets(It.IsAny<int>()))
                .Returns(new List<DenominationDataSet> { 
                    _testDataSet
                });

            var result = _testConsoleService.Object.InputDataSets();

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod, TestCategory("Small")]
        public void OutputHighestDifferences_NoDataSets_OutputsNothing()
        {
            _testConsoleService.Object.OutputHighestDifferences(new List<DenominationDataSet> { });
            _mockConsoleManager.Verify(x => x.WriteOutput(It.IsAny<string>()), Times.Never);
            _mockConsoleManager.Verify(x => x.WriteOutput(It.IsAny<int>()), Times.Never);
        }

        [TestMethod, TestCategory("Small")]
        public void OutputHighestDifferences_DataSets_OutputsCorrectDifference()
        {
            _testConsoleService.Object.OutputHighestDifferences(new List<DenominationDataSet> { 
                _testDataSet
            });

            _mockConsoleManager.Verify(x => x.WriteOutput(_testDataSet.HighestDifference), Times.Once);
        }

        [TestMethod, TestCategory("Small")]
        public void OutputHighestDifferences_DataSets_OutputsCorrectIndex()
        {
            _testConsoleService.Object.OutputHighestDifferences(new List<DenominationDataSet> {
                _testDataSet
            });

            _mockConsoleManager.Verify(x => x.WriteOutput("Data Set 1:"), Times.Once);
        }
    }
}
