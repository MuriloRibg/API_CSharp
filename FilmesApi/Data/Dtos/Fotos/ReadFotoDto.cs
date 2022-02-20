using System;
namespace FilmesApi.Data.Dtos.Fotos
{
    public class ReadFotoDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime PostDate { get; set; }

        public string Description { get; set; }

        public bool AllowComments { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        public int UserId { get; set; }
    }
}
