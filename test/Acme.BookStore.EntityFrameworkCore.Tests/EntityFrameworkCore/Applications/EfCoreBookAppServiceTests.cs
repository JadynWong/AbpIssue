using Acme.BookStore.Books;
using Xunit;

namespace Acme.BookStore.EntityFrameworkCore.Applications;

[Collection(BookStoreTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppServiceTests : BookAppServiceTests<BookStoreEntityFrameworkCoreTestModule>
{
}
