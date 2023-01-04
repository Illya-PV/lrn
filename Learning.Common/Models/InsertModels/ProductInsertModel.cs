using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Common.Models.InsertModels
{
    public class ProductInsertModel
    {
        public int Price { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}
