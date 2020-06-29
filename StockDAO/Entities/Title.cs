using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockDAO.Entities
{
    public class Title
    {
        public int TitleId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(3),MaxLength(50)]
        public string Name { get; set; }


    }
}
