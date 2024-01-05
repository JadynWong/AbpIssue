using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.AuditLogging;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.BookStore.Books;

public abstract class BookAppServiceTests<TStartupModule> : BookStoreApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IBookAppService _bookAppService;
    private readonly IAuditLogRepository _auditLogRepository;

    protected BookAppServiceTests()
    {
        _bookAppService = GetRequiredService<IBookAppService>();
        _auditLogRepository = GetRequiredService<IAuditLogRepository>();
    }

    [Fact]
    public async Task EntityChange_Should_Empty()
    {
        //Act
        var book = await _bookAppService.CreateAsync("test");
        await _bookAppService.AddPictureAsync(book.Id, "https://google.com");

        var entityChanges = await _auditLogRepository.GetEntityChangeListAsync();

        //Assert
        entityChanges.ShouldBeEmpty();
    }
}
