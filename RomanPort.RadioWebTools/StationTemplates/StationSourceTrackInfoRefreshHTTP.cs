using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RomanPort.RadioWebTools.StationTemplates
{
    public abstract class StationSourceTrackInfoRefreshHTTP : StationSource
    {
        private Timer trackInfoRefreshTimer;

        public StationSourceTrackInfoRefreshHTTP(StationProvider provider) : base(provider)
        {
            
        }

        public override async Task Init()
        {
            //Get current track
            await RefreshCurrentTrack();

            //Set track info refresh timer
            trackInfoRefreshTimer = new Timer(5000);
            trackInfoRefreshTimer.Elapsed += TrackInfoRefreshTimer_Elapsed;
            trackInfoRefreshTimer.AutoReset = true;
            trackInfoRefreshTimer.Start();
        }

        private void TrackInfoRefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RefreshCurrentTrack();
        }

        private async Task RefreshCurrentTrack()
        {
            //Get currently playing track
            RadioTrack current = await GetCurrentTrack();
            string currentId = current == null ? null : current.id;
            string previousId = _currentTrack == null ? null : _currentTrack.id;

            //Check if this is a new track
            if (currentId == previousId)
                return;

            //Update track
            ChangeTrack(current);
        }

        internal abstract Task<RadioTrack> GetCurrentTrack();
    }
}
