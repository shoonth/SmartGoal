using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartGoalApp.Controllers.Resources;
using SmartGoalApp.Models;
using SmartGoalApp.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartGoalApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ModelContext context;
        private readonly IMapper mapper;
        public UsersController(ModelContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("/api/user")]
        public async Task<IEnumerable<UserResource>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return mapper.Map<List<User>, List<UserResource>>(users);
        }
        //SonarQube test duplicated test
        public async Task<IEnumerable<UserResource>> GetDuplicatedUsers()
        {
            var users = await context.Users.ToListAsync();
            return mapper.Map<List<User>, List<UserResource>>(users);
        }
        //SonarQube problematic code test
        public void EndlessLoop()
        {
            while(true)
            {
                Console.WriteLine("Endless loop");
            }
        }
    }
}
