using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Lunch_Delivery_MVC.Models
{
    public class OnlineDelivery
    {
        public int Id { get; set; }

        public int DeliveryAgentId { get; set; }

        public int LunchPackId { get; set; }

        public int CustomerId { get; set; }


        public DeliveryAgent DeliveryAgent { get; set; }

        public Customer Customer { get; set; }

        public LunchPack LunchPack { get; set; }


        public int NumberOfPacks { get; set; }

        public string Address { get; set; }


        [NotMapped]
        public decimal TotalPrice
        {
            get
            {

                return this.LunchPack.Price * this.NumberOfPacks;

            }
        }

    }
}
