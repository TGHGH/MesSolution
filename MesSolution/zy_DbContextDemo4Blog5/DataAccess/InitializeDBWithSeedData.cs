using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DbContexts.DataAccess
{
    public class InitializeDBWithSeedData : DropCreateDatabaseAlways<BreakAwayContext>
    {
        protected override void Seed(BreakAwayContext context)
        {
            context.Destinations.Add(new DbContexts.Model.Destination
            {
                Name = "Hawaii",
                Country = "USA",
                Description = "Sunshine, beaches and fun."
            });

            context.Destinations.Add(new DbContexts.Model.Destination
            {
                Name = "Wine Glass Bay",
                Country = "Australia",
                Description = "Picturesque sandy beaches."
            });

            context.Destinations.Add(new DbContexts.Model.Destination
            {
                Name = "Great Barrier Reef",
                Description = "Beautiful coral reef.",
                Country = "Australia"
            });

            context.Destinations.Add(new DbContexts.Model.Destination
            {
                Name = "Grand Canyon",
                Country = "USA",
                Description = "One huge canyon.",
                Lodgings = new List<DbContexts.Model.Lodging>
                    {
                        new DbContexts.Model.Lodging 
                        { 
                            Name = "Grand Hotel",
                            MilesFromNearestAirport = 2.5M
                        },
                        new DbContexts.Model.Lodging 
                        { 
                            Name = "Dave's Dump" ,
                            MilesFromNearestAirport = 32.65M,
                            PrimaryContact = new DbContexts.Model.Person
                        {
                            FirstName = "Dave",
                            LastName = "Citizen",
                            Photo = new DbContexts.Model.PersonPhoto()
                         }
                     }
                 }
            });

            context.Reservations.Add(new DbContexts.Model.Reservation
            {
                DateTimeMade = DateTime.Now,
                Trip = new DbContexts.Model.Trip
                {
                    StartDate = new DateTime(2012, 1, 1),
                    EndDate = new DateTime(2012, 1, 14),
                    Description = ("Trip from the database"),
                    Destination = context.Destinations.Local.First(),   //First
                    CostUSD = 1000M
                },
                Traveler = new DbContexts.Model.Person
                {
                    FirstName = "Julie",
                    LastName = "Lerman",
                    Photo = new DbContexts.Model.PersonPhoto()
                },
                Payments = new List<DbContexts.Model.Payment>()
                {
                    new DbContexts.Model.Payment { Amount = 150 }
                 }
            });

        }
    }
}
