using AutoMapper;
using AutoMapper.QueryableExtensions;
using WebShop.API.Data;
using WebShop.API.Helpers;
using WebShop.API.Models.Entities;
using WebShop.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.API.Controllers
{
    [Route("shop/[controller]")]
    [ApiController]
    public class ShopItemController : Controller
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ShopItemController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ShopItemViewModel> Get()
        {
            return _context.ShopItems
                .ProjectTo<ShopItemViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        [HttpGet("{id}")]
        public ShopItemViewModel Get(int id)
        {
            return _context.ShopItems
                .Where(x => x.Id == id)
                .ProjectTo<ShopItemViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ShopItemViewModel viewModel)
        {
            var entity = _mapper.Map<ShopItem>(viewModel);

            _context.ShopItems.Update(entity);

            _context.SaveChanges();

            return Ok(entity.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _context.ShopItems.Find(id);

            if (entity != null)
            {
                _context.ShopItems.Remove(entity);

                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
