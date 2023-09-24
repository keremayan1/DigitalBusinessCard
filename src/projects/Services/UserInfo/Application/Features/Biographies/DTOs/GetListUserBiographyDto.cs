namespace Application.Features.Biographies.DTOs
{
    public class GetListUserBiographyDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BiographyDescription { get; set; }
    }
}
