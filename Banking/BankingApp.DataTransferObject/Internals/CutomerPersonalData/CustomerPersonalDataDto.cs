namespace BankingApp.DataTransferObject.Internals.CutomerPersonalData
{
    public class CustomerPersonalDataDto
    {
        public Guid CustomerNumber { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public List<EmailDto> Emails { get; set; }
        public List<PhoneDto> Phones { get; set; }
    }
}
