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

        public ApiResponse<T> SuccessfulResponseWithPagination<T>(List<T> data, string message)
        {
            // realizar o calculo aqui da paginação.
            return new ApiResponse<T>
            {
                DataList = data,
                Pagination = null,
                Error = null,
                StatusCode = 200,
                Success = true,
                Message = message
            };
        }
    }
}
