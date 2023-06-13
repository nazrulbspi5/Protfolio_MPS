using MPS.Web.Enum;

namespace MPS.Web.Models
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public ResponseTypes Type { get; set; }
    }
}