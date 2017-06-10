using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Projekat3_NWT.DAL
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        RoleManager<IdentityRole> roleManager;

        public ApplicationUserRepository(DbContext context) : base(context)
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public IEnumerable<ApplicationUser> getAllAgents()
        {
            var agentRole = roleManager.FindByName("Agent");

            return context.Set<ApplicationUser>().Where(x => x.Roles.Any(s => s.RoleId == agentRole.Id)).ToList();
        }

        public IEnumerable<ApplicationUser> getAllClients()
        {
            var clientRole = roleManager.FindByName("Client");
            return context.Set<ApplicationUser>().Where(x => x.Roles.Any(s => s.RoleId == clientRole.Id)).ToList();
        }
    }
}