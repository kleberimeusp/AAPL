
namespace APP.Model
{
    public class Response
    {
        public object Data { get; private set; }
        public Enums.ResponseStatus Status { get; private set; }
        public string Message { get; private set; }

        public Response(object data)
        {
            this.Data = data;
            this.Status = Enums.ResponseStatus.SUCCESS;
        }

        public Response(Enums.ResponseStatus status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
