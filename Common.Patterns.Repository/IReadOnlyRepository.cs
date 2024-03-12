namespace Common.Patterns.Repository;

/// <summary>
/// Represents a repository that supports read operations.
/// </summary>
public interface IReadOnlyRepository
{
    /// <summary>
    /// Read the matching <typeparamref name="TItem"/> asynchronously.
    /// </summary>
    /// <typeparam name="TItem">The type of the item to read.</typeparam>
    /// <typeparam name="TIdentifier">The type for the item's identifier.</typeparam>
    /// <param name="cancellationToken">An optional signal used as a cancellation token that allows the consumers to attempt cancellation of the "creation operation". This is not guaranteed to cancel, as it's possible the underlying storage provider finishes before cancellation.</param>
    /// <returns>An asynchronous task representing the "read operation".</returns>
    Task<TItem> ReadItemAsync<TItem, TIdentifier>(
        TIdentifier identifier,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Reads all <paramref name="matching"/> items asynchronously.
    /// </summary>
    /// <typeparam name="TItem">The type of the item read.</typeparam>
    /// <param name="matching">A predicate used to match items.</param>
    /// <param name="cancellationToken">An optional signal used as a cancellation token that allows the consumers to attempt cancellation of the "creation operation". This is not guaranteed to cancel, as it's possible the underlying storage provider finishes before cancellation.</param>
    /// <returns>An asynchronous task representing the "read all operation".</returns>
    Task<IEnumerable<TItem>> ReadAllItemsAsync<TItem>(
        Func<TItem, bool> matching,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Reads all items as an asynchronous enumerable.
    /// </summary>
    /// <typeparam name="TItem">The type of the item to read.</typeparam>
    /// <param name="matching">A predicate used to match on.</param>
    /// <param name="cancellationToken">An optional signal used as a cancellation token that allows the consumers to attempt cancellation of the "creation operation". This is not guaranteed to cancel, as it's possible the underlying storage provider finishes before cancellation.</param>
    /// <returns>An asynchronous task representing the "read all operation".</returns>
    public async IAsyncEnumerable<TItem?> ReadAllItemsAsAsyncEnumerable<TItem>(
        Func<TItem, bool> matching,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        matching ??= static (TItem item) => true;

        var items = await ReadAllItemsAsync(matching, cancellationToken);

        if (items is null)
        {
            yield break;
        }

        foreach (var item in items ?? [])
        {
            if (matching?.Invoke(item) is false)
            {
                break;
            }

            yield return item ?? default;
        }
    }
}
