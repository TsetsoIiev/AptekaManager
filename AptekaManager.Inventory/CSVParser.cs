using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AptekaManager.Internal.Dto;

namespace AptekaManager.Inventory
{
    internal class CSVParser
    {
        private readonly string filePath;

        public CSVParser(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<ProductDto> ParseCSV()
        {
            List<ProductDto> values = File.ReadAllLines(this.filePath)
                                           .Skip(1)
                                           .Select(v => ParseToProduct(v))
                                           .ToList();

            return values;
        }

        private ProductDto ParseToProduct(string csvLine)
        {
            ProductDto result = new();
            string[] values = csvLine.Split(',');

            result.Name = values[0];
            result.Price = decimal.Parse(values[1]);
            result.Quantity= decimal.Parse(values[2]);
            result.Description= values[3];
            result.MeasurementUnitsPerBox= int.Parse(values[4]);
            result.IsSeparableSale = bool.Parse(values[5]);

            return result;
        }
    }
}
