using System;
using System.Collections.Generic;

namespace JollyAPI.Models.Entity
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
