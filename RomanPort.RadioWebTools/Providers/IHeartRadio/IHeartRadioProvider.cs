using RomanPort.RadioWebTools.Providers.IHeartRadio.NetEntities.LiveStationData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.RadioWebTools.Providers.IHeartRadio
{
    public class IHeartRadioProvider : StationProvider
    {
        public override async Task<StationSource> GetStationById(string id)
        {
            //Try and get data
            LiveStationDataContainer m = await HTTPGetJson<LiveStationDataContainer>("https://api.iheart.com/api/v2/content/liveStations/"+id);
            if (m.hits.Count != 1)
                return null;
            var s = new IHeartRadioSource(this, m.hits[0]);
            return s;
        }
    }
}
