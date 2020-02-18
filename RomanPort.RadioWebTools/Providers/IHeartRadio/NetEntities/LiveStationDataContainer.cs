using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.RadioWebTools.Providers.IHeartRadio.NetEntities.LiveStationData
{
    public class Streams
    {
        public string pls_stream { get; set; }
        public string secure_pls_stream { get; set; }
    }

    public class Market
    {
        public string name { get; set; }
        public string marketId { get; set; }
        public int sortIndex { get; set; }
        public string city { get; set; }
        public int stateId { get; set; }
        public string stateAbbreviation { get; set; }
        public int cityId { get; set; }
        public string country { get; set; }
        public int countryId { get; set; }
        public bool origin { get; set; }
        public bool primary { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sortIndex { get; set; }
        public bool primary { get; set; }
    }

    public class Feeds
    {
        public string feed { get; set; }
        public string enableTritonTracking { get; set; }
    }

    public class LiveStationData
    {
        public int id { get; set; }
        public double score { get; set; }
        public string name { get; set; }
        public string responseType { get; set; }
        public string description { get; set; }
        public string band { get; set; }
        public string callLetters { get; set; }
        public string logo { get; set; }
        public string freq { get; set; }
        public int cume { get; set; }
        public string countries { get; set; }
        public Streams streams { get; set; }
        public bool isActive { get; set; }
        public string modified { get; set; }
        public List<Market> markets { get; set; }
        public List<Genre> genres { get; set; }
        public Feeds feeds { get; set; }
        public string format { get; set; }
        public string provider { get; set; }
        public string rds { get; set; }
        public string website { get; set; }
        public string link { get; set; }
    }

    public class LiveStationDataContainer
    {
        public int duration { get; set; }
        public int total { get; set; }
        public List<LiveStationData> hits { get; set; }
    }
}
