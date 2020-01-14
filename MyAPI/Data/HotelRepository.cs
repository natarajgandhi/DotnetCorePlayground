using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Data
{
    public class HotelRepository : IHotelRepository
    {
        public HotelRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public HotelContext _hotelContext { get; }

        public void Add<T>(T entity) where T : class
        {
            //_logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _hotelContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            //_logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _hotelContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //_logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _hotelContext.SaveChangesAsync()) > 0;
        }

        public List<Hotel> GetAllHotels()
        {
            var hotels = (from h in _hotelContext.Hotels
                          select h).ToList();
            return hotels;
        }

        public async Task<List<Hotel>> GetAllHotelsAsync(bool includeLocation = true)
        {
            if (includeLocation)
            {
                return await _hotelContext.Hotels.Include(l => l.Location).ToListAsync();
            }
            return await _hotelContext.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            var hotel = await _hotelContext.Hotels.SingleOrDefaultAsync(h => h.Name.Equals(name));
            return hotel;

        }

    }
}
