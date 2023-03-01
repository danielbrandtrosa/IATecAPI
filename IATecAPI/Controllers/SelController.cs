using IATecAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IATecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<SelModel>> GetSel(int id)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult<SelModel> UpDateSel()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<SelModel> RecordSel()
        {
            return Ok();
        }
    }
}
