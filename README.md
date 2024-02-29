# PCTO---Mabalens
## MABAQUIZ - a game with Microsoft Hololens 2
#### In this repository there are all the files for the PCTO activity of MABALENS team, visit the site https://benedettabe.github.io/home.html to learn more

## Requirements
The game requires a pc and Microsoft Hololens 2

## What is MABAQUIZ?
MABAQUIZ is a quiz on a chosen topic and diffculty, selected in the menu.
There are several topics: history, geography, sport, science, music and mathematic.
When the game starts the player will see the question and four possible answers. 
With the arm the user will have to select the answer that he considers correct to collect point.

## How to play at Mabaquiz
### If you don't have Unity and Visual Studio install them follow the step below or follow the tutorial https://learn.microsoft.com/it-it/training/paths/beginner-hololens-2-tutorials/
* download Unity from https://www.freecodecamp.org/news/how-to-write-a-good-readme-file
* download the zip folder from the repository and then extract
* open Unity, if it's necessary create an account and log in
* waiting for the download of Unity version
* go on 'Installs' the click on the settings on the right then on 'Add moduls', flag on: 'Visual Studio Community', 'Universal Windows Platform Build Support',  'Windows Build Support (IL2CPP)', 'Windows Dedicated Server Build Support'
* click on the arrow of the add button and press "add project from disk"
* select the folder containing the previously extracted game
* download Mixed Reality Feature Tool from https://www.microsoft.com/en-us/download/details.aspx?id=102778 and run the file MixedRealityFeatureTool.exe just installed
* click on start
* insert the path of the project and click on Discover features
* on MRTK3 click on select all, then on Platform Support click on '+' and flag Mixed Reality OpenXR Plugin, now click select all for Spatial Audio, finally click on Get Features
* click on 'import', then 'Approve', the unity project will be updated.
* Go back on unity hub and double click on your project to open it
* when the project is open click on 'Edit' then on 'Project settings'
  * go on MRTK3, click on the arrow of profile and select MRTKProfile
  * go on XR Plug-in Management then select the Windows icon and flag the 'OpenXR' and 'Microsot Hololens feature group'
    * go on 'OpenXR'(in XR Plug-in Management) click on '+' under 'Enable Interaction Profile' and select 'Microsoft hand interaction profile' and 'Eye Gaze interaction profile'
      * under 'OpenXR Feature Groups' flag 'Microsoft Hololens'
      * click on All Features and flag 'hand tracking' and 'motion controller model'
    * go on 'Project Validation' then click on 'fix all'
* close Project settings page and click on 'File', then 'build settings'
* select 'Universal Windows Platform' in the platform list
* switch the 'Architecture' to 'ARM 64-bit'
* click on 'Switch platform'
* create a new folder that will be the destination of the build of the project
* return on Unity and on build settings click on 'Build' than choose the folder that we have create for the destination
* open the folder and open the file (.sln) with 'Visual Studio community'
* open the 'Visual Studio Community Installer' and click on 'edit'
* flag 'cross-platform .NET app UI development...', '.NET desktop development', 'Desktop apllication Development with C++', 'App development for the UWP platform(Universal Windows)', 'Game development with Unity', 'Data science analytics application Languages'
* in the right spot open the menu of 'app development for Unity Platform', click on 'Optional' and flag 'IntelliCode', 'USB device connectivity', 'UWP platform tools(Universal...)', 'UWP platform tools(Universal...)', 'graphical debugger and GPU profiler for DirectX' and click on 'Install'
* open 'Visual Studio' and replace 'Debug' with 'Release', change the architecture with 'ARM 64'
* switch the compile destination to 'Device'
* connect the Microsoft Hololens 2 by cable
* start the compilation
* wear the Hololens and wait until you see the screen 'Made with Unity'


### If you have already Unity and Visual Studio follow the step below
* download the zip folder from the repository and their extract
* create a new folder that will be the destination of the build of the project
* go on Unity and on build settings click on 'Build' than choose the folder that we have create for the destination
* open the folder and open the file (.sln) with 'Visual Studio community'
* open 'Visual Studio Community Installer' and click on 'edit'
* flag 'cross-platform .NET app UI development...', '.NET desktop development', 'Desktop apllication Development with C++', 'App development for the UWP platform(Universal Windows)', 'Game development with Unity', 'Data science analytics application Languages'
* in the right spot open the menu of 'app development for Unity Platform', click on 'Optional' and flag 'IntelliCode', 'USB device connectivity', 'UWP platform tools(Universal...)', 'UWP platform tools(Universal...)', 'graphical debugger and GPU profiler for DirectX' and click on 'Install'
* open 'Visual Studio' and replace 'Debug' with 'Release', change the architecture with 'ARM 64'
* switch the compile destination to 'Device'
* connect the Microsoft Hololens 2 by cable
* start the compilation
* wear the Hololens and wait until you see the screen 'Made with Unity'

Enjoy the game
