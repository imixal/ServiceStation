namespace ServiceStation.Models
{
    public class Order : Entity
    {
        public string Date { get; set; }

        public double OrderAmount { get; set; }

        public string Status { get; set; }

        public Client OrderClient { get; set; }


        public Auto OrderAuto { get; set; }
    }
}
