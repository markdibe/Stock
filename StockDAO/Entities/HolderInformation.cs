using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Numerics;
using System.Text;

namespace StockDAO.Entities
{
    public class HolderInformation
    {
        public Int64 Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string NumberOfRegistration { get; set; }

        public string LocationOfRegistration { get; set; }

        [Required]
        [ForeignKey(nameof(Title))]
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }

    }
}
