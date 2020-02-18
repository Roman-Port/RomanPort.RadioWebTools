# RomanPort.RadioWebTools
This library allows you to get information, events, and audio stream from a variety of radio streaming services. This was designed with FM/AM radio stations in mind.

## Supported Providers
* radio.com
* IHeartRadio

## Using the Library
### Providers
Providers are the websites that are used to stream radio stations. Once you've added this as a reference, you'll need to set up providers for each provider of choice:
```c#
IHeartRadioProvider iheart = new IHeartRadioProvider();
RadioDotComProvider radioDotCom = new RadioDotComProvider();
```
This will set up an IHeartRadio and radio.com provider.

### Getting Listings
This feature isn't implemented yet. It should be in the near future. For now, skip this step and use the next step.

### Getting Radio Stations by ID
Radio stations have a unique ID within the databases of their providers. It can usually be found very easily by looking at the provider's website. They are numberical. As an example, I will be using 104.1 JACK FM's ID of ``529`` from radio.com.

To get a station by it's ID, use the ``GetStationById`` function of the provider and pass in the ID, like this:
```c#
await radioDotCom.GetStationById("529")
```
This will return a ``StationSource`` object that can be used. The ``StationSource`` is only really useful for getting information (such as name, frequency, callsign, etc.) in it's current state.

### Receiving Events and Information
To receive events (such as track changes) and other information about the station (like the current track) you'll need to run the ``Init`` function on the ``StationSource``
```c#
await s.Init();
```
__This will create an additional call to the provider's server__ that will potentially cause rate limiting. Only use if you need the information.

Once that is done, you can subscribe to the ``OnTrackChanged`` event to get notified when the track changes. You'll get a ``RadioTrack`` object in return:
```c#
s.OnTrackChanged += S_OnTrackChanged;

private static void S_OnTrackChanged(StationSource source, RadioTrack track)
{
    //Do what you want with the RadioTrack here 
}
```
You can also get the currently playing track with ``s.current_track``.

### RadioTrack
``RadioTrack``s define the currently playing track. They contain information about the artist, album, name, icon, and ID of the track. On some providers, the currently playing track will be null. This usually occurs during certain events (for example, 92.5 KQRS will cease to update tracks when their night host is on air) or during commercial breaks.  

### Streaming Audio
To stream audio, call the ``GetStreamUrl`` function on the ``StationSource``. You'll, in return, get a URL you can use to stream the audio from the station. **This may not be working right now**.
