using System;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Books;

public class BookPicture : Entity<Guid>
{
    public Guid BookId { get; set; }

    public string Url { get; set; }

    public BookPicture(Guid id, string url) : base(id)
    {
        Url = url;
    }
}