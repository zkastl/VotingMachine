using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingMachineCore
{
    public class Election
    {
        public Guid ElectionId { get; private set; }
        public Dictionary<int, List<string>> Vote { get; private set; }
        public string Title { get; private set; }
        public List<int> EligibleVoters { get; private set; }
        public List<string> Candidates { get; private set; }
        public int CandidateCount { get; private set; }

        public Election(string title, List<int> eligibleVoters, int candidateCount = 1, List<string> candidates = null)
        {
            ElectionId = Guid.NewGuid();
            Vote = new Dictionary<int, List<string>>();
            Title = title;
            EligibleVoters = new List<int>(eligibleVoters);
            Candidates = candidates ?? new List<string>();
            CandidateCount = candidateCount;
        }

        public string ProcessVote(int voterId, List<string> candidates)
        {
            if (!EligibleVoters.Contains(voterId))
                return "This User is not eligible to vote.";
            else if (candidates.Where(x => !Candidates.Contains(x)).Count() > 0)
                return "Invalid Candidate(s)";
            else if (Vote.ContainsKey(voterId))
                return "User cannot vote more than once per election";
            else
            {
                Vote.Add(voterId, candidates);
                return "Vote Accepted!";
            }
        }

        public bool HaveAllVotersVoted() =>
            EligibleVoters.Where(x => !Vote.ContainsKey(x)).Count() == 0;
    }
}
