namespace Async_Inn_Management_System.Models.DTO
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Phone { get; set; }
        public List<HotelRoomDTO> Rooms { get; set; }
    }
}
