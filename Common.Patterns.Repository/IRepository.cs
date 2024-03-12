

namespace Common.Patterns.Repository;

/// <summary>
/// Represents a repository that supports both read and write operations.
/// Read operations are performed using the <see cref="IReadOnlyRepository"/> interface, while 
/// write operations are performed using the <see cref="IWriteOnlyRepository"/> interface.
/// Collectively, the following C.R.U.D. operations are supported:
/// <list type="bullet">
/// <item>
/// <see cref="IWriteOnlyRepository.CreateItemAsync{TItem}(TItem, CancellationToken)"/>
/// </item>
/// <item>
/// <see cref="IReadOnlyRepository.ReadItemAsync{TItem, TIdentifier}(TIdentifier, CancellationToken), CancellationToken)"/>
/// </item>
/// <item>
/// <see cref="IWriteOnlyRepository.UpdateItemAsync{TItem}(TItem, CancellationToken)"/>
/// </item>
/// <item>
/// <see cref="IWriteOnlyRepository.DeleteItemAsync{TItem}(TItem, CancellationToken)"/>
/// </item>
/// </list>
/// </summary>
public interface IRepository : IWriteOnlyRepository, IReadOnlyRepository
{
}
