using System;
using System.Collections.Generic;
using System.Text;

namespace RomanPort.RadioWebTools
{
    public class RadioTrack
    {
        public string title;
        public string album;
        public string artist;
        public string image_url;
        public string id; //Only important for checking if a *new* song is playing
    }
}
