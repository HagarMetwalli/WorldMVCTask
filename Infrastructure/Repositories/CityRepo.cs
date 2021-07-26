using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.IRepositories;
using DataModel.Models;

namespace Infrastructure.Repositories
{
    public class CityRepo : IGeneric<City>
    {
        private WorldDBEntities _db;

        public CityRepo(WorldDBEntities db)
        {
            _db = db;
        }
        public City Create(City city)
        {
            try
            {
                if (city == null)
                {
                    return null;
                }

                _db.Cities.Add(city);
                int affected = _db.SaveChanges();

                if (affected == 1)
                {
                    return city;
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                City city = RetriveById(id);
                if (city == null)
                {
                    return false;
                }
                _db.Cities.Remove(city);
                int affected = _db.SaveChanges();

                if (affected == 1)
                {
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }

        }

        public City Patch(City entity)
        {
            try
            {

                City city = RetriveById(entity.Id);
                if (city == null)
                {
                    return null;
                }
                city.CityName = entity.CityName;
                city.CountryId = entity.CountryId;
                int affected = _db.SaveChanges();
                if (affected == 1)
                {
                    return city;
                }
                return null;

            }
            catch
            {
                return null;
            }
        }

        public City RetriveById(int id)
        {
            try
            {
                return _db.Cities.Include("Country").Single(i => i.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public List<City> RetriveAll()
        {
            try
            {
                return _db.Cities.Include("Country").ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
