
using DataModel.IRepositories;
using DataModel.Models;
using Infrastructure.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WorldMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IGeneric<Country>, CountryRepo>();
            container.RegisterType<IGeneric<City>, CityRepo>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}