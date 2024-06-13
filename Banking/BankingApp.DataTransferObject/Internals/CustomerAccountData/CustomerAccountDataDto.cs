namespace BankingApp.DataTransferObject.Internals.CustomerAccountData
{
    public class CustomerAccountDataDto
    {
        public Guid CustomerNumber { get; set; }
        public List<BankingAccountDto> BankingAccounts { get; set; }
    }
}
