using BLL.Agents;
using BLL.Customers;
using BLL.Tests;
using BLL.Tests.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CanonFT_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AgentController(IAgentRepository agentRepository, IResultRepository resultRepository) : ControllerBase
    {
        private IAgentRepository _AgentRepository = agentRepository;
        private IResultRepository _ResultRepository = resultRepository;

        [HttpPost(Name = "CreateAgent")]
        public IActionResult CreateAgent(Agent agent)
        {
            return Ok(_AgentRepository.Create(agent));
        }

        [HttpGet("{guid}", Name = "RetrieveAgent")]
        public IActionResult RetrieveAgent([FromRoute] string guid)
        {
            Agent? agent = _AgentRepository.Retrieve(guid);
            if (agent != null)
            {
                return Ok(agent);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{guid}", Name = "UpdateAgent")]
        public IActionResult UpdateAgent([FromRoute] string guid, Agent agent)
        {
            if (agent.GUID != guid) return BadRequest();
            return Ok(_AgentRepository.Update(agent));
        }

        [HttpDelete("{guid}", Name = "DeleteAgent")]
        public IActionResult DeleteAgent([FromRoute] string guid)
        {
            Agent? agent = _AgentRepository.Retrieve(guid);
            if (agent == null)
            {
                return NotFound();
            }

            if (_AgentRepository.Delete(agent))
            {
                return Ok();
            }

            return StatusCode(500, "Internal server error");
        }

        [HttpPost("{guid}/Heartbeat", Name = "PostHeartbeat")]
        public IActionResult PostHeartbeat([FromRoute] string guid, DateTime heartbeat)
        {
            Agent? agent = _AgentRepository.Retrieve(guid);
            if (agent == null)
            {
                return NotFound();
            }
            agent.HeartBeat = heartbeat;
            return Ok(_AgentRepository.Update(agent));
        }

        [HttpPost("{guid}/Result", Name = "PostTestResult")]
        public IActionResult PostTestResult([FromRoute] string guid, Result result)
        {
            if (result.Reporter != guid) return BadRequest();

            if (resultRepository.Create(result))
            {
                return Ok(_ResultRepository.Create(result));
            }
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{guid}/Status", Name = "RetrieveAgentStatus")]
        public IActionResult RetrieveAgentStatus([FromRoute] string guid)
        {
            Agent? agent = _AgentRepository.Retrieve(guid);
            if(agent != null)
            {
                return Ok(agent.Status);
            } else
            {
                return NotFound();
            }
        }

        [HttpGet("{guid}/Config", Name = "RetrieveAgentConfig")]
        public IActionResult RetrieveAgentConfig([FromRoute] string guid)
        {
            Agent? agent = _AgentRepository.Retrieve(guid);
            if (agent != null)
            {
                return Ok(agent.Configuration);
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
