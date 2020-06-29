using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockDAO.Entities
{
    public class Category
    {
        public Int64 Id { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
