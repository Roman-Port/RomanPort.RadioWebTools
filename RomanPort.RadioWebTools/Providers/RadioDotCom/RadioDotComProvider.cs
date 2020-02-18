using RomanPort.RadioWebTools.Providers.RadioDotCom.NetEntities.LiveStationDataContainer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.RadioWebTools.Providers.RadioDotCom
{
    public class RadioDotComProvider : StationProvider
    {
        public override async Task<StationSource> GetStationById(string id)
        {
            //Try and get data
            LiveStationDataContainer m = await HTTPGetJson<LiveStationDataContainer>("https://api.radio.com/v1/stations/" + id);
            if (m.data == null)
                return null;
            var s = new RadioDotComSource(this, m.data.attributes);
            return s;
        }
    }
}
