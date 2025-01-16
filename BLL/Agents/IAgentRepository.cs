namespace BLL.Agents
{
    public interface IAgentRepository
    {
        public IReadOnlyList<Agent> Agents { get; }
        public string Create(Agent agent);
        public Agent? Retrieve(string GUID);
        public bool Update(Agent agent);
        public bool Delete(Agent agent);
    }
}
