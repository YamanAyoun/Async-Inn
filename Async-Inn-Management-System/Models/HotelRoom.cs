namespace Async_Inn_Management_System.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int Rate { get; set; }
        public byte PetFriendly { get; set; }

        //Navigation 
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
