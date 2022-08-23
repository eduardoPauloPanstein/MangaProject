namespace Shared
{
   public class ResponseFactory
    {
        #region Singleton
        private static ResponseFactory _factory;

        public static ResponseFactory CreateInstance()
        {
            if (_factory == null)
            {
                _factory = new ResponseFactory();
            }
            return _factory;
        }

        private ResponseFactory() { }
        #endregion Singleton

        public  Response CreateSuccessResponse()
        {
            return new Response("Operação realizada com sucesso.", true,null);
        }
        public  SingleResponse<T> CreateSingleSuccessResponse<T>(T item)
        {
            return new SingleResponse<T>("Dado coletado com sucesso", true,item,null);
        }
        public DataResponse<T> CreateDataSuccessResponse<T>(List<T> item)
        {
            return new DataResponse<T>("Dados coletados com sucesso", true,item,null);
        }
        public Response CreateFailedResponse(Exception ex)
        {
            return new Response("Erro no banco de dados, contate o administrador.", false,ex);
        }
        public Response CreateNotFoundIdResponse()
        {
            return new Response("Not found ID.", false, null);
        }
        public SingleResponse<T> CreateSingleFailedResponse<T>(Exception ex,T item)
        {
            return new SingleResponse<T>("Erro no banco, contate o administrador.", false,item,ex);
        }
        public DataResponse<T> CreateDataFailedResponse<T>(Exception ex)
        {
            return new DataResponse<T>("Erro no banco, contate o administrador.", false, null,ex);
        }
    }
}
