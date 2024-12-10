using FTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanonFT_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AgentController : ControllerBase
    {
        [HttpPost(Name = "CreateAgent")]
        public string CreateAgent(Agent agent)
        {
            return "GUID";
        }

        [HttpPost("{aid:int}", Name = "UpdateAgent")]
        public void UpdateAgent(string update)
        {
            return;
        }

        [HttpGet("{aid:int}/Status", Name = "RetrieveAgentStatus")]
        public AgentStatus RetrieveAgentStatus(int aid)
        {
            return AgentStatus.Offline;
        }

        [HttpDelete("{aid:int}", Name = "DeleteAgent")]
        public void DeleteAgent(int aid)
        {
            return;
        }

        [HttpGet("{aid:int}/Config", Name = "RetrieveAgentConfig")]
        public string RetrieveAgentConfig(int aid)
        {
            return "Config";
        }
    }
}
