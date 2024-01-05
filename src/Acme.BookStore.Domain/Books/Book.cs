using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Books;

public class Book : AggregateRoot<Guid>
{
    public string Name { get; set; } = null!;

    public List<BookPicture> Pictures { get; set; } = [];

    protected Book() { }

    public Book(Guid id, string name) : base(id)
    {
        Name = name;
    }
}
