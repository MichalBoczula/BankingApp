using BankingApp.DataTransferObject.Enums;

namespace BankingApp.DataTransferObject.Internals.CutomerPersonalData
{
    public class PhoneDto
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }
        public VerificationStatusEnum VerificationStatus { get; set; }
    }
}
