
namespace _0_Framework.Application
{
    public class OpretaionResult
    {
        public string Message { get; set; }
        public bool IsSuccesseded { get; set; }
        public OpretaionResult()
        {
            IsSuccesseded = false;
        }
        public OpretaionResult Successeded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccesseded = true;
            Message = message;
            return this;
        }
        public OpretaionResult Failed(string message)
        {
            IsSuccesseded = false;
            Message = message;
            return this;
        }
    }
}
