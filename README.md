#  Async-Inn

## Name: Yaman Ayoun
## Date: 31/7/2023.

1. Add in Async Inn application by cleaning up input and outputs of your controllers to be DTOs.

build DTOs stand for data transfer objects for this class:

* Amenities
* Rooms
* HotelRooms
* Hotels
```
    public class HotelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public List<HotelRoomDTO> Rooms { get; set; }
    }


    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }

    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
    }

    public class AmenityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
```

2. Update the Interface for each class becouse we need use DTO Classes.

3. Update services and controller API.

## Name: Yaman Ayoun
## Date: 23/7/2023.

## In Lab 13:

1. I implemented Dependency Injection to enhance the structure of my Hotels, Rooms, and Amenities Controllers. This was achieved by making these controllers depend on interfaces.

2. To begin, I created interfaces for each of the controllers, ensuring that these interfaces contained all the necessary method signatures for performing CRUD operations directly to the database.

3. Next, I modified each of the controllers to inject the corresponding interface.

4. For seamless integration, I developed a service for each of the controllers that implemented the respective interface.

5. With these changes in place, I updated the Controller to utilize the appropriate methods from the interface instead of directly accessing the DBContext.

## Name: Yaman Ayoun
## Date: 19/7/2023.

### Introduction
This web app is for a hotel management system. Users can view the hotels, rooms, and the amenities available either by retrieving all data of each table or by getting a specific one using it's ID.

## Async-Inn ERD 
![ERD Async Inn](Async-Inn-Management-System/Asserts/AsyncInn.png)

## I have Implemente this table:
* Hotel: the hotel has an ID, name, street address, city, state, country, and phone. All of these are provided in the requierments.

* Room: so this room has a unique ID and other properites such as name and layout.

* Amenities: it has an ID and a name. It navigates to RoomAmenities table since the relationship between them is a many to many.


