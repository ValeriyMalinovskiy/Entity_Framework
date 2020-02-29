﻿using System;
using System.Collections.Generic;

namespace _2020._02._15_Fluent_API_3.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int Time { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ReleaseCountry { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<MovieDirection> MovieDirections { get; set; }
    }
}
