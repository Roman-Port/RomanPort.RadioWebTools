using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.RadioWebTools.Providers.IHeartRadio.NetEntities.CurrentTrackMeta
{
    public class Meta
    {
        public int offset { get; set; }
        public int pageSize { get; set; }
        public int totalSize { get; set; }
    }

    public class CurrentTrackMetadata
    {
        public int artistId { get; set; }
        public int albumId { get; set; }
        public int trackId { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public int trackDuration { get; set; }
        public string imagePath { get; set; }
        public bool explicitLyrics { get; set; }
        public int lyricsId { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public string dataSource { get; set; }
    }

    public class CurrentTrackMetadataContainer
    {
        public Meta meta { get; set; }
        public List<CurrentTrackMetadata> data { get; set; }
    }
}
