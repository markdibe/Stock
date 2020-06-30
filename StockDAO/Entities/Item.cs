using StockDAO.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockDAO.Entities
{
    public class Item
    {
        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = Guid.NewGuid().ToString() + "-" + Name;
            }
        }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public Int64 CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [BarCode]
        public string BarCode { get; set; }

    }
}
