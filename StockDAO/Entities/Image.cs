using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockDAO.Entities
{
    public class Image
    {


        private string _Id;
        [Key]
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

        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(250)]
        [MinLength(4)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
