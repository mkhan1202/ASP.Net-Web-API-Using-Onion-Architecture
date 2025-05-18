namespace Presentation_Layer.Controllers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }

        private ApiResponse(bool success, string message, T? data, List<string>? errors, int status)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
            StatusCode = status;
        }

        public static ApiResponse<T> SuccessResponse(T? data, int status, string message="")
        {
            return new ApiResponse<T> ( true, message, data, null, status );
        }

        public static ApiResponse<T> ErrorResponse(List<string> errors, int status, string message="")
        {
            return new ApiResponse<T>(false, message, default(T), errors, status );
        }
    }
}
