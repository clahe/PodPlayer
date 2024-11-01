using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public class Validering
    {
        public Validering()
        {


        }

        public bool ArPoddDubbel(string poddNamn, List<Podcast> poddLista)
        {
            return !poddLista.Any(p => p.Rubrik.Equals(poddNamn, StringComparison.OrdinalIgnoreCase));


        }

        public bool IsUrlValid(string rssUrl)
        {
            Uri uri;
            bool rattURL = Uri.TryCreate(rssUrl, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);

            try
            {
                if (!rattURL)
                {
                    throw new Exception("URL-adressen stämmer inte, var vänlig försök igen");
                }
            }

            catch (Exception e)
            {
            }
            return rattURL;

        }
    }
}

