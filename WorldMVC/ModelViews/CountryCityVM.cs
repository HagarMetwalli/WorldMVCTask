using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldMVC.ModelViews
{
    public class CountryCityVM
    {

        public City City { get; set; }
        public List<Country> Countries { get; set; }
    }
}