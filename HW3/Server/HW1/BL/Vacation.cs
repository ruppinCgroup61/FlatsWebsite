
namespace HW1.BL
{
    public class Vacation
    {
        int id;
        int userId;
        int flatId;
        DateTime startDate;
        DateTime endDate;
        static List<Vacation> vacationsList = new List<Vacation>();

        public Vacation() { }

        public Vacation(int id, int userId, int flatId, DateTime startDate, DateTime endDate)
        {
            Id = id;
            UserId = userId;
            FlatId = flatId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int FlatId { get => flatId; set => flatId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public bool Insert()
        {
            if (!vacationsList.Any(Vacation => Vacation.id == id))
            {
                foreach (Vacation V in vacationsList)
                {
                    if (V.flatId == this.flatId)
                    {
                        //V.startDate=26.12,V.endDate=30.12 | this_SD=27.12 , this_ED=30.12 --> should retrun true
                        if (V.startDate <= this.endDate && V.endDate >= this.startDate)
                        {
                            return false;
                        }
                    }
                }
                vacationsList.Add(this);
                return true;
            }
              return false;

        }

        public static List<Vacation> Read()
        {
            return vacationsList;
        }

        public List<Vacation> GetBystartDateAndendDateRuoting(DateTime StartD, DateTime EndD)
        {
            List<Vacation> selectedList = new List<Vacation>();
            foreach (Vacation v in vacationsList)
            {
                if (v.startDate >= StartD && v.endDate <= EndD)
                    selectedList.Add(v);
            }
            return selectedList;
        }
    }
}
