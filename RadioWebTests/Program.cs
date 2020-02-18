using RomanPort.RadioWebTools.Providers.IHeartRadio;
using RomanPort.RadioWebTools.Providers.RadioDotCom;
using System;
using System.Threading.Tasks;

namespace RadioWebTests
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            RadioDotComProvider provider = new RadioDotComProvider();
            var station = await provider.GetStationById("529");
            await station.Init();
            station.OnTrackChanged += Station_OnTrackChanged;
            Console.WriteLine(station.name);
            await Task.Delay(-1);
        }

        private static void Station_OnTrackChanged(RomanPort.RadioWebTools.StationSource source, RomanPort.RadioWebTools.RadioTrack track)
        {
            Console.WriteLine(source + " / " + track.title);
        }
    }
}
