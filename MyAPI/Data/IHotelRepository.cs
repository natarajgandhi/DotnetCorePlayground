using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Data
{
    public interface IHotelRepository
    {
        public List<Hotel> GetAllHotels();
        public Task<List<Hotel>> GetAllHotelsAsync(bool includeLocation = true);

        public Task<Hotel> GetHotelByName(string name);

        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
