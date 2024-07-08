using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using libAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace libAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(2000)]
        public string Title { get; set; } = string.Empty;

        [StringLength(13, MinimumLength = 10)]
        [Column(TypeName = "varchar(13)")]
        public string? ISBM { get; set; } = string.Empty;

        [Range(1, short.MinValue)]
        public short PageCount { get; set; }

        [Range(-4000, 2100)]
        public short PublishingYear { get; set; }
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int PrintCount { get; set; }
        public bool Banned { get; set; }

        [Range(0, 5)]
        public float Rating { get; set; }
        public List<Author>? Authors { get; set; }
        public Publisher? Publisher { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
        public List<Language>? Languages { get; set; }
        public Location? Location { get; set; }

    }

}

