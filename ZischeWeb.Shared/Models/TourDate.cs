namespace ZischeWeb.Shared.Models
{
    public class TourDate
    {
        public int Id { get; set; }                  // Unique identifier for the tour date
        public string Venue { get; set; }            // Name of the venue
        public string City { get; set; }             // City where the concert will be held
        public string Country { get; set; }          // Country where the concert will be held
        public DateTime Date { get; set; }           // Date of the concert
        public string TicketLink { get; set; }       // Link to purchase tickets
    }

}
