using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MagCoders.Orders.Shared.Abstractions.Extensions;

/// <summary>
/// OrderedQueryableExtension class.
/// </summary>
public static class OrderedQueryableExtension
{
	/// <summary>
	/// Pagination extension method.
	/// </summary>
	/// <typeparam name="T">Entity type.</typeparam>
	/// <param name="query">Query.</param>
	/// <param name="pageableQuery">Paging criteria.</param>
	/// <returns>Paginated query.</returns>
	public static IQueryable<T> Paginate<T>(this IQueryable<T> query, IPageableQuery pageableQuery)
	{
		var result = query.Skip(pageableQuery.PageSize * (pageableQuery.PageIndex - 1)).Take(pageableQuery.PageSize);
		return result;
	}

	/// <summary>
	/// Sorting extension method.
	/// </summary>
	/// <typeparam name="T">Type of queryable.</typeparam>
	/// <param name="source">Query.</param>
	/// <param name="sortDescriptors">Sort criteria.</param>
	/// <returns>Sorted query.</returns>
	public static IQueryable<T> Sort<T>(this IQueryable<T> source, List<SortDescriptor> sortDescriptors)
	{
		if (sortDescriptors.IsNullOrEmpty())
		{
			return source;
		}

		if (!typeof(T).GetProperties().Any(x => x.Name == sortDescriptors[0].ColumnName))
		{
			throw new InvalidOperationException($"Sorting on column {sortDescriptors[0].ColumnName} is not allowed.");
		}

		var query = sortDescriptors[0].SortAscending ? source.OrderBy(x => EF.Property<string>(x!, sortDescriptors[0].ColumnName)) : source.OrderByDescending(x => EF.Property<string>(x!, sortDescriptors[0].ColumnName));

		foreach (var sortDescriptor in sortDescriptors.Skip(1))
		{
			if (!typeof(T).GetProperties().Any(x => x.Name == sortDescriptor.ColumnName))
			{
				throw new InvalidOperationException($"Sorting on column {sortDescriptor.ColumnName} is not allowed.");
			}

			query = sortDescriptor.SortAscending ? query.ThenBy(x => EF.Property<string>(x!, sortDescriptors[0].ColumnName)) : query.ThenByDescending(x => EF.Property<string>(x!, sortDescriptors[0].ColumnName));
		}

		return query;
	}
}