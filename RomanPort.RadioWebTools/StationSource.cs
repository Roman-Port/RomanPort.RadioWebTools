using RomanPort.RadioWebTools.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.RadioWebTools
{
    public abstract class StationSource
    {
        internal StationProvider provider;

        /// <summary>
        /// Has this station been initialized yet? Many features are not accessible without this.
        /// </summary>
        public bool initialized;

        /// <summary>
        /// The currently playing track
        /// </summary>
        public RadioTrack current_track { get { if (!initialized) { throw new NotInitializedException(); } else { return _currentTrack; }} set { _currentTrack = value; } }
        internal RadioTrack _currentTrack;

        public string band;
        public string callsign;
        public string freq;
        public string name;
        public string description;
        public string website;
        public string logo_url;

        public StationSource(StationProvider provider)
        {
            this.provider = provider;
            this.OnTrackChanged += StationSource_OnTrackChanged;
        }

        private void StationSource_OnTrackChanged(StationSource source, RadioTrack track)
        {
            current_track = track;
        }

        public event TrackChangedEventArgs OnTrackChanged;

        /// <summary>
        /// Changes the active track
        /// </summary>
        /// <param name="track"></param>
        internal void ChangeTrack(RadioTrack track)
        {
            OnTrackChanged(this, track);
        }

        /// <summary>
        /// Actively requests data about this source from the server, may be rate limited
        /// </summary>
        /// <returns></returns>
        public abstract Task Init();

        /// <summary>
        /// Gets the audio stream URL
        /// </summary>
        /// <returns></returns>
        public abstract Task<string> GetStreamUrl();
    }

    public delegate void TrackChangedEventArgs(StationSource source, RadioTrack track);
}
