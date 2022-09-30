namespace Shared.Responses
{
    public class DataResponse<T> : Response
    {
        public DataResponse(string message, bool hasSuccess, List<T> dados, Exception? ex) : base(message, hasSuccess, ex)
        {
            Data = dados;
        }
        public DataResponse()
        {

        }

        public List<T> Data { get; set; }
        public bool IsEmptyData { get { return this.Data == null || this.Data.Count > 0; } }
    }
}
