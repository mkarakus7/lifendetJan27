using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basRepo;

        public BasketController(IBasketRepository basRepo)
        {
            _basRepo = basRepo;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>>
                GetBasketById(string id)
        {
            var basket = await _basRepo.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>>
                UpdateBasket(CustomerBasket basket)
        {
            var updateBasket = await _basRepo.UpdateBasketAsync(basket);
            return Ok(updateBasket);
        }

        [HttpDelete]
        public async Task
                DeleteBasketAsync(string id)
        {
             await _basRepo.DeleteBasketAsync(id);
           
        }

    }
}