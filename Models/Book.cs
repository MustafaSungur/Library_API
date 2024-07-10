using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using libAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace libAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [NotMapped]
        public List<short>? AuthorsIds { get; set; }

        [StringLength(2000)]
        public string Title { get; set; } = string.Empty;

        //[StringLength(13, MinimumLength = 10)]
        //[Column(TypeName = "varchar(13)")]
        //public string? ISBM { get; set; } = string.Empty;

        [Range(1, short.MaxValue)]
        public short PageCount { get; set; }

        [Range(-4000, 2100)]
        public short PublishingYear { get; set; }
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int PrintCount { get; set; }
        public bool Banned { get; set; }

        [Range(0, 5)]
        public float Rating { get; set; }

        public int PublisherId { get; set; }
        public int LocationId { get; set; }

		[JsonIgnore]
        [ForeignKey(nameof(PublisherId))]
        public Publisher? Publisher { get; set; }

        public List<SubCategoryBook>? SubCategoryBooks { get; set; }

		public List<LanguageBook>? LanguageBooks { get; set; }


		[JsonIgnore]
		[ForeignKey(nameof(LocationId))]
		public Location? Location { get; set; }

		public List<AuthorBook>? AuthorBooks { get; internal set; }

    }

}

