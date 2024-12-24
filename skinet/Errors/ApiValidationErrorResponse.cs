namespace skinet.Errors
{
    public class ApiValidationErrorResponse() : ApiResponse(400)
    {
        public required IEnumerable<string> Errors { get; set; }
    }
}