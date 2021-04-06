using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Block1Uebung2.Models;

namespace Block1Uebung2.ViewModels {
    class TeamMemberViewModel : INotifyPropertyChanged {

        public ObservableCollection<TeamMember> team1 = new ObservableCollection<TeamMember>();
        public ObservableCollection<TeamMember> team2 = new ObservableCollection<TeamMember>();

        private TeamMember selectedTeamMember1Dummy;

        public TeamMember SelectedTeamMember1Dummy
        {
            get => selectedTeamMember1Dummy;
            set
            {
                if (selectedTeamMember1Dummy != value)
                {
                    selectedTeamMember1Dummy = value;
                    RaisePropertyChanged();
                   
                }
            }
        }
        


        public TeamMemberViewModel() {
            FillTeam1();
            InitializeTeam2();
            ChangeTeam1Command = new MyICommand(OnChange1, CanChange1);
            ChangeTeam2Command = new MyICommand(OnChange2, CanChange2);
        }

        public ObservableCollection<TeamMember> Team1 {
            get;
            set;
        }

        public ObservableCollection<TeamMember> Team2 {
            get;
            set;
        }

        private void FillTeam1() {
            team1.Add(new TeamMember { MemberName = "Johannes" });
            team1.Add(new TeamMember { MemberName = "Tino" });
            team1.Add(new TeamMember { MemberName = "Marina" });
            team1.Add(new TeamMember { MemberName = "Lisa" });
            team1.Add(new TeamMember { MemberName = "George" });
            team1.Add(new TeamMember { MemberName = "Biene" });
            team1.Add(new TeamMember { MemberName = "Markus" });
            team1.Add(new TeamMember { MemberName = "Emelie" });
            team1.Add(new TeamMember { MemberName = "Sven" });
            team1.Add(new TeamMember { MemberName = "Judy" });

            Team1 = team1;
        }

        private void InitializeTeam2() {
            Team2 = team2;
        }


        // von Team 1 zu Team 2 wechseln
        public MyICommand ChangeTeam1Command {
            get;
            set;
        }

        private TeamMember _selectedTeamMember1;
        public TeamMember SelectedTeamMember1 { 
            get {
                return _selectedTeamMember1;
            }
            set {
                _selectedTeamMember1 = value;
                RaisePropertyChanged();
                ChangeTeam1Command.RaiseCanExecuteChanged();
            }
            
        }

        public void OnChange1() {
            Team2.Add(SelectedTeamMember1);
            Team1.Remove(SelectedTeamMember1);
        }

        public bool CanChange1() {
            return SelectedTeamMember1 != null;
        }

        // von Team 2 zu Team 1 wechseln
        public MyICommand ChangeTeam2Command {
            get;
            set;
        }

        private TeamMember _selectedTeamMember2;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TeamMember SelectedTeamMember2 {
            get {
                return _selectedTeamMember2;
            }
            set {
                _selectedTeamMember2 = value;
                ChangeTeam2Command.RaiseCanExecuteChanged();
            }
        }

        public void OnChange2() {
            Team1.Add(SelectedTeamMember2);
            Team2.Remove(SelectedTeamMember2);

        }
        public bool CanChange2() {
            return SelectedTeamMember2 != null;
        }


    }
}
