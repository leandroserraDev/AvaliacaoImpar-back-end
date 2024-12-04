namespace AvaliacaoImpa.API.response
{
    public class Response<T>
    {
        public Response(bool success, T? result, IList<string>? errors = null)
        {
            this.success = success;
           this.result = result;
            this. errors = errors;
        }

        public bool success{ get; private set; }
        public T? result { get; private set; }
        public IList<string>? errors { get; private set; } = null;
    }
}
