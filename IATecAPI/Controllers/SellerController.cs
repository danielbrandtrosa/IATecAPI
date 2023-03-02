using IATecAPI.Extensions;
using IATecAPI.Models;
using IATecAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IATecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        #region CONST e PRIV

        private readonly ISellerRepository _sellerRepository;
        public SellerController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        #endregion

        #region GETs
        [HttpGet()]
        public async Task<ActionResult<List<SellerModel>>> GetAllSeller()
        {
            List<SellerModel> lstSellers = await _sellerRepository.GetAll();
            if (lstSellers == null && lstSellers.Count() == 0)
                return NotFound();
            return Ok(lstSellers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SellerModel>>> GetSellerById(int id) 
        {
            SellerModel seller = await _sellerRepository.GetById(id);
            if (seller == null)
                return NotFound();

            return Ok(seller);
        }
        #endregion

        #region POSTs

        [HttpPost]
        public async Task<ActionResult<SellerModel>> AddSeller([FromBody] SellerModel sellerModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            try
            {
                SellerModel seller = await _sellerRepository.Add(sellerModel);
                //Validar CPF já cadastrado(consultar)

                return Ok(seller);
                //code 201=created    
            }
            catch (Exception)
            {
                return BadRequest("Problems with adding the saller, contact the administrator.");
            }        
            
        }
        #endregion

        #region PUTs

        [HttpPut("{id}")]
        public async Task<ActionResult<SellerModel>> UpDateSeller([FromBody] SellerModel sellerModel, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            try
            {
                SellerModel seller = await _sellerRepository.GetById(id);
                if (seller == null)
                    return NotFound();

                sellerModel.Id = id;
                //Validar CPF já cadastrado(cpf não se muda)
                seller = await _sellerRepository.Update(sellerModel, id);
                return Ok(seller);
                //ou NoContent();   

            }
            catch (Exception)
            {
                return BadRequest("Problems with update the saller, contact the administrator.");
            }
        }
        #endregion

        #region DELETEs
        [HttpDelete("{id}")]
        public async Task<ActionResult<SellerModel>> DeleteSeller(int id)
        {
            SellerModel seller = await _sellerRepository.GetById(id);
            if (seller == null)
                return NotFound();

            bool apagado = await _sellerRepository.Delete(id);
            return Ok(apagado);
        }
        #endregion 
    }
}
