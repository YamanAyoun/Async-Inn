﻿using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
    public class RoomServices : IRoom
    {
        private readonly AsyncInnDbContext _context;

        public RoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(RoomDTO room)
        {
            Room newRoom = new Room
            {
                Name = room.Name,
                Layout = room.Layout,
            };
            _context.Entry(newRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newRoom;
        }
        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.rooms.Select(x => new RoomDTO
            {
                Id = x.Id,
                Name = x.Name,
                Layout = x.Layout,
                Amenities = x.RoomAmenities.Select(x => new AmenityDTO
                {
                    Id = x.AmenityID,
                    Name = x.Amenity.Name
                }).ToList()
            }).ToListAsync();
        }
        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _context.rooms.Select(x => new RoomDTO
            {
                Id = x.Id,
                Name = x.Name,
                Layout = x.Layout,
                Amenities = x.RoomAmenities.Select(x => new AmenityDTO
                {
                    Id = x.AmenityID,
                    Name = x.Amenity.Name
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Room> UpdateRoom(int id, RoomDTO room)
        {
            Room newRoom = new Room
            {
                Id = id,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(newRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return newRoom;
        }
        public async Task Delete(int id)
        {
            Room room = await _context.rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity { AmenityID = amenityId, RoomID = roomId };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var roomAmenity = await _context.RoomAmenities.Where(x => x.AmenityID == amenityId && x.RoomID == roomId)
                                                          .FirstOrDefaultAsync();
            if (roomAmenity != null)
            {
                _context.Entry(roomAmenity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
