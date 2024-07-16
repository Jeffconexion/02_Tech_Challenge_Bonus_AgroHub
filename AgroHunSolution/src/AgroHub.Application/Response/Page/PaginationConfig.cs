using AgroHub.Domain.Entities;

namespace AgroHub.Application.Response.Page
{
    public static class PaginationConfig
    {
        public static int GetTotalPages(int pageSize, int totalItems)
        {
            return (int)Math.Ceiling(totalItems / (double)pageSize);
        }

        public static List<Product> GetPagination(int page, int pageSize, IEnumerable<Product> productList)
        {
            return productList.Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();
        }
    }
}
