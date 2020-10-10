using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;
namespace Entities
{
    public class Menu : BaseEntity
    {
        public ICollection<Item> Items { get; set; }
    }
}