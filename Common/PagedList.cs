using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Common
{
    public class PagedList<T> : List<T>
    {
		public Pagination Pagination { get; set; }
		public List<T> Items { get; set; }

		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			Pagination = new Pagination(count, pageNumber, pageSize);
			Items = items;
		}

		public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}

	}

	public class Pagination
    {
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }

		public bool HasPrevious => CurrentPage > 1;
		public bool HasNext => CurrentPage < TotalPages;

		public Pagination(int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
		}
	}

}
