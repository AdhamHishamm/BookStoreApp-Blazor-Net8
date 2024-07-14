﻿using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services
{
	public class AuthorService : BaseHttpService, IAuthorService
    {
        private readonly IClient client;
		private readonly IMapper mapper;

		public AuthorService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this.client = client;
			this.mapper = mapper;
		}

        public async Task<Response<int>> Create(AuthorCreateDto author)
        {
            Response<int> response = new();

            try
            {
                await GetBearerToken();
                await client.AuthorsPOSTAsync(author);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

		public async Task<Response<int>> Delete(int id)
		{
			Response<int> response = new();

			try
			{
				await GetBearerToken();
				await client.AuthorsDELETEAsync(id);
			}
			catch (ApiException exception)
			{
				response = ConvertApiExceptions<int>(exception);
			}

			return response;
		}

		public async Task<Response<int>> Edit(int id,AuthorUpdateDto author)
		{
			Response<int> response = new();

			try
			{
				await GetBearerToken();
				await client.AuthorsPUTAsync(id, author);
			}
			catch (ApiException exception)
			{
				response = ConvertApiExceptions<int>(exception);
			}

			return response;
		}

		public async Task<Response<List<AuthorReadOnlyDto>>> Get()
        {
            Response<List<AuthorReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            { 
                response = ConvertApiExceptions<List<AuthorReadOnlyDto>>(exception);
            }
            return response;
        }

		public async Task<Response<AuthorDetailsDto>> Get(int id)
		{
			Response<AuthorDetailsDto> response;

			try
			{
				await GetBearerToken();
				var data = await client.AuthorsGETAsync(id);
				response = new Response<AuthorDetailsDto>
				{
					Data = data,
					Success = true
				};
			}
			catch (ApiException exception)
			{
				response = ConvertApiExceptions<AuthorDetailsDto>(exception);
			}
			return response;
		}

		public async Task<Response<AuthorUpdateDto>> GetForUpdate(int id)
		{
			var response = new Response<AuthorUpdateDto>();

			try
			{
				await GetBearerToken();
				var data = await client.AuthorsGETAsync(id);

				if (data == null)
				{
					response.Success = false;
					response.Message = "Author data not found or null.";
				}
				else
				{
					response.Data = mapper.Map<AuthorUpdateDto>(data);
					response.Success = true;
				}
			}
			catch (ApiException exception)
			{
				response = ConvertApiExceptions<AuthorUpdateDto>(exception);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"An error occurred: {ex.Message}";
				// Optionally log the exception for further debugging
				Console.WriteLine($"Error in GetForUpdate: {ex}");
			}

			return response;
		}

	}

}
