﻿using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication
{
	public interface IAuthenticationService
	{
		Task<bool> AuthenticateAsync(LoginUserDto loiginModel);
		public Task Logout();
	}
}
