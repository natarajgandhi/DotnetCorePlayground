using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using MyAPI.Data;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        public HotelsController(LinkGenerator linkGenerator, IHotelRepository hotelRepository, ILogger<HotelsController> hotelLogger, IMapper mapper)
        {
            LinkGenerator = linkGenerator;
            HotelRepository = hotelRepository;
            HotelLogger = hotelLogger;
            Mapper = mapper;
        }

        public LinkGenerator LinkGenerator { get; }
        public IHotelRepository HotelRepository { get; }
        public ILogger<HotelsController> HotelLogger { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetAllHotels(bool includeLocation = true)
        {
            var hotels = new List<HotelModel>();
            try
            {
                var hotelDBItems = await HotelRepository.GetAllHotelsAsync(includeLocation);
                hotels = Mapper.Map<List<HotelModel>>(hotelDBItems);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Server Error {e.Message}");
            }
            return Ok(hotels);
        }

        [HttpGet("{hotelName}")]
        public async Task<ActionResult<Hotel>> GetHotel(string hotelName)
        {
            var hotel = await HotelRepository.GetHotelByName(hotelName);
            return Ok(hotel);
        }
        [HttpPost]
        public async Task<ActionResult<Hotel>> CreateHotel(HotelModel hotelmodel)
        {
            try
            {
                var location = LinkGenerator.GetPathByAction("Get", "Hotel", new { hotelName = hotelmodel.Name });
                var hotel = Mapper.Map<Hotel>(hotelmodel);
                HotelRepository.Add(hotel);
                await HotelRepository.SaveChangesAsync();
                return Created($"/api/Hotels/{hotel.Name}", Mapper.Map<HotelModel>(hotel));
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Server Error {e.Message}");
            }
            return Ok(new { });
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> Delete(string name)
        {
            var hotel = await HotelRepository.GetHotelByName(name);
            if(hotel != null)
            {
                HotelRepository.Delete(hotel);
                await HotelRepository.SaveChangesAsync();
                return Ok("deleted");
            }
            return Ok();
        }

    }
}