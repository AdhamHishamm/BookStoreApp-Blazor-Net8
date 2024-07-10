﻿using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
	public interface IAuthenticationService
	{
		Task<bool> AuthenticateAsync(LoginUserDto loiginModel);
		public Task Logout();
	}
}
