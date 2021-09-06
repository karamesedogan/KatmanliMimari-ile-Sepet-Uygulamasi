using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.DomainModels
{

    //Sepet Detayı
    public class CartLine:IDomainModel
    {
        public Product  Product { get; set; }
        public int? Quantity { get; set; }
    }
}
