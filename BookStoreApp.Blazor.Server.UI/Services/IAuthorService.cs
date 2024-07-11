using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> Get();
		Task<Response<AuthorDetailsDto>> Get(int id);
		Task<Response<AuthorUpdateDto>> GetAuthorForUpdate(int id);
		Task<Response<int>> CreateAuthor(AuthorCreateDto author);
        Task<Response<int>> EditAuthor(int id, AuthorUpdateDto author);
        Task<Response<int>> Delete(int id);

    }
}