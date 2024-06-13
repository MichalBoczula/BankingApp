using BankingApp.DataTransferObject.Enums;

namespace BankingApp.DataTransferObject.Internals.CutomerPersonalData
{
    public class EmailDto
    {
        public string Address { get; set; }
        public VerificationStatusEnum VerificationStatus { get; set; }
    }
}
