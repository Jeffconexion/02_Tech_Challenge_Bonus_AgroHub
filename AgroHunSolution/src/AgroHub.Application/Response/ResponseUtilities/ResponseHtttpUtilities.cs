using AgroHub.Application.Response.Page;

namespace AgroHub.Application.Response.ResponseUtilities
{
    public class HttpResponseUtils
    {
        public ApiResponse<T> SuccessfulResponseCreated<T>(T data, string message)
        {
            return new ApiResponse<T>
            {
                Data = data,
                StatusCode = 201,
                Success = true,
                Message = message
            };
        }

        public ApiResponse<T> SuccessfulResponseOk<T>(T data, string message)
        {
            return new ApiResponse<T>
            {
                Data = data,
                StatusCode = 200,
                Success = true,
                Message = message
            };
        }

        public ApiResponse<T> NotFoundResponse<T>(string message)
        {
            return new ApiResponse<T>
            {
                Data = default(T),
                StatusCode = 404,
                Success = false,
                Message = message
            };
        }

        public ApiResponse<T> InternalServerErrorResponse<T>(string message)
        {
            return new ApiResponse<T>
            {
                Data = default(T),
                Error = "Internal server error",
                StatusCode = 500,
                Success = false,
                Message = message
            };
        }

        public ApiResponse<T> SuccessfulResponseWithPagination<T>(List<T> data, int page, int pageSize, int totalItems, int totalPages, string message)
        {
            var productPagination = new Pagination<T>()
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems,
            };

            return new ApiResponse<T>
            {
                Datas = data,
                Pagination = productPagination,
                Error = null,
                StatusCode = 200,
                Success = true,
                Message = message
            };
        }
    }
}
