using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Christiansoe.Models
{
    public class Route
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Theme { get; set; }

        public double Length { get; set; }

        public int HikingTime { get; set; }

        public string Description { get; set; }

        public BingoBoard BingoBoard { get; set; }

        public Map Map { get; set; }







    }
}
