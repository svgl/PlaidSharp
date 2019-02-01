namespace PlaidSharp.Entities
{
    public class Error
    {
        public string ErrorType { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string DisplayMessage { get; set; }

        public string RequestId { get; set; }

        public override string ToString()
        {
            return $"Error<ErrorType: {ErrorType}, ErrorCode: {ErrorCode}, ErrorMessage: {ErrorMessage}, DisplayMessage: {DisplayMessage}, RequestId: {RequestId}>";
        }
    }
}
