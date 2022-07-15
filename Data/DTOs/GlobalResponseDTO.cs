namespace LibraryManagementApi.Data.DTOs
{
    public class GlobalResponseDTO
    {
        public GlobalResponseDTO(string message, dynamic data, bool status=true ,dynamic errors=null)
        {
            Status = status;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Errors { get; set; }
    }
}
