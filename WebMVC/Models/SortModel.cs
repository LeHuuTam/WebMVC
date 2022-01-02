using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class SortModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SortModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}