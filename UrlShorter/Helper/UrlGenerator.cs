using System;
using System.Text;
using UrlShorter.Data.Interfaces;

namespace UrlShorter.Helper
{
	public class UrlGenerator
	{
        private static readonly string CaracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string GenerarUrlCorta()
        {
            Random random = new Random();
            StringBuilder urlCorta = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                int indice = random.Next(CaracteresPermitidos.Length);
                urlCorta.Append(CaracteresPermitidos[indice]);
            }

            return urlCorta.ToString();
        }
    }
}

