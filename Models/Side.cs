namespace burgershack.Models
{
    public class Side : Burger
    {
        public Size Size { get; set; }
        public Side()
        {

        }
        public Side(string name, string description, float price, Size s) : base(name, description, price)
        {
            Size = s;
        }
    }

    public enum Size
    {
        sm = 1,
        md,
        lg
    }

}