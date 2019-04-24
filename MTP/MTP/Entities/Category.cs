using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTP.Entities
{
    public class Category
    {
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
