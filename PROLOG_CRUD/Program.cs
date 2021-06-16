using System;
using System.Collections.Generic;
using System.Linq;

namespace PROLOG_CRUD
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public int Stock { get; set; }

        public Beer(int Id, string Name, int Cost, int Stock)
        {
            this.Id = Id;
            this.Name = Name;
            this.Cost = Cost;
            this.Stock = Stock;
        }

        public Beer(){ }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Beer> beersList = new List<Beer>();

            // -----CREATE
            beersList.Add(new Beer() { Id = 1, Name = "Corona", Cost = 15, Stock = 48 });
            beersList.Add(new Beer() { Id = 2, Name = "Estrella", Cost = 10, Stock = 24 });
            beersList.Add(new Beer() { Id = 3, Name = "Stout", Cost = 3, Stock = 12 });
            beersList.Add(new Beer() { Id = 4, Name = "Viena", Cost = 4, Stock = 6 });
            beersList.Add(new Beer() { Id = 5, Name = "Sol", Cost = 20, Stock = 8 });
            beersList.Add(new Beer() { Id = 6, Name = "Indio", Cost = 15, Stock = 10 });
            beersList.Add(new Beer() { Id = 7, Name = "Tecate", Cost = 2, Stock = 10 });

            int Id = 8;
            string Name = "Ambar";
            int Cost = 25;
            int Stock = 24;

            Beer beerObject = new Beer(Id, Name, Cost, Stock);
            beersList.Add(beerObject);

            // -----READ
                var Read1 = beersList
                    .Where(d => d.Id == 6)
                    .Select(d => new { Id = d.Id, Name = d.Name, Cost = d.Stock }).ToList();

                var Read2 = beersList
                    .Where(d => d.Id == 1)
                    .Select(d => new { Id = d.Id, Name = d.Name, Cost = d.Cost, d.Stock }).ToList();

                string strRead1 = string.Join(Environment.NewLine, Read1);
                string strRead2 = string.Join(Environment.NewLine, Read2);

                Console.WriteLine(strRead1+"\n");
                Console.WriteLine(strRead2+"\n");
            //------

            // ---UPDATE
            beersList.First(d => d.Id == 7).Name = "Tecate Light";
            beersList.First(d => d.Id == 2).Name = "Dos Equis";

            //---DELETE
            // This will remove the part at index 7.
            beersList.RemoveAt(7);


            /// <sumary>
            /// Get the number of rows in the inventory
            /// </sumary>
            
            int totalRows = 0;
            var BeerBrand = beersList.
                Select(d => new {NameBeer = d.Id}).ToList();
                totalRows = BeerBrand.Count();
            Console.WriteLine("Get the number of rows in the inventory: " + totalRows);


            ///<summary
            /// Get all the products that cost more than 5
            ///</summary>
            
            int totalGetCost = 0;
            var BeerBrandCost = beersList.
                Where(d => d.Cost > 5).ToList();

            totalGetCost = BeerBrandCost.Count();
            Console.WriteLine("\nGet all the products that cost more than 5: "+totalGetCost);


            ///<summary
            /// Sum the number of products in the inventory
            ///</summary>
 
            var BeerSum = beersList.Sum(d =>d.Stock).ToString();
            Console.WriteLine("\nSum the number of products in the inventory: " + BeerSum);

        }


    }
}
