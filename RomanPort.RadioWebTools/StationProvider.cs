using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.RadioWebTools
{
    /// <summary>
    /// A provider (for example, radio.com) of a radio station
    /// </summary>
    public abstract class StationProvider
    {
        public readonly HttpClient client;

        public StationProvider()
        {
            this.client = new HttpClient();
        }

        /// <summary>
        /// GETs JSON data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T> HTTPGetJson<T>(string url)
        {
            //Fetch
            var data = await client.GetAsync(url);

            //Get string (FUCK YOU RADIO.COM FOR BREAKING HTTP STANDARD AND GIVING ME YOUR SHITTY ASS GZIPPED DATA AND BREAKING THIS)
            string c;
            if (!data.IsSuccessStatusCode)
                throw new Exception("HTTP Request Failed");

            if (data.Content.Headers.ContentEncoding.FirstOrDefault() == "gzip")
            {
                //FUCK
                using (Stream compressedContent = await data.Content.ReadAsStreamAsync())
                using (GZipStream gz = new GZipStream(compressedContent, CompressionMode.Decompress))
                using (StreamReader sr = new StreamReader(gz))
                {
                    c = await sr.ReadToEndAsync();
                }
            } else
            {
                //This does not need any special decoding
                c = await data.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<T>(c);
        }
        
        /// <summary>
        /// Gets a station by it's provider ID, typically needs to be looked up beforehand
        /// </summary>
        /// <returns></returns>
        public abstract Task<StationSource> GetStationById(string id);
    }
}
