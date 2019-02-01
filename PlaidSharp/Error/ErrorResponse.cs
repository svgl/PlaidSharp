namespace PlaidSharp.Error
{
    public class ErrorResponse : PlaidResponse
    {
        public string ErrorType { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string DisplayMessage { get; set; }

        public override string ToString()
        {
            return $"<Error: ErrorType: {ErrorType}, ErrorCode: {ErrorCode}, ErrorMessage: {ErrorMessage}, DisplayMessage: {DisplayMessage}, RequestId: {RequestId}>";
        }
    }
}
