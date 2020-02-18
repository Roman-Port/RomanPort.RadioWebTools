using RomanPort.RadioWebTools.Providers.IHeartRadio.NetEntities.CurrentTrackMeta;
using RomanPort.RadioWebTools.Providers.IHeartRadio.NetEntities.LiveStationData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RomanPort.RadioWebTools.Providers.IHeartRadio
{
    public class IHeartRadioSource : StationTemplates.StationSourceTrackInfoRefreshHTTP
    {
        private LiveStationData data;

        public IHeartRadioSource(StationProvider provider, LiveStationData data) : base(provider)
        {
            this.data = data;

            //Set data
            this.band = data.band;
            this.callsign = data.callLetters.Substring(0, 4);
            this.freq = data.freq;
            this.name = data.name;
            this.description = data.description;
            this.website = data.website;
            this.logo_url = data.logo;
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
            CurrentTrackMetadataContainer c = await provider.HTTPGetJson<CurrentTrackMetadataContainer>("https://us.api.iheart.com/api/v3/live-meta/stream/" + data.id + "/trackHistory?limit=1");
            if (c.data.Count != 1)
                return null;
            var m = c.data[0];
            return new RadioTrack
            {
                title = m.title,
                artist = m.artist,
                album = m.album,
                image_url = m.imagePath,
                id = m.trackId.ToString()
            };
        }

        public override async Task<string> GetStreamUrl()
        {
            throw new NotImplementedException();
        }
    }
}
