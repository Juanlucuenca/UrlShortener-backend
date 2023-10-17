using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShorter.Models
{
	public class XYZ
	{
		[Key]
		public int Id { get; set; }
		public string OriginalUrl { get; set; } = string.Empty;
		public string ShortenedUrl { get; set; } = string.Empty;
		public int Visits { get; set; }
		public Category Cateogiry { get; set; }
		public int CategoryId { get; set; }
	}
}