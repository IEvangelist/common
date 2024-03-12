namespace Common.Patterns.Repository;

/// <summary>
/// Represents a repository that supports write operations.
/// </summary>
public interface IWriteOnlyRepository
{
    /// <summary>
    /// Creates the given <paramref name="item"/> in the repository, by persisting it to the underlying storage provider.
    /// </summary>
    /// <typeparam name="TItem">The type of the item to create.</typeparam>
    /// <param name="item">The item instance.</param>
    /// <param name="cancellationToken">An optional signal used as a cancellation token that allows the consumers to attempt cancellation of the "creation operation". This is not guaranteed to cancel, as it's possible the underlying storage provider finishes before cancellation.</param>
    /// <returns>An asynchronous task representing the "creation operation".</returns>
    Task<TItem> CreateItemAsync<TItem>(
        TItem item,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the given <paramref name="item"/> in the repository, by updating an existing update in the underlying storage provider.
    /// </summary>
    /// <typeparam cref="TItem">The type of the item to update.</typeparam>
    /// <param name="item">The item instance.</param>
    /// <param name="cancellationToken">An optional signal used as a cancellation token that allows the consumers to attempt cancellation of the "update operation". This is not guaranteed to cancel, as it's possible the underlying storage provider finishes before cancellation.</param>
    /// <returns>An asynchronous task representing the "update operation".</returns>
    Task<TItem> UpdateItemAsync<TItem>(
        TItem item,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the given <paramref name="item"/> in the repository, by deleting an existing item in the underlying storage provider.
    /// </summary>
    /// <typeparam cref="TItem">The type of the item to delete.</typeparam>
    /// <param name="item">The item instance.</param>
    /// <param name="cancellationToken">An optional signal used as a cancellation token that allows the consumers to attempt cancellation of the "deletion operation". This is not guaranteed to cancel, as it's possible the underlying storage provider finishes before cancellation.</param>
    /// <returns>An asynchronous task representing the "delete operation".</returns>
    Task<TItem> DeleteItemAsync<TItem>(
        TItem item,
        CancellationToken cancellationToken = default);
}
