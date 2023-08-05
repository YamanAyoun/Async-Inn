using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Services;

namespace TestAsyncInn
{
    public class UnitTest1 : Mock
    {
        [Fact]
        public async Task CanAddAndDeleteRoomToHotel()
        {
            // Arrange
            var hotel = await CreateAndSaveTestHotel();
            var room = await CreateAndSaveTestRoom();

            var services = new HotelRoomServices(_db);

            // Act
            await services.AddRoomToHotel(hotel.Id, new HotelRoom
            {
                HotelID = hotel.Id,
                RoomID = room.Id,
                Rate = 5,
                RoomNumber = 110,
            });

            // Assert
            var actualHotelRoom = await services.GetHotelRoom(hotel.Id, 110);
            Assert.Equal(room.Id, actualHotelRoom.RoomID);

            // Act
            await services.DeleteRoomFromHotel(room.Id, hotel.Id);

            // Assert
            var deleted = await services.GetHotelRoom(hotel.Id, room.Id);
            Assert.Null(deleted);
        }

        
        
        [Fact]
        
        public async Task CanAddAndDeleteAmenityToRoom()
        {
            // Arrange
            var amenity = await CreateAndSaveTestAmenity();
            var room = await CreateAndSaveTestRoom();

            var services = new RoomServices(_db);

            // Act
            await services.AddAmenityToRoom(room.Id, amenity.Id);

            // Assert
            var actualRoom = await services.GetRoom(room.Id);
            Assert.Contains(actualRoom.Amenities, r => r.Id == amenity.Id);

            // Act
            await services.RemoveAmentityFromRoom(room.Id, amenity.Id);

            // Assert
            actualRoom = await services.GetRoom(room.Id);
            Assert.DoesNotContain(actualRoom.Amenities, r => r.Id == amenity.Id);
        }
        [Fact]
        public async Task CanGetAmenity()
        {
            // Arrange
            var amenity = await CreateAndSaveTestAmenity();

            var service = new AmenityServices(_db);

            // Act
            var actAmenity = await service.GetAmenity(amenity.Id);

            // Assert
            Assert.NotNull(actAmenity);
            Assert.Equal(amenity.Id, actAmenity.Id);
            Assert.Equal(amenity.Name, actAmenity.Name);
        }




        [Fact]
        public async Task CanGetRoom()
        {
            // Arrange
            var room = await CreateAndSaveTestRoom();

            var service = new RoomServices(_db);

            // Act
            var actualRoom = await service.GetRoom(room.Id);

            // Assert
            Assert.NotNull(actualRoom);
            Assert.Equal(room.Id, actualRoom.Id);
            Assert.Equal(room.Name, actualRoom.Name);
            Assert.Equal(room.Layout, actualRoom.Layout);
        }


        


    }
}