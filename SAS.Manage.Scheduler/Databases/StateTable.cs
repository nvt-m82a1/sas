using SAS.Manage.Scheduler.Databases.Entities;

namespace SAS.Manage.Scheduler.Databases
{
    internal class StateTable
    {
        public StateTable Instance = new StateTable();
        private StateTable()
        {
            States = new List<State>();
        }

        public ICollection<State> States { get; set; }
    }
}
