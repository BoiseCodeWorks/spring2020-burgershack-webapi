using System.Collections.Generic;
using burgershack.Models;

namespace burgershack.DB
{
    static class FakeDB
    {
        // NOTE THIS IS TEMPORARY DON'T DO THIS!!!!!!!
        public static List<Burger> burgers = new List<Burger>(){
            new Burger("Mark Burger", "Extra Cheesy", 5.03f),
            new Burger("Jake Burger", "Bacon Galore", 5.98f),
            new Burger("D$", "Its suprise mixture of whatever he brings in", 6.03f)
        };

        public static List<Side> sides = new List<Side>(){
            new Side("Tots", "Little baby Idaho's", 1f, Size.sm),
            new Side("Tots", "Little baby Idaho's", 1.5f, Size.md),
            new Side("Tots", "Little baby Idaho's", 2f, Size.lg),
            new Side("Fries", "Little string forms of Idaho", 1f, Size.sm),
            new Side("Fries", "Little string forms of Idaho", 1.5f, Size.md),
            new Side("Fries", "Little string forms of Idaho", 2f, Size.lg),
        };
    }
}