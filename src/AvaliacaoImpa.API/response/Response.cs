namespace AvaliacaoImpa.API.response
{
    public class Response<T>
    {
        public Response(bool success, T? data, IList<string>? errors = null)
        {
            this.success = success;
           this.data = data;
            this. errors = errors;
        }

        public bool success{ get; private set; }
        public T? data { get; private set; }
        public IList<string>? errors { get; private set; } = null;
    }
}
