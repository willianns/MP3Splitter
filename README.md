## POC Mp3Splitter

Simple tool to use ffmpeg to split a full mp3 song in multiple mp3 tracks

### How to build (Windows, Linux)

Just run dotnet build or publish

### Requirements

Windows - ffmpeg executables can be downloaded at official website https://www.ffmpeg.org/

Linux (Ubuntu) - Just run 'sudo apt install ffmpeg' to grab the dependency

### Usage 

mp3splitter.exe my_file.mp3 [options]

Options:
-f 'required path for ffmpeg executable - for Windows only'

Info: Note the need to have a txt file in the same path as the mp3 file
with the same name (eg my_file.txt) containing the specification of the ranges per line in the following format;
The tracks will be generated in the same mp3 source folder.

Format: {start time} {end time} {trackname without special chars}

Example: hh:mm:ss hh:mm:ss my trackname

### License

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org/>