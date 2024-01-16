﻿using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System.Collections.Generic;

namespace BankApp.Web.Mapping
{
	public interface IUserMapper
	{
		List<UserListModel> MapTolistOfUserList(List<ApplicationUser> users);

		UserListModel MapToUserList(ApplicationUser user);

	}
}
