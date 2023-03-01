using IATecAPI.Models;
using IATecAPI.Repository;
using IATecAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IATecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelController : ControllerBase
    {   
        #region CONST e PRIV

        private readonly ISelRepository _selRepository;
        public SelController(ISelRepository selRepository)
        {
            _selRepository = selRepository;
        }
        #endregion

       #region GETs
        [HttpGet("{id}")]
        public async Task<ActionResult<SelModel>> GetById(int id)
        {
            SelModel sel = await _selRepository.GetById(id);
            if (sel == null)
                return NotFound();

            return Ok(sel);
        }
        #endregion

        #region PUTs
        [HttpPut("{id}")]
        public async Task<ActionResult<SelModel>> UpDateSel([FromBody] SelModel selModel, int id)
        {
            SelModel sel = await _selRepository.GetById(id);
            if (sel == null)
                return NotFound();

            selModel.Id = id;

            sel = await _selRepository.UpdateStatus(selModel, id);
            return Ok(sel);
            //ou NoContent(); 
        }
        #endregion

        #region POSTs
        [HttpPost]
        public async Task<ActionResult<SelModel>> AddSel([FromBody] SelModel selModel)
        {
            SelModel sel = await _selRepository.Add(selModel);
             return Ok(sel);
            //code 201=created 
        }
        //obs: validar com HttpResponseMessage 
        #endregion
    }
}
