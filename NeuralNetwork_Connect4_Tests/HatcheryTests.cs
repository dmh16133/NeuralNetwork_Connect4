using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetwork_Connect4.Models;

namespace NeuralNetwork_Connect4_Tests
{
    [TestClass]
    public class HatcheryTests
    {
        [TestMethod]
        public void GivenInitialCandidateListIsEmpty_WhenRepopulateMissingCandidates_ThenReturnsListOf100Candidates()
        {
            var hatchery = new Hatchery(new Random());
            var list = hatchery.GetGenerationCandidateList(new List<Candidate>());
            Assert.AreEqual(100, list.Count);
        }
        
    }
}