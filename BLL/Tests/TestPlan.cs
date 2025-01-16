using BLL.Customers;

namespace BLL.Tests
{
    public class TestPlan
    {
        private List<Tuple<TestAction, Server>> Steps;

        public TestPlan()
        {
            Steps = new List<Tuple<TestAction, Server>>();
        }

        public TestPlan(List<Tuple<TestAction, Server>> steps)
        {
            Steps = steps;
        }

        public void AddStep(TestAction executeAction, Server executeOn)
        {
            Steps.Add(new Tuple<TestAction, Server>(executeAction, executeOn));
        }

        public List<TestAction> ActionsPerServer(Server server)
        {
            return ActionsPerServer(server.GUID);
        }

        public List<TestAction> ActionsPerServer(string guid)
        {
            List<TestAction> actions = new List<TestAction>();
            foreach (Tuple<TestAction, Server> step in Steps)
            {
                if (step.Item2.GUID.Equals(guid))
                {
                    actions.Add(step.Item1);
                }
            }
            return actions;
        }
    }
}
