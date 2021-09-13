using Microsoft.AspNetCore.Mvc;
using ShowCase.Models;
using ShowCaseAPI.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCaseAPI.DTO
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
