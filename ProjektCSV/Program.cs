using System;
using System.Collections.Generic;


namespace ProjektCSV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var houseList = new List<House>()
        {
            new House(){Id = 10, Surface =150, Name = "Guest House", IsFlat = true, Description = "Some, description" },
            new House(){Id = 12, Surface =110, Name = "Apartment", IsFlat = false, Description = "Some, description" },
            new House(){Id = 21, Surface =78, Name = "Tree House", IsFlat = true, Description = "Some, description" },
            new House(){Id = 31, Surface =90, Name = "Garage", IsFlat = false, Description = "Some, description" },
            new House(){Id = 14, Surface =96, Name = "Play House", IsFlat = true, Description = "Some, description" }
        };
            var humanList = new List<Human>()
        {
            new Human(){Id = 10, BirthDate = new DateTime(2015,11,23), Height = 192},
            new Human(){Id = 12, BirthDate = new DateTime(1992,05,17), Height = 187},
            new Human(){Id = 21, BirthDate = new DateTime(1993,05,14), Height = 173},
            new Human(){Id = 31, BirthDate = new DateTime(1928,02,25), Height = 176},
            new Human(){Id = 14, BirthDate = new DateTime(2017,03,02), Height = 165}
        };
            //CsvTools.AppendToCsvFile<Human>(humanList, "Human.csv");
            //CsvTools.AppendToCsvFile<House>(houseList, "House.csv",";");
            //Console.WriteLine(CsvTools.ReadCsv("House.csv",";")); 
            //Console.Read();
        }

    }
}
