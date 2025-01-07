using BLL.Customers;
using BLL.Tests;
using Microsoft.AspNetCore.Mvc;

namespace CanonFT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(ITestRepository testRepository) : ControllerBase
    {
        private ITestRepository _TestRepository = testRepository;

        [HttpGet(Name = "RetrieveTests")]
        public IActionResult RetrieveTests()
        {
            return Ok(_TestRepository.Tests);
        }

        [HttpPost(Name = "CreateTest")]
        public IActionResult CreateTest(Test test)
        {
            return Ok(_TestRepository.Create(test));
        }

        [HttpGet("{tid}", Name = "RetrieveTest")]
        public IActionResult RetrieveTest([FromRoute] string tid)
        {
            Test? test = _TestRepository.Retrieve(tid);
            if (test == null) return NotFound();
            return Ok(test);
        }

        [HttpPut("{tid}", Name = "UpdateTest")]
        public IActionResult UpdateTest([FromRoute] string tid, Test test)
        {
            if (test.TestType != tid) return BadRequest();
            return Ok(_TestRepository.Update(test));
        }

        [HttpDelete("{tid}", Name = "DeleteTest")]
        public IActionResult DeleteTest([FromRoute] string tid)
        {
            Test? test = _TestRepository.Retrieve(tid);
            if (test == null) return NotFound();
            return Ok(_TestRepository.Delete(test));
        }
    }
}
