using JiPP_2.Data;
using JiPP_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JiPP_2.Repositories
{
    public class RentManager
    {
        public class VehicleAlreadyRentedException : Exception { 
            public VehicleAlreadyRentedException() { }
        }


        private ApplicationDbContext _context;

        public RentManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool isVehicleRentedBetween(int vehicleId, DateTime d1, DateTime d2)
        {
            if (d1 > d2)
                (d1, d2) = (d2, d1);
            return _context.Rents.Where(a => a.VehicleId == vehicleId).Where(a => a.Status != RentModel.RentStatus.CANCELLED && a.StartDate <= d2 && (a.ReturnDate??a.EndDate) >= d1).Any();
        }

        public RentManager AddRent(RentModel rentModel)
        {
            if(!isVehicleRentedBetween(rentModel.VehicleId, rentModel.StartDate, rentModel.EndDate))
            {
                _context.Rents.Add(rentModel);
                _context.SaveChanges();
            } else
            {
                throw new VehicleAlreadyRentedException();
            }
            return this;
        }

        public RentManager RemoveRent(RentModel rentModel)
        {
            _context.Rents.Remove(rentModel);
            _context.SaveChanges();
            return this;
        }

        public RentManager UpdateRent(RentModel rentModel)
        {
            _context.Rents.Update(rentModel);
            Debug.Write(rentModel.ToString());
            _context.SaveChanges();
            return this;
        }

        public RentModel GetRent(int id)
        {
            return _context.Rents
                .Include(a => a.Vehicle)
                    .ThenInclude(a => a.Vendor)
                .Include(a => a.Customer)
                .SingleOrDefault(rent => rent.Id == id);
        }

        public List<RentModel> GetRents()
        {
            return _context.Rents
                .Include(a => a.Vehicle)
                    .ThenInclude(a => a.Vendor)
                .Include(a => a.Customer)
                .ToList();
        }

        public List<CustomerModel> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public List<VehicleModel> GetVehicles()
        {
            return _context.Vehicles.Include(a => a.Vendor).ToList();
        }

    }
}