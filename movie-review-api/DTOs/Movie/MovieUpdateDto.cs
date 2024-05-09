﻿namespace movie_review_api.DTOs.Movie
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int DurationMins { get; set; }

        public int ReleaseYear { get; set; }

        public int DirectorId { get; set; }
    }
}
