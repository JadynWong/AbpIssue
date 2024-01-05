using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books;

public class BookAppService : BookStoreAppService, IBookAppService
{
    private readonly IRepository<Book, Guid> _repository;

    public BookAppService(IRepository<Book, Guid> repository)
    {
        _repository = repository;
    }

    public virtual async Task<BookDto> CreateAsync(string name)
    {
        var book = new Book(GuidGenerator.Create(), name);
        await _repository.InsertAsync(book);

        return ObjectMapper.Map<Book, BookDto>(book);
    }

    public virtual async Task AddPictureAsync(Guid id, string url)
    {
        var book = await _repository.GetAsync(id);
        book.Pictures.Add(new BookPicture(GuidGenerator.Create(), url));
        await _repository.UpdateAsync(book);
    }
}
