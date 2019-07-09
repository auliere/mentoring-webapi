namespace UniDonors.DataLayer.Models
{
    public class DonorOrganization
    {
        //[FromRoute(Name="donorId")]
        public long DonorId { get; set; }
        //[FromRoute(Name="organizationId")]
        public long OrganizationId { get; set; }
    }
}
