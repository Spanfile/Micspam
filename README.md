Micspam
=======

A WinForms app to play sounds. Use [Virtual Audio Cable](http://software.muzychenko.net/eng/vac.htm) for micspamming.
Basically it's a music player that can play multiple sounds and output to multiple devices at the same time.

Supported formats
-----------------
* MP3 (.mp3)
* Waveform (.wav)
* FLAC (.flac)
* Most AAC formats

The following formats are a big maybe. CSCore says it can load these but they may still cause problems.
* AAC formats that also include video (like .mp4)

Libraries
---------
* [CSCore](http://cscore.codeplex.com/) for audio output
* [TagLib#](https://github.com/mono/taglib-sharp) to read ID3 tags
