﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel.Model.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HotelEntities : DbContext
    {
        public HotelEntities()
            : base("name=HotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<booking> bookings { get; set; }
        public virtual DbSet<feature> features { get; set; }
        public virtual DbSet<offer> offers { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<roomPhoto> roomPhotoes { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<booking_serivces> booking_serivces { get; set; }
    
        public virtual int AddAccount(string email, string fullname, string pass, string usertype)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var fullnameParameter = fullname != null ?
                new ObjectParameter("fullname", fullname) :
                new ObjectParameter("fullname", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var usertypeParameter = usertype != null ?
                new ObjectParameter("usertype", usertype) :
                new ObjectParameter("usertype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddAccount", emailParameter, fullnameParameter, passParameter, usertypeParameter);
        }
    
        public virtual int AddBooking(Nullable<System.DateTime> checkIn, Nullable<System.DateTime> checkOut, Nullable<int> bookedRoom, Nullable<int> nrPeople, Nullable<int> price, Nullable<int> room, Nullable<int> user)
        {
            var checkInParameter = checkIn.HasValue ?
                new ObjectParameter("checkIn", checkIn) :
                new ObjectParameter("checkIn", typeof(System.DateTime));
    
            var checkOutParameter = checkOut.HasValue ?
                new ObjectParameter("checkOut", checkOut) :
                new ObjectParameter("checkOut", typeof(System.DateTime));
    
            var bookedRoomParameter = bookedRoom.HasValue ?
                new ObjectParameter("bookedRoom", bookedRoom) :
                new ObjectParameter("bookedRoom", typeof(int));
    
            var nrPeopleParameter = nrPeople.HasValue ?
                new ObjectParameter("nrPeople", nrPeople) :
                new ObjectParameter("nrPeople", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var roomParameter = room.HasValue ?
                new ObjectParameter("room", room) :
                new ObjectParameter("room", typeof(int));
    
            var userParameter = user.HasValue ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddBooking", checkInParameter, checkOutParameter, bookedRoomParameter, nrPeopleParameter, priceParameter, roomParameter, userParameter);
        }
    
        public virtual int AddFeature(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddFeature", nameParameter);
        }
    
        public virtual int AddOffer(string name, Nullable<int> bookedRooms, Nullable<int> price, Nullable<System.DateTime> startDate, Nullable<System.DateTime> dueDate)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var bookedRoomsParameter = bookedRooms.HasValue ?
                new ObjectParameter("bookedRooms", bookedRooms) :
                new ObjectParameter("bookedRooms", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var dueDateParameter = dueDate.HasValue ?
                new ObjectParameter("dueDate", dueDate) :
                new ObjectParameter("dueDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddOffer", nameParameter, bookedRoomsParameter, priceParameter, startDateParameter, dueDateParameter);
        }
    
        public virtual int AddRoom(Nullable<int> capacity, Nullable<int> numberofRooms, Nullable<int> price, Nullable<int> feature)
        {
            var capacityParameter = capacity.HasValue ?
                new ObjectParameter("capacity", capacity) :
                new ObjectParameter("capacity", typeof(int));
    
            var numberofRoomsParameter = numberofRooms.HasValue ?
                new ObjectParameter("numberofRooms", numberofRooms) :
                new ObjectParameter("numberofRooms", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var featureParameter = feature.HasValue ?
                new ObjectParameter("feature", feature) :
                new ObjectParameter("feature", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddRoom", capacityParameter, numberofRoomsParameter, priceParameter, featureParameter);
        }
    
        public virtual int AddService(string name, Nullable<int> price)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddService", nameParameter, priceParameter);
        }
    
        public virtual int ModifyAccount(Nullable<int> id, string email, string fullname, string pass, string usertype)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var fullnameParameter = fullname != null ?
                new ObjectParameter("fullname", fullname) :
                new ObjectParameter("fullname", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var usertypeParameter = usertype != null ?
                new ObjectParameter("usertype", usertype) :
                new ObjectParameter("usertype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyAccount", idParameter, emailParameter, fullnameParameter, passParameter, usertypeParameter);
        }
    
        public virtual int ModifyBooking(Nullable<int> id, Nullable<System.DateTime> checkIn, Nullable<System.DateTime> checkOut, Nullable<int> bookedRoom, Nullable<int> nrPeople, Nullable<int> price, Nullable<int> room, Nullable<int> user)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var checkInParameter = checkIn.HasValue ?
                new ObjectParameter("checkIn", checkIn) :
                new ObjectParameter("checkIn", typeof(System.DateTime));
    
            var checkOutParameter = checkOut.HasValue ?
                new ObjectParameter("checkOut", checkOut) :
                new ObjectParameter("checkOut", typeof(System.DateTime));
    
            var bookedRoomParameter = bookedRoom.HasValue ?
                new ObjectParameter("bookedRoom", bookedRoom) :
                new ObjectParameter("bookedRoom", typeof(int));
    
            var nrPeopleParameter = nrPeople.HasValue ?
                new ObjectParameter("nrPeople", nrPeople) :
                new ObjectParameter("nrPeople", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var roomParameter = room.HasValue ?
                new ObjectParameter("room", room) :
                new ObjectParameter("room", typeof(int));
    
            var userParameter = user.HasValue ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyBooking", idParameter, checkInParameter, checkOutParameter, bookedRoomParameter, nrPeopleParameter, priceParameter, roomParameter, userParameter);
        }
    
        public virtual int ModifyFeature(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyFeature", idParameter, nameParameter);
        }
    
        public virtual int ModifyOffer(Nullable<int> id, string name, Nullable<int> bookedRooms, Nullable<int> price, Nullable<System.DateTime> startDate, Nullable<System.DateTime> dueDate)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var bookedRoomsParameter = bookedRooms.HasValue ?
                new ObjectParameter("bookedRooms", bookedRooms) :
                new ObjectParameter("bookedRooms", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var dueDateParameter = dueDate.HasValue ?
                new ObjectParameter("dueDate", dueDate) :
                new ObjectParameter("dueDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyOffer", idParameter, nameParameter, bookedRoomsParameter, priceParameter, startDateParameter, dueDateParameter);
        }
    
        public virtual int ModifyRoom(Nullable<int> id, Nullable<int> numberofRooms, Nullable<int> price, Nullable<int> feature, Nullable<int> capacity)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var numberofRoomsParameter = numberofRooms.HasValue ?
                new ObjectParameter("numberofRooms", numberofRooms) :
                new ObjectParameter("numberofRooms", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var featureParameter = feature.HasValue ?
                new ObjectParameter("feature", feature) :
                new ObjectParameter("feature", typeof(int));
    
            var capacityParameter = capacity.HasValue ?
                new ObjectParameter("capacity", capacity) :
                new ObjectParameter("capacity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyRoom", idParameter, numberofRoomsParameter, priceParameter, featureParameter, capacityParameter);
        }
    
        public virtual int ModifyService(Nullable<int> id, string name, Nullable<int> price)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyService", idParameter, nameParameter, priceParameter);
        }
    
        public virtual int RemoveAccount(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveAccount", idParameter);
        }
    
        public virtual int RemoveBooking(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveBooking", idParameter);
        }
    
        public virtual int RemoveFeatures(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveFeatures", idParameter);
        }
    
        public virtual int RemoveOffers(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveOffers", idParameter);
        }
    
        public virtual int RemoveRooms(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveRooms", idParameter);
        }
    
        public virtual int RemoveServices(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveServices", idParameter);
        }
    
        public virtual int AddServiceToBooking(Nullable<int> idService, Nullable<int> idBooking)
        {
            var idServiceParameter = idService.HasValue ?
                new ObjectParameter("idService", idService) :
                new ObjectParameter("idService", typeof(int));
    
            var idBookingParameter = idBooking.HasValue ?
                new ObjectParameter("idBooking", idBooking) :
                new ObjectParameter("idBooking", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddServiceToBooking", idServiceParameter, idBookingParameter);
        }
    
        public virtual int ModifyServiceToBooking(Nullable<int> id, Nullable<int> idService, Nullable<int> idBooking)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var idServiceParameter = idService.HasValue ?
                new ObjectParameter("idService", idService) :
                new ObjectParameter("idService", typeof(int));
    
            var idBookingParameter = idBooking.HasValue ?
                new ObjectParameter("idBooking", idBooking) :
                new ObjectParameter("idBooking", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModifyServiceToBooking", idParameter, idServiceParameter, idBookingParameter);
        }
    
        public virtual int AddPhoto(Nullable<int> idRoom, string path)
        {
            var idRoomParameter = idRoom.HasValue ?
                new ObjectParameter("idRoom", idRoom) :
                new ObjectParameter("idRoom", typeof(int));
    
            var pathParameter = path != null ?
                new ObjectParameter("path", path) :
                new ObjectParameter("path", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddPhoto", idRoomParameter, pathParameter);
        }
    
        public virtual int DeletePhoto(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePhoto", idParameter);
        }
    
        public virtual int PayBooking(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PayBooking", idParameter);
        }
    }
}