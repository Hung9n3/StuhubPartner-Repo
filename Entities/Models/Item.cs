
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;
namespace Entities
{
    public class Item : BaseEntity
    {
        public string ItemName { get; set; }
        public bool isFood { get; set; }
        public Menu Menu { get; set; }
    }
}