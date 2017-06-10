using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Projekat3_NWT.DAL;
using Projekat3_NWT.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Projekat3_NWT.Startup))]
namespace Projekat3_NWT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        private void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
  
            if (!roleManager.RoleExists("Admin"))
            {


                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin1@admin.com";
                user.Email = "admin1@admin.com";

                string userPWD = "Admin1!";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }                

            }

            bool proba = roleManager.RoleExists("Agent");
  
            if (!roleManager.RoleExists("Agent"))
            {
                var role = new IdentityRole();
                role.Name = "Agent";
                roleManager.Create(role);


                var agent1 = new ApplicationUser();
                agent1.UserName = "agent1@agent.com";
                agent1.Email = "agent1@agent.com";

                string agent1PWD = "Agent1!";

                var chkAgent1 = UserManager.Create(agent1, agent1PWD);

                if (chkAgent1.Succeeded)
                {
                    var result1 = UserManager.AddToRole(agent1.Id, "Agent");

                }



                var agent2 = new ApplicationUser();
                agent2.UserName = "agent2@agent.com";
                agent2.Email = "agent2@agent.com";

                string agent2PWD = "Agent2!";

                var chkAgent2 = UserManager.Create(agent2, agent2PWD);

                if (chkAgent2.Succeeded)
                {
                    var result1 = UserManager.AddToRole(agent2.Id, "Agent");

                }
            }
 
            if (!roleManager.RoleExists("Client"))
            {
                var role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);

                var client1 = new ApplicationUser();
                client1.UserName = "client1@client.com";
                client1.Email = "client1@client.com";

                string client1PWD = "Client1!";

                var chkClient1 = UserManager.Create(client1, client1PWD);

                if (chkClient1.Succeeded)
                {
                    var result1 = UserManager.AddToRole(client1.Id, "Client");

                }

                var client2 = new ApplicationUser();
                client2.UserName = "client2@client.com";
                client2.Email = "client2@client.com";

                string client2PWD = "Client2!";

                var chkClient2 = UserManager.Create(client2, client2PWD);

                if (chkClient2.Succeeded)
                {
                    var result1 = UserManager.AddToRole(client2.Id, "Client");

                }
            }

            if(context.Properties.Count() == 0)
            {
                context.Properties.AddOrUpdate(
                   p => p.Id,
                   new Property
                   {
                       Id = 1,
                       Type = "Apartment",
                       AvailableFor = "Rent",
                       DateAdded = DateTime.Now,
                       NumberOfRooms = 5,
                       NumberOfBedRooms = 1,
                       NumberOfBathRooms = 2,
                       SquareMeters = 70,
                       DescriptionLong = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia." +
                       " Quisque at leo et elit ullamcorper ultricies eget id erat.Etiam hendrerit tortor id tincidunt maximus." +
                       " Quisque ante nibh, tempus in viverra in, pretium ut diam.Praesent egestas, urna ut pellentesque ultricies," +
                       " nibh quam blandit ipsum, ac hendrerit justo sem quis risus.Nam sollicitudin nisi quam," +
                       "quis convallis arcu consequat a.",
                       DescriptionShort = "Property1 Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia.",
                       Price = 2000,
                       StoryNumber = 10,
                       TotalNumberOfStories = 12,
                       TypeOfHeating = "Central Heating",
                       ParkingPlace = true,
                       AvailableFrom = new DateTime(2017, 2, 15),
                       Elevator = true,
                       CameraSystem = false,
                       InterPhone = true,
                       Furnished = false,
                       Owner = context.Users.Where(u => u.Email == "client2@client.com").First(),
                       Address = new Address
                       {
                           Id = 1,
                           State = "Serbia",
                           City = "Nis",
                           Street = "Admiralova 12",
                           ZipCode = "18000",
                           Lat = 43.330708,
                           Lon = 21.892216
                       },
                       propertyImages = new[] {
                                                    new PropertyImage
                                                    {
                                                        Id = 1,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property1 Picture1"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 2,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-26.jpg",
                                                        description = "Property1 Picture2"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 3,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/img2.jpg",
                                                        description = "Property1 Picture3"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 4,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property1 Picture4"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 5,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/studio-apartment-design-1024x614.jpg",
                                                        description = "Property1 Picture5"
                                                    }
                                              }



                   },
               new Property
               {
                   Id = 2,
                   Type = "House",
                   AvailableFor = "Sale",
                   DateAdded = System.DateTime.Now,
                   NumberOfRooms = 6,
                   NumberOfBedRooms = 2,
                   NumberOfBathRooms = 1,
                   SquareMeters = 700,
                   DescriptionLong = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia." +
                       " Quisque at leo et elit ullamcorper ultricies eget id erat.Etiam hendrerit tortor id tincidunt maximus." +
                       " Quisque ante nibh, tempus in viverra in, pretium ut diam.Praesent egestas, urna ut pellentesque ultricies," +
                       " nibh quam blandit ipsum, ac hendrerit justo sem quis risus.Nam sollicitudin nisi quam," +
                       "quis convallis arcu consequat a.",
                   DescriptionShort = "Propert2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia.",
                   Price = 500,
                   StoryNumber = 1,
                   TotalNumberOfStories = 1,
                   TypeOfHeating = "Furnice",
                   ParkingPlace = false,
                   AvailableFrom = new DateTime(2017, 2, 18),
                   Elevator = false,
                   CameraSystem = true,
                   InterPhone = false,
                   Furnished = true,
                   Owner = context.Users.Where(u => u.Email == "client1@client.com").First(),
                   Address = new Address
                   {
                       Id = 2,
                       State = "Serbia",
                       City = "Nis",
                       Street = "Admiralova 18",
                       ZipCode = "18000",
                       Lat = 43.319796,
                       Lon = 21.894082
                   },
                   propertyImages = new[] {
                                                    new PropertyImage
                                                    {
                                                        Id = 6,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bachelor-apartment-design.1.jpg",
                                                        description = "Property2 Picture1"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 7,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-26.jpg",
                                                        description = "Property2 Picture2"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 8,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/img2.jpg",
                                                        description = "Property2 Picture3"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 9,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/studio-apartment-design-1024x614.jpg",
                                                        description = "Property2 Picture4"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 10,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property2 Picture5"
                                                    }
                                              }



               },
                   new Property
                   {
                       Id = 1,
                       Type = "Apartment",
                       AvailableFor = "Rent",
                       DateAdded = DateTime.Now,
                       NumberOfRooms = 5,
                       NumberOfBedRooms = 1,
                       NumberOfBathRooms = 2,
                       SquareMeters = 70,
                       DescriptionLong = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia." +
                       " Quisque at leo et elit ullamcorper ultricies eget id erat.Etiam hendrerit tortor id tincidunt maximus." +
                       " Quisque ante nibh, tempus in viverra in, pretium ut diam.Praesent egestas, urna ut pellentesque ultricies," +
                       " nibh quam blandit ipsum, ac hendrerit justo sem quis risus.Nam sollicitudin nisi quam," +
                       "quis convallis arcu consequat a.",
                       DescriptionShort = "Propert3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia.",
                       Price = 2000,
                       StoryNumber = 10,
                       TotalNumberOfStories = 12,
                       TypeOfHeating = "Central Heating",
                       ParkingPlace = true,
                       AvailableFrom = new DateTime(2017, 2, 15),
                       Elevator = true,
                       CameraSystem = false,
                       InterPhone = true,
                       Furnished = false,
                       Owner = context.Users.Where(u => u.Email == "client2@client.com").First(),
                       Address = new Address
                       {
                           Id = 1,
                           State = "Serbia",
                           City = "Nis",
                           Street = "Admiralova 12",
                           ZipCode = "18000",
                           Lat = 43.330708,
                           Lon = 21.892216
                       },
                       propertyImages = new[] {
                                                    new PropertyImage
                                                    {
                                                        Id = 1,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property1 Picture1"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 2,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-26.jpg",
                                                        description = "Property1 Picture2"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 3,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/img2.jpg",
                                                        description = "Property1 Picture3"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 4,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property1 Picture4"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 5,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/studio-apartment-design-1024x614.jpg",
                                                        description = "Property1 Picture5"
                                                    }
                                              }



                   },
               new Property
               {
                   Id = 2,
                   Type = "House",
                   AvailableFor = "Sale",
                   DateAdded = System.DateTime.Now,
                   NumberOfRooms = 6,
                   NumberOfBedRooms = 2,
                   NumberOfBathRooms = 1,
                   SquareMeters = 700,
                   DescriptionLong = "Property 4 Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia." +
                       " Quisque at leo et elit ullamcorper ultricies eget id erat.Etiam hendrerit tortor id tincidunt maximus." +
                       " Quisque ante nibh, tempus in viverra in, pretium ut diam.Praesent egestas, urna ut pellentesque ultricies," +
                       " nibh quam blandit ipsum, ac hendrerit justo sem quis risus.Nam sollicitudin nisi quam," +
                       "quis convallis arcu consequat a.",
                   DescriptionShort = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia.",
                   Price = 500,
                   StoryNumber = 1,
                   TotalNumberOfStories = 1,
                   TypeOfHeating = "Furnice",
                   ParkingPlace = false,
                   AvailableFrom = new DateTime(2017, 2, 18),
                   Elevator = false,
                   CameraSystem = true,
                   InterPhone = false,
                   Furnished = true,
                   Owner = context.Users.Where(u => u.Email == "client1@client.com").First(),
                   Address = new Address
                   {
                       Id = 2,
                       State = "Serbia",
                       City = "Nis",
                       Street = "Admiralova 18",
                       ZipCode = "18000",
                       Lat = 43.319796,
                       Lon = 21.894082
                   },
                   propertyImages = new[] {
                                                    new PropertyImage
                                                    {
                                                        Id = 6,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bachelor-apartment-design.1.jpg",
                                                        description = "Property2 Picture1"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 7,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-26.jpg",
                                                        description = "Property2 Picture2"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 8,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/img2.jpg",
                                                        description = "Property2 Picture3"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 9,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/studio-apartment-design-1024x614.jpg",
                                                        description = "Property2 Picture4"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 10,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property2 Picture5"
                                                    }
                                              }



               },
                   new Property
                   {
                       Id = 1,
                       Type = "Apartment",
                       AvailableFor = "Rent",
                       DateAdded = DateTime.Now,
                       NumberOfRooms = 5,
                       NumberOfBedRooms = 1,
                       NumberOfBathRooms = 2,
                       SquareMeters = 70,
                       DescriptionLong = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia." +
                       " Quisque at leo et elit ullamcorper ultricies eget id erat.Etiam hendrerit tortor id tincidunt maximus." +
                       " Quisque ante nibh, tempus in viverra in, pretium ut diam.Praesent egestas, urna ut pellentesque ultricies," +
                       " nibh quam blandit ipsum, ac hendrerit justo sem quis risus.Nam sollicitudin nisi quam," +
                       "quis convallis arcu consequat a.",
                       DescriptionShort = "Property5 Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia.",
                       Price = 2000,
                       StoryNumber = 10,
                       TotalNumberOfStories = 12,
                       TypeOfHeating = "Central Heating",
                       ParkingPlace = true,
                       AvailableFrom = new DateTime(2017, 2, 15),
                       Elevator = true,
                       CameraSystem = false,
                       InterPhone = true,
                       Furnished = false,
                       Owner = context.Users.Where(u => u.Email == "client2@client.com").First(),
                       Address = new Address
                       {
                           Id = 1,
                           State = "Serbia",
                           City = "Nis",
                           Street = "Admiralova 12",
                           ZipCode = "18000",
                           Lat = 43.330708,
                           Lon = 21.892216
                       },
                       propertyImages = new[] {
                                                    new PropertyImage
                                                    {
                                                        Id = 1,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property1 Picture1"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 2,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-26.jpg",
                                                        description = "Property1 Picture2"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 3,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/img2.jpg",
                                                        description = "Property1 Picture3"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 4,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property1 Picture4"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        Id = 5,
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/studio-apartment-design-1024x614.jpg",
                                                        description = "Property1 Picture5"
                                                    }
                                              }



                   },
               new Property
               {
                   Id = 2,
                   Type = "House",
                   AvailableFor = "Sale",
                   DateAdded = DateTime.Now,
                   NumberOfRooms = 6,
                   NumberOfBedRooms = 2,
                   NumberOfBathRooms = 1,
                   SquareMeters = 700,
                   DescriptionLong = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia." +
                       " Quisque at leo et elit ullamcorper ultricies eget id erat.Etiam hendrerit tortor id tincidunt maximus." +
                       " Quisque ante nibh, tempus in viverra in, pretium ut diam.Praesent egestas, urna ut pellentesque ultricies," +
                       " nibh quam blandit ipsum, ac hendrerit justo sem quis risus.Nam sollicitudin nisi quam," +
                       "quis convallis arcu consequat a.",
                   DescriptionShort = "Property6 Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nullam ut diam vel erat" +
                       " suscipit faucibus id id nibh.Duis aliquam commodo ligula vitae pretium.In sodales eu leo ac lacinia.",
                   Price = 500,
                   StoryNumber = 1,
                   TotalNumberOfStories = 1,
                   TypeOfHeating = "Furnice",
                   ParkingPlace = false,
                   AvailableFrom = new DateTime(2017, 2, 18),
                   Elevator = false,
                   CameraSystem = true,
                   InterPhone = false,
                   Furnished = true,
                   Owner = context.Users.Where(u => u.Email == "client1@client.com").First(),
                   Address = new Address
                   {
                       State = "Serbia",
                       City = "Nis",
                       Street = "Admiralova 18",
                       ZipCode = "18000",
                       Lat = 43.319796,
                       Lon = 21.894082
                   },
                   propertyImages = new[] {
                                                    new PropertyImage
                                                    {
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bachelor-apartment-design.1.jpg",
                                                        description = "Property6 Picture1"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-26.jpg",
                                                        description = "Property6 Picture2"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/img2.jpg",
                                                        description = "Property6 Picture3"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/studio-apartment-design-1024x614.jpg",
                                                        description = "Property2 Picture4"
                                                    },
                                                    new PropertyImage
                                                    {
                                                        url = "~/Images/user_uploads/zeljkicc@hotmail.com/bes-small-apartments-designs-ideas-image-12.jpg",
                                                        description = "Property2 Picture5"
                                                    }
                                              }



               }

               );

                context.SaveChanges();
            }



        }
    }
}
