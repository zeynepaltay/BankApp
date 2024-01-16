﻿using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Data.Repositories
{
	public class ApplicationUserRepository : IApplicationUserRepository
	{
		private readonly BankContext _context;

		public ApplicationUserRepository(BankContext context)
		{
			_context = context;
		}

		public List<ApplicationUser> GetAll()
		{
			return _context.ApplicationUsers.ToList();
		}
		public ApplicationUser GetById(int id)
		{
			return _context.ApplicationUsers.SingleOrDefault(x => x.Id == id);
		}

		public void Create(ApplicationUser user)
		{
			_context.Set<ApplicationUser>().Add(user);
			_context.SaveChanges();
		}
	}
}