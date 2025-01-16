using BLL.Agents;
using BLL.Customers;
using BLL.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mock
{
    public class AgentRepositoryMock : IAgentRepository
    {
        private ICustomerRepository _CustomerRepository;

        private List<Agent> _Agents = new List<Agent>();

        public IReadOnlyList<Agent> Agents { get { return _Agents.AsReadOnly(); } }

        public AgentRepositoryMock(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
            
            Server? server = _CustomerRepository.RetrieveServer("TESTSERVER");
            if(server == null)
            {
                //TODO if the server can't be found, the agent should not exist either
            } else
            {
                Agent agent1 = new Agent("Tester", server);
                agent1.GUID = "111111";
                agent1.HeartBeat = DateTime.Now;

                // Find the customer to which the server belongs to
                Customer? c = _CustomerRepository.FindByServer(agent1.InstallationServer);
                if (c == null)
                {
                    //TODO: if the customer can't be found, the agent should not exist
                    //Delete(agent1);
                }
                else
                {
                    agent1.Configuration = c.Testplan.ActionsPerServer(agent1.InstallationServer);
                    _Agents.Add(agent1);
                }
            }



        }

        public string Create(Agent agent)
        {
            _Agents.Add(agent);
            return agent.GUID;
        }

        public bool Delete(Agent agent)
        {
            Agent? existingAgent = Retrieve(agent.GUID);
            if (existingAgent != null)
            {
                return _Agents.Remove(existingAgent);
            }
            return false;
        }

        public Agent? Retrieve(string GUID)
        {
            foreach (Agent agent in _Agents)
            {
                if (agent.GUID == GUID) return agent;
            }
            return null;
        }

        public bool Update(Agent agent)
        {
            Delete(agent);
            Create(agent);
            return true;
        }
    }
}
