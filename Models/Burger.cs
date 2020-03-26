using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
    public class Burger
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }


        [Required]
        [MaxLength(140)]
        public string Description { get; set; }


        [Range(1, 10000)]
        public float Price { get; set; }
        public string Id { get; set; }

        public Burger()
        {
            Id = Guid.NewGuid().ToString();
        }

        // NOTE No constructors for API's
        public Burger(string name, string description, float price)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = Guid.NewGuid().ToString();
        }
    }

}