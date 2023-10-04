﻿using System;
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

            XYZ urlModel = new XYZ()
            {
                Id = urlDto.Id,
                OriginalUrl = urlDto.OriginalUrl,
                ShortenedUrl = shortUrl
            };

            _context.Urls.Add(urlModel);
            _context.SaveChanges();
            return true;
        }

        public XYZ SearchUrlByShortUrl(string shortUrl)
        {
            return _context.Urls.Where(u => u.ShortenedUrl == shortUrl).FirstOrDefault();
        }
    }
}
