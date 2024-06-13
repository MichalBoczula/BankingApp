using BankingApp.DataTransferObject.Enums;

namespace BankingApp.DataTransferObject.Internals.CustomerAccountData
{
    public class BankingAccountDto
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public List<OperationDto> Operations { get; set; }
    }
}
