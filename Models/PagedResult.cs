//using Microsoft.EntityFrameworkCore;

namespace HalaqatManagmentSystem_API.Models;

public class PagedResult<T>
{
    public required List<T> Items { get; set; }

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public bool HasNextPage => PageSize * CurrentPage < TotalItems;
    public bool HasPreveiosPage => CurrentPage > 1;

    //private PagedResult()
    //{

    //}

    //public static async Task<PagedResult<T>> ToPagedResult(IQueryable<T> query, int pageSize, int pageNumber)
    //{
    //    var totalItems = await query.CountAsync();
    //    var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

    //    return new PagedResult<T>
    //    {
    //        Items = items,
    //        TotalItems = totalItems,
    //        PageSize = pageSize,
    //        CurrentPage = pageNumber,
    //        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
    //    };
    //}
}
