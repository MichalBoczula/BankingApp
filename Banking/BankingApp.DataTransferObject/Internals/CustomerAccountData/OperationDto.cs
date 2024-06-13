using BankingApp.DataTransferObject.Enums;

namespace BankingApp.DataTransferObject.Internals.CustomerAccountData
{
    public class OperationDto
    {
        public OperationTypeEnum OperationType { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
