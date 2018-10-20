using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RouteAPI.Models;

namespace RouteAPI.Data
{
    public class RouteRepository : IRouteRepository
    {
        private readonly DataContext _context;
        public RouteRepository(DataContext context)
        {
            _context = context;

        }
        public void add<T>(T entity) where T : class
        {
            _context.Add(entity); ;
        }

        public void delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Delivery>> getUnassignDelivery(string transdate)
        {
            var tempDate = DateTime.Parse(transdate);
            var delivery = await _context.Delivery.Include(c => c.Customer).Where(d => d.status == "unassign" && d.transDate == tempDate).ToListAsync();
            return delivery;
        }
        public async Task<IEnumerable<Delivery>> getWaitToSendDelivery(string transdate, string carcode)
        {
            var tempDate = DateTime.Parse(transdate);
            var delivery = await _context.Delivery.Include(c => c.Customer).Where(d => d.status == "รอส่ง" && d.transDate == tempDate && d.carCode == carcode).ToListAsync();
            return delivery;
        }

        public async Task<Delivery> getDelivery(string id)
        {
            var delivery = await _context.Delivery.Include(c => c.Customer).FirstOrDefaultAsync(d => d.deliveryId == id);
            return delivery;
        }
        public async Task<bool> saveAll()
        {
            return await _context.SaveChangesAsync() > 0;

        }
    }
}