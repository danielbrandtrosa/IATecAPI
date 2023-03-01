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
        private readonly ISellerRepository _sellerRepository;
        public SellerController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }



        [HttpGet()]
        public async Task<ActionResult<List<SellerModel>>> GetAllSeller()
        {
            List<SellerModel> lstSellers = await _sellerRepository.GetAll();
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

        [HttpPost]
        public async Task<ActionResult<SellerModel>> AddSeller([FromBody] SellerModel sellerModel)
        {
            SellerModel seller = await _sellerRepository.Add(sellerModel);
            //Validar CPF já cadastrado
            return Ok(seller);
            //code 201=created    
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SellerModel>> UpDateSeller([FromBody] SellerModel sellerModel, int id)
        {
            SellerModel seller = await _sellerRepository.GetById(id);
            if (seller == null)
                return NotFound();

            sellerModel.Id = id;
            //Validar CPF já cadastrado
            seller = await _sellerRepository.Update(sellerModel, id);
            return Ok(seller);
            //ou NoContent();   
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SellerModel>> DeleteSeller(int id)
        {
            bool apagado = await _sellerRepository.Delete(id);
            return Ok(apagado);
        }
        
    }
}
