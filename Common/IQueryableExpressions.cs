using System.Linq;
using System.Linq.Dynamic.Core;


namespace WebApi.Common
{
    public class IQueryableExpressions<T>
    {

        public static IQueryable<T> Sort(IQueryable<T> iQuery, Sort sortBy)
        {
            return iQuery.OrderBy(sortBy.SortBy);
        }
   
        public static IQueryable<T> Search(IQueryable<T> iQuery, Search search)
        {
            string query = string.Join(" or ", search.SearchBy.Split(',').Select(item => item + " .Contains(@0)").ToArray());
           
            return iQuery.Where(query, search.KeyWord);
        }
    }
    public class Sort
    {
            public string SortBy { get; set; }
    }
    public class Search
    {
        public string SearchBy { get; set; }
        public string KeyWord { get; set; }
    }

}