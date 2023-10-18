using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using UrlShorter.Data.Interfaces;
using UrlShorter.Helper;
using UrlShorter.Models;

namespace UrlShorter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class XYZController : ControllerBase
	{
		private readonly IXYZRepository _XYZRepository;


        public XYZController(IXYZRepository Repository)
		{
			_XYZRepository = Repository;
		}

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(XYZ))]
        public IActionResult getOriginalUrl([FromRoute] int id)
        {
            bool urlExist = _XYZRepository.ExistUrl(id);
            if (!urlExist)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();
            
            
            return Ok(_XYZRepository.GetOriginalUrl(id));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UrlCreate([FromBody] XYZForCreationDto urlModel)
        {
            UrlGenerator GenerateUrl = new UrlGenerator();
            string shortUrl = GenerateUrl.GenerarUrlCorta();
            return Ok(_XYZRepository.CreateUrl(urlModel, shortUrl));
        }

        [HttpGet("redirectUrl/{shortUrl}")]
        public IActionResult RedirectShortUrl(string shortUrl)
        {
            // Buscar la URL original correspondiente a la URL corta en la base de datos
            XYZ modelUrl = _XYZRepository.SearchUrlByShortUrl(shortUrl);
            if (modelUrl != null)
            {
                _XYZRepository.IncreaseVisits(modelUrl.Id);
                return Redirect(modelUrl.OriginalUrl);
            }
            return NotFound();
        }





    }
}

