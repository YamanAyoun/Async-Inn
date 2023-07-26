namespace Async_Inn_Management_System.Models
{
    public class RoomAmenity
    {
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        //Navigation 
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
