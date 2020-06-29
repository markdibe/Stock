using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Text;

namespace StockDAO.Entities
{
    public class ItemImages
    {
        private string _Id;
        [Key]
        public string Id
        {
            get { return _Id; }
            set { _Id = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToString(); }
        }

        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }
        public Image Image { get; set; }

        [ForeignKey(nameof(Item))]
        public string ItemId { get; set; }
        public Item Item { get; set; }
    }
}
