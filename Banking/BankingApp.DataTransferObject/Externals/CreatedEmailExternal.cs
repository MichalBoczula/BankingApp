using BankingApp.DataTransferObject.Enums;

namespace BankingApp.DataTransferObject.Externals
{
    public class CreatedEmailExternal
    {
        public string Address { get; set; }
        public VerificationStatusEnum VerificationStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
