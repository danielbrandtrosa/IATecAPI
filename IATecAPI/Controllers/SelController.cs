using IATecAPI.Extensions;
using IATecAPI.Models;
using IATecAPI.Repository;
using IATecAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            try
            {
                SelModel sel = await _selRepository.GetById(id);
                if (sel == null)
                    return NotFound();

                if (sel.BlockUpdate(selModel.Status))
                {
                    return BadRequest("Invalid new Status");//Aviso, ação não permitida
                }


                selModel.Id = id;
                sel = await _selRepository.UpdateStatus(selModel, id);
                return Ok(sel);
                //ou NoContent(); 
            }
            catch (Exception)
            {
                return BadRequest("Problems with get the sale, contact the administrator.");
            }

        }
        #endregion

        #region POSTs
        [HttpPost]
        public async Task<ActionResult<SelModel>> AddSel([FromBody] SelModel selModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            try
            {
                SelModel newSel = selModel;

                if (!newSel.ValidateItem())
                {
                    return BadRequest("Invalid new Status");//Aviso, ação não permitida
                }

                SelModel sel = await _selRepository.Add(selModel);
                 return Ok(sel);
                //code 201=created 
            }
            catch (Exception)
            {
                return BadRequest("Problems with adding the sale, contact the administrator.");
            }

        }
        //obs: validar com HttpResponseMessage 
        #endregion
    }
}
