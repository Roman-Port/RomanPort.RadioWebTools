using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.RadioWebTools.Providers.RadioDotCom.NetEntities.CurrentTrackMetadata
{
    public class CurrentTrackMetadata
    {
        public string title { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public string imageUrl { get; set; }
        public string imageUrlHd { get; set; }
        public DateTime timePlayed { get; set; }
        public DateTime timePlayedUtc { get; set; }
        public string ufId { get; set; }
        public string primaryAction { get; set; }
        public string teId { get; set; }
        public string trackingId { get; set; }
        public int itemType { get; set; }
        public string category { get; set; }
        public string lookupArtist { get; set; }
        public string lookupTitle { get; set; }
        public List<object> ctas { get; set; }
    }

    public class Event
    {
        public int station_id { get; set; }
        public CurrentTrackMetadata current_event { get; set; }
    }

    public class Data
    {
        public Event @event { get; set; }
    }

    public class CurrentTrackMetadataContainer
    {
        public Data data { get; set; }
    }
}
