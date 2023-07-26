namespace Async_Inn_Management_System.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Nav
        public List<RoomAmenity> RoomAmenities { get; set; }
    }
}
