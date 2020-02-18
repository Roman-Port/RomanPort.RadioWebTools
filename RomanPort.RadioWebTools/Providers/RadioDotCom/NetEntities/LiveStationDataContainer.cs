using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.RadioWebTools.Providers.RadioDotCom.NetEntities.LiveStationDataContainer
{
    public class Market
    {
        public int id { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class StationStream
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class LiveStationData
    {
        public int id { get; set; }
        public string bband { get; set; }
        public string callsign { get; set; }
        public string category { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public string doubleclick_bannertag { get; set; }
        public string doubleclick_prerolltag { get; set; }
        public string facebook { get; set; }
        public string format { get; set; }
        public string frequency { get; set; }
        public int gmt_offset { get; set; }
        public object hero_image { get; set; }
        public bool interactive { get; set; }
        public int interactive_stream_drift { get; set; }
        public string keywords { get; set; }
        public double latitude { get; set; }
        public string listen_live_url { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
        public object napster_id { get; set; }
        public object napster_station_type { get; set; }
        public string nielsen_asset_id { get; set; }
        public string nielsen_station_type { get; set; }
        public object observes_dst { get; set; }
        public string partner { get; set; }
        public int partner_id { get; set; }
        public string partner_name { get; set; }
        public string phonetic_name { get; set; }
        public int popularity { get; set; }
        public string postal_code { get; set; }
        public string primary_color { get; set; }
        public int r20id { get; set; }
        public string secondary_color { get; set; }
        public string site_slug { get; set; }
        public string slogan { get; set; }
        public string slug { get; set; }
        public string square_logo_large { get; set; }
        public string square_logo_small { get; set; }
        public string state { get; set; }
        public int status { get; set; }
        public object stream_provider_id { get; set; }
        public object stream_provider_name { get; set; }
        public string stream_type { get; set; }
        public int tag_station_id { get; set; }
        public object text_number { get; set; }
        public int triton_id { get; set; }
        public string triton_name { get; set; }
        public string twitter { get; set; }
        public string website { get; set; }
        public Market market { get; set; }
        public List<object> activity { get; set; }
        public List<Genre> genre { get; set; }
        public List<object> mood { get; set; }
        public List<object> parent_stations { get; set; }
        public List<object> child_stations { get; set; }
        public List<StationStream> station_stream { get; set; }
        public object interactive_stream_url { get; set; }
        public int market_id { get; set; }
        public string market_name { get; set; }
        public List<string> genre_name { get; set; }
        public List<object> activity_name { get; set; }
        public List<object> mood_name { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
    }

    public class Data
    {
        public string type { get; set; }
        public int id { get; set; }
        public LiveStationData attributes { get; set; }
        public Links links { get; set; }
    }

    public class LiveStationDataContainer
    {
        public Data data { get; set; }
    }
}
