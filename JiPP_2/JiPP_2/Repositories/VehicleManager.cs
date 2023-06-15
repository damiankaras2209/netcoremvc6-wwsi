using JiPP_2.Data;
using JiPP_2.Models;
using Microsoft.EntityFrameworkCore;

namespace JiPP_2.Repositories
{
    public class VehicleManager
    {
        private ApplicationDbContext _context;

        public VehicleManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public VehicleManager AddVehicle(VehicleModel vehicleModel)
        {
            _context.Vehicles.Add(vehicleModel);
            _context.SaveChanges();
            return this;
        }

        public VehicleManager RemoveVehicle(VehicleModel vehicleModel)
        {
            _context.Vehicles.Remove(vehicleModel);
            _context.SaveChanges();
            return this;
        }

        public VehicleManager UpdateVehicle(VehicleModel vehicleModel)
        {
            _context.Vehicles.Update(vehicleModel);
            _context.SaveChanges();
            return this;
        }

        public VehicleModel GetVehicle(int id)
        {
            var vehicle = _context.Vehicles
                .Include(a => a.Vendor)
                .Include(a => a.Transmission)
                .SingleOrDefault(vehicle => vehicle.Id == id);

            var isRented = _context.Rents.Where(b => b.VehicleId == vehicle.Id).Where(b=> b.Status == RentModel.RentStatus.ACTIVE).Any();
            vehicle.isRented = isRented;
            return vehicle;
        }

        public List<VehicleModel> GetVehicles()
        {
            var list =  _context.Vehicles
                .Include(a => a.Vendor)
                .Include(a => a.Transmission)
                .ToList();

            list.ForEach(a => a.isRented = _context.Rents.Where(b => b.VehicleId == a.Id).Where(b => b.Status == RentModel.RentStatus.ACTIVE).Any());
            return list;
        }

        public List<DictionaryDetailModel> GetVendors()
        {
            return _context.DictionaryDetails.Where(dictionaryDetail => dictionaryDetail.Type == DictionaryModel.DictionaryType.VENDOR).ToList();
        }

        public List<DictionaryDetailModel> GetTransmissions()
        {
            return _context.DictionaryDetails.Where(dictionaryDetail => dictionaryDetail.Type == DictionaryModel.DictionaryType.TRANSMISISON).ToList();
        }

    }
}
