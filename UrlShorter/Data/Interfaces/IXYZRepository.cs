using System;
using UrlShorter.Models;

namespace UrlShorter.Data.Interfaces
{
	public interface IXYZRepository
	{
		XYZ GetOriginalUrl(int id);
		bool ExistUrl(int Id);
        bool CreateUrl(XYZForCreationDto urlModel, string shortUrl);
		XYZ SearchUrlByShortUrl(string shortUrl);
		int IncreaseVisits(int id);
    }
}

