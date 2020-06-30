using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockDAO.Entities
{
    public class HolderLocationTransaction
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }

            set { _Id = Guid.NewGuid().ToString(); }
        }

        [ForeignKey(nameof(HolderInformation))]
        public Int64 HolderId { get; set; }

        public HolderInformation HolderInformation { get; set; }

        [ForeignKey(nameof(Location))]
        public Int64 LocationId { get; set; }
        public Location Location { get; set; }


        public DateTime DateOfTransaction { get; set; }


    }
}
