
using System.Collections.Generic;
using System.Linq;

namespace _01_PakhshinoQuery.Contract.Paging
{
    public static class PagingExtensions
    {
        public static IEnumerable<T> Paging<T>(this IEnumerable<T> queryable, BasePaging pager)
        {
            return queryable.Skip(pager.SkipEntity).Take(pager.TakeEntity);
        }
    }
}
