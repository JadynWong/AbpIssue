using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books;

public interface IBookAppService : IApplicationService
{
    Task AddPictureAsync(Guid id, string url);
    Task<BookDto> CreateAsync(string name);
}