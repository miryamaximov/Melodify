namespace Entities
{
    public class Album_DTO
    {
        public int AlbumId { get; set; }

        public string AlbumName { get; set; } = null!;

        public int AlbumSingerId { get; set; }

        public string AlbumSingerFirstName { get; set; }

        public string AlbumSingerLastName { get; set; }

        public DateTime? PublishingDate { get; set; }

        public DateTime? UploadDate { get; set; }

        public string? ImageUrl { get; set; }
    }
}
