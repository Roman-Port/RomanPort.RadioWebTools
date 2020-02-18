using RomanPort.RadioWebTools.Providers.RadioDotCom.NetEntities.LiveStationDataContainer;
using RomanPort.RadioWebTools.Providers.RadioDotCom.NetEntities.CurrentTrackMetadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.RadioWebTools.Providers.RadioDotCom
{
    public class RadioDotComSource : StationTemplates.StationSourceTrackInfoRefreshHTTP
    {
        private LiveStationData data;

        public RadioDotComSource(StationProvider provider, LiveStationData data) : base(provider)
        {
            this.data = data;

            //Set data
            this.band = data.bband;
            this.callsign = data.callsign.Substring(0, 4);
            this.freq = data.frequency;
            this.name = data.name;
            this.description = data.description;
            this.website = data.website;
            this.logo_url = data.square_logo_large;
        }

        public override async Task Init()
        {
            await base.Init();
            initialized = true;
        }

        /// <summary>
        /// Fetches the current track and sends events if it was changed
        /// </summary>
        /// <returns></returns>
        internal override async Task<RadioTrack> GetCurrentTrack()
        {
            CurrentTrackMetadataContainer c = await provider.HTTPGetJson<CurrentTrackMetadataContainer>("https://api.radio.com/v1/stations/" + data.id + "/now_playing");
            if (c.data == null)
                return null;
            if (c.data.@event == null)
                return null;
            if (c.data.@event.current_event == null)
                return null;
            CurrentTrackMetadata m = c.data.@event.current_event;
            return new RadioTrack
            {
                title = m.title,
                artist = m.artist,
                album = m.album,
                image_url = m.imageUrlHd,
                id = m.ufId
            };
        }

        public override async Task<string> GetStreamUrl()
        {
            throw new NotImplementedException();
        }
    }
}
