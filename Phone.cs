using System;
using System.Collections.Generic;
using System.Text;

namespace TelefonCLI
{
    internal class Phone
    {
        static int counter = 1;


        public Phone(string l)
        {
            var r = l.Split(';');
            Brand = new Brand
            {
                BrandID = int.Parse(r[0]),
                BrandName = r[1]
            };
            Model = r[2];
            Year = int.Parse(r[3]);
            Storage = int.Parse(r[4]);
            Price = r[5] == "NA" ? 0 : int.Parse(r[5]);
            OS = new OS
            {
                OSID = int.Parse(r[6]),
                OSName = r[7]
            };
            Battery = r[8];
            Condition = r[9];
            County = r[10];
            Warranty = r[11];
            Sold = r[12];
            PhoneId = counter++;



        }

        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Storage { get; set; }
        public int Price { get; set; }
        public OS OS { get; set; }
        public string Battery { get; set; }
        public string Condition { get; set; }
        public string County { get; set; }
        public string Warranty { get; set; }
        public string Sold { get; set; }
        public int PhoneId { get; set; }


        public double PricePerGB()
        {
            return Math.Round((double)Price / Storage, 2);
        }
        public override string ToString()
        {
            return $"\tPhone ID: {PhoneId}\n" +
                   $"\tBrand: {Brand.BrandName}\n" +
                   $"\tModel: {Model}\n" +
                   $"\tYear: {Year}\n" +
                   $"\tStorage: {Storage} GB\n" +
                   $"\tPrice: {(Price == 0 ? "NA" : Price)}\n" +
                   $"\tOS: {OS.OSName}\n" +
                   $"\tBattery: {Battery}\n" +
                   $"\tCondition: {Condition}\n" +
                   $"\tCounty: {County}\n" +
                   $"\tWarranty: {Warranty}\n" +
                   $"\tSold: {Sold}\n" +
                   $"\tPrice per GB: {PricePerGB()}\n";
        }
    }
}
