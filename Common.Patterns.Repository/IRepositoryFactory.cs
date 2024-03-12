namespace Common.Patterns.Repository;

/// <summary>
/// Represents a repository factory, <see cref="IRepositoryFactory"/>.
/// </summary>
public interface IRepositoryFactory
{
    /// <summary>
    /// Creates an instance of a repository, <see cref="IRepository"/>.
    /// </summary>
    /// <returns>An instance of <see cref="IRepository"/></returns>
    IRepository CreateRepository();

    /// <summary>
    /// Creates an instance of a read-only repository, <see cref="IReadOnlyRepository"/>.
    /// </summary>
    /// <returns>An instance of <see cref="IReadOnlyRepository"/></returns>
    IReadOnlyRepository CreateReadOnlyRepository();

    /// <summary>
    /// Creates an instance of a write-only repository, <see cref="IWriteOnlyRepository"/>.
    /// </summary>
    /// <returns>An instance of <see cref="IWriteOnlyRepository"/></returns>
    IWriteOnlyRepository CreateWriteOnlyRepository();
}

