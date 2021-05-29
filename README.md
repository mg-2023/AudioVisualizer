# AudioVisualizer
A simple audio spectrum visualizer

## Usage in Unity
(한글 버전은 추후 추가할 예정입니다)

### Playing a music
 1. Import an audio file as a new asset
 2. Display a 'BGM' object in inspector and add an audio file into AudioClip section
 3. In 'Music Manager' script, you can adjust fade-in time and max volume
 4. Hit play button; enjoy the visualized audio!
 
(Adding an audio mixer is optional)

### Bar Color
There are 4 color mode; you can set the color mode in GeneralSettings > Bar Color script
 - Color switching rainbow: both 'Enable Rainbow / Interpolate Color' is on, you can set the color loop timer
 - Original rainbow: only 'Enable Rainbow' is on
 - Smooth transition: only 'Interpolate Color' is on, you can set the two colors (leftmost, rightmost)
 - Alternating colors: both 'Enable Rainbow / Interpolate Color' is off
 
### Setting a font
In 'Canvas' object, there is 'Set Font' script. You just add your custom font in 'Custom Font' section. Job done!
