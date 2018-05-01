using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VotingMachineCore;

namespace UnitTestVotingMachineCore
{
    [TestClass]
    public class UnitTest_Election
    {
        List<int> eligibleVoters;
        List<string> candidates;

        [TestInitialize]
        public void Initialize()
        {
            eligibleVoters = new List<int>()
            {
                12345,
                67890,
                13579,
                24680,
                10293,
                48576
            };
            candidates = new List<string>()
            {
                "Zak Kastl",
                "Vy Vo",
                "Aaron Beal",
                "Barry Hunt"
            };
        }

        [TestMethod]
        public void TestCreateElection()
        {
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);
            Assert.IsNotNull(testElection);
        }

        [TestMethod]
        public void TestVote_Successful()
        {
            string expectedResult = "Vote Accepted!";
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            Assert.AreEqual(expectedResult,
                testElection.ProcessVote(12345, new List<string>() { "Zak Kastl" }));
        }

        [TestMethod]
        public void TestVote_Successful_MultipleCandidates()
        {
            string expectedResult = "Vote Accepted!";
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            Assert.AreEqual(expectedResult,
                testElection.ProcessVote(12345, new List<string>() { "Zak Kastl", "Vy Vo" }));
        }

        [TestMethod]
        public void TestVote_Unsuccessful_BadCandidate()
        {
            string expectedResult = "Invalid Candidate(s)";
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            Assert.AreEqual(expectedResult, 
                testElection.ProcessVote(12345, new List<string>() { "Bilbo Baggins" }));
        }

        [TestMethod]
        public void TestVote_Unsuccessful_BadCandidate_Multiple()
        {
            string expectedResult = "Invalid Candidate(s)";
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            Assert.AreEqual(expectedResult,
                testElection.ProcessVote(12345, new List<string>() {"Zak Kastl", "Bilbo Baggins" }));
        }

        [TestMethod]
        public void TestVote_Unsuccessful_IneligibleVoter()
        {
            string expectedResult = "This User is not eligible to vote.";
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            Assert.AreEqual(expectedResult,
                testElection.ProcessVote(00000, new List<string>() { "Zak Kastl" }));
        }

        [TestMethod]
        public void TestVote_Unsuccessful_VotedTwice()
        {
            string expectedResult = "User cannot vote more than once per election";
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            testElection.ProcessVote(12345, new List<string>() { "Zak Kastl" });

            Assert.AreEqual(expectedResult,
                testElection.ProcessVote(12345, new List<string>() { "Zak Kastl" }));
        }

        [TestMethod]
        public void Test_AllVotersVoted_True()
        {
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            foreach (int voter in eligibleVoters)
                testElection.ProcessVote(voter, new List<string>() { "Zak Kastl" });

            Assert.IsTrue(testElection.HaveAllVotersVoted());
        }

        [TestMethod]
        public void Test_AllVotersVoted_False()
        {
            Election testElection = new Election("TEST ELECTION",
                eligibleVoters, 1, candidates);

            Assert.IsFalse(testElection.HaveAllVotersVoted());
        }
    }
}
