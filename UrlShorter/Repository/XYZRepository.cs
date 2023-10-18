using System;
using System.Runtime.CompilerServices;
using UrlShorter.Data.Interfaces;
using UrlShorter.Models;

namespace UrlShorter.Repository
{
	public class XYZRepository : IXYZRepository
	{
        private readonly UrlShortenerContext _context;

        public XYZRepository(UrlShortenerContext context)
		{
            _context = context;
		}

        public bool ExistUrl(int id)
        {
            return _context.Urls.Any(u => u.Id == id);
        }

        public XYZ GetOriginalUrl(int id)
        {
            return _context.Urls.Where(u => u.Id == id).FirstOrDefault();
        }

        public bool CreateUrl(XYZForCreationDto urlDto, string shortUrl)
        {

            bool existURL = _context.Urls.Any(u => u.OriginalUrl == urlDto.OriginalUrl);
            if (existURL)
                return false;

            XYZ urlModel = new XYZ()
            {
                OriginalUrl = urlDto.OriginalUrl,
                ShortenedUrl = shortUrl,
                CategoryId = urlDto.CategoryId,
                Visits = 0
            };

            _context.Urls.Add(urlModel);
            _context.SaveChanges();
            return true;
        }

        public int IncreaseVisits(int id)
        {
            XYZ urlModel = _context.Urls.Where(u => u.Id == id).FirstOrDefault();
            urlModel.Visits++;
            _context.SaveChanges();
            return urlModel.Visits;
        }

        public XYZ SearchUrlByShortUrl(string shortUrl)
        {
            return _context.Urls.Where(u => u.ShortenedUrl == shortUrl).FirstOrDefault();
        }
    }
}

