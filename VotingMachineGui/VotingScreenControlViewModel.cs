using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingMachineCore;
using SlimBindableCommand;
using System.Collections.ObjectModel;

namespace VotingMachineGui
{
    public class VotingScreenControlViewModel : ProtoBind
    {
        public string ElectionName
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public string NumberToElect
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public string MultiSelect
        {
            get { return ObservableGet<string>(); }
            set { ObservableSet(value); }
        }

        public ObservableCollection<string> Candidates
        {
            get { return ObservableGet<ObservableCollection<string>>(); }
            set { ObservableSet(value); }
        }

        public Election CurrentElection { get; private set; }

        public VotingScreenControlViewModel()
        {
            var eligibleVoters = new List<int>()
            {
                12345,
                67890,
                13579,
                24680,
                10293,
                48576
            };
            var candidates = new List<string>()
            {
                "Zak Kastl",
                "Vy Vo",
                "Aaron Beal",
                "Barry Hunt"
            };

            CurrentElection = new Election("State Warden", eligibleVoters, 2, candidates);
            ElectionName = CurrentElection.Title;
            NumberToElect = string.Format("Please vote for {0} candidate(s)", CurrentElection.CandidateCount);
            MultiSelect = "Multiple";
        }
    }
}
