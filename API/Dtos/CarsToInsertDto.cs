using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CarsToInsertDto
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public string Make { get; set; }
    }
}