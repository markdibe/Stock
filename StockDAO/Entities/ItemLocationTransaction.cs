using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockDAO.Entities
{
    public class ItemLocationTransaction
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                _Id = this.ItemId.ToString() +
                  "-" + this.LocationId.ToString() +
                  "-" + DateTime.Now.ToString();
            }
        }

        [ForeignKey(nameof(Item))]
        public Int64 ItemId { get; set; }

        [ForeignKey(nameof(Location))]
        public Int64 LocationId { get; set; }

        public Item Item { get; set; }
        public Location Location { get; set; }

        private DateTime _date;
        public DateTime DateOfTransaction { get { return _date; } set { _date = DateTime.Now; } }

    }
}
