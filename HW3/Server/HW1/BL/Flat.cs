namespace HW1.BN
{
    public class Flat
    {
        int id;
        string city;
        string address;
        double price;
        int numbers_of_rooms;
        static List<Flat> FlatsList = new List<Flat>();

        public Flat(int id, string city, string address, double price, int numbers_of_rooms)
        {
            Id = id;
            City = city;
            Address = address;
            Price = price;
            Numbers_of_rooms = numbers_of_rooms;
        }

        public int Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public double Price { get => price; set => price = value; }
        public int Numbers_of_rooms { get => numbers_of_rooms; set => numbers_of_rooms = value; }

        public Flat() { }

        public bool Insert()
        {
            if (!FlatsList.Any(Flat => Flat.Id==Id))
            {
                if(numbers_of_rooms>1&&price>100)
                {
                    price = 0.9 * price;
                }
                FlatsList.Add(this);
                return true;
            }
            else
                return false;

        }

        public static List<Flat> Read() {
            return FlatsList;
        }

        public List<Flat> GetFlatByCityAndPrice(string city, double price)
        {
            List<Flat> selectedList = new List<Flat>();
            foreach (Flat f in FlatsList)
            {
                if (f.city == city && f.price < price)
                    selectedList.Add(f);
            }
            return selectedList;
        }

    }
}
