namespace TurkeyCities.API.Domain.Entities.Models
{
    public  class ResponseModel<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
    }
}
