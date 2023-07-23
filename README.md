## In Lab 13:

1. I implemented Dependency Injection to enhance the structure of my Hotels, Rooms, and Amenities Controllers. This was achieved by making these controllers depend on interfaces.

2. To begin, I created interfaces for each of the controllers, ensuring that these interfaces contained all the necessary method signatures for performing CRUD operations directly to the database.

3. Next, I modified each of the controllers to inject the corresponding interface.

4. For seamless integration, I developed a service for each of the controllers that implemented the respective interface.

5. With these changes in place, I updated the Controller to utilize the appropriate methods from the interface instead of directly accessing the DBContext.
