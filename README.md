# embeddinator-weather

Embedding .NET code into your iOS, Android, and macOS applications. See the getting started at: https://github.com/mono/Embeddinator-4000

Current documentation only tested on:
* Visual Studio for Mac
* Xcode 8.3
* Android Studio 2.3.3
* Latest Embeddinator Package

### Getting Started

Install the latest version of Embeddinator from: https://mono.github.io/Embeddinator-4000/

### Getting Started for macOS

1. Open Weather.sln
2. Build WeatherNet, which is a .NET library targeting 4.6.2 that can be consumed in a mac application
3. Right click on WetherNet project and note the build output
...We are running this command ```/Library/Frameworks/Xamarin.Embeddinator-4000/Commands/objcgen --debug --outdir=output -c bin/Debug/Weather.dll```
4. This will run embeddinator and output all files needed for macOS: bindings.h, embeddinator.h, glib.h, libWeather.dylib, mono_embeddinator.h, mono-support.h, objc-support.h from the output folder and in bin/Debug you will find  Weather.dll.
5. Open MyWeatherMac.xcodeproj, note that these file will be already references under embeddinator. Ensure that you update these files which live in MyWeatherMac/MyWeatherMac, or copy and paste them there.
6. Ensure in project settings under build phases that the .dylib is set to code sign on copy and is a framework. Ensure that Weatehr.dll is an executable that is also set to code sign on copy
7. Run app

### Getting Started for iOS
1. Open Weather.sln
2. Build WeatheriOS, which is a Xamarin.iOS library that can be consumed in a iOS application
3. Right click on WetheriOS project and note the build output
...We are running this command ```/Library/Frameworks/Xamarin.Embeddinator-4000/Commands/objcgen bin/Debug/WeatheriOS.dll --target=framework --platform=iOS --outdir=output -c --debug```
4. This will run embeddinator and output all files needed for iOS: WeatheriOS.framework
5. Open MyWeatheriOS.xcodeproj, note that these file will be already references under embeddinator. Ensure that you update the framework which lives in MyWeatheriOS, or copy and paste it there.
6. Ensure in project settings under build phases that the .framework is set to code sign on copy and is an embedded framework. 
7. Run the app