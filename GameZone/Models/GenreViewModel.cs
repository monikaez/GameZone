﻿using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}