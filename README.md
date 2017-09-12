# embeddinator-weather

Embedding .NET code into your iOS, Android, and macOS applications. See the getting started at: https://github.com/mono/Embeddinator-4000

Current documentation only tested on:
* Visual Studio for Mac
* Xcode 8.3+
* Android Studio 2.3.3+
* Java JDK 1.8+

### Getting Started

Read the latest documenation fir Embeddinator from: https://mono.github.io/Embeddinator-4000/

This now uses a NuGet package and custom commands to automatically build and export into the specific folder for all projects.

### Getting Started for iOS
1. Open Weather.sln
2. Build WeatheriOS, which is a Xamarin.iOS library that can be consumed in an iOS application
3. Right click on WetheriOS project and note the build output
...We are running this command ```mono '${SolutionDir}/packages/Embeddinator-4000.0.3.0/tools/objcgen.exe' 'bin/Debug/WeatheriOS.dll' --target=framework --platform=iOS --outdir='${SolutionDir}/iosoutput' -c --debug```
4. This will run embeddinator and output all files needed for iOS: WeatheriOS.framework
5. Open MyWeatheriOS.xcodeproj, note that these file will be already references under embeddinator. Ensure that you update the framework which lives in MyWeatheriOS, or copy and paste it there.
6. Ensure in project settings under build phases that the .framework is set to code sign on copy and is an embedded framework. 
7. Run the app

### Getting Started for Android
1. Open Weather.sln
2. Build WeatherAndroid, which is a Xamarin.Android library that can be consumed in an Android application
3. Right click on WeatherAndroid project and note the build output
...We are running this command ```mono '${SolutionDir}/packages/Embeddinator-4000.0.3.0/tools/Embeddinator-4000.exe' '${TargetPath}' --gen=Java --platform=Android --outdir='${SolutionDir}/androidoutput' -c```
4. This will run embeddinator and output all files needed for Android: WeatherAndroid.aar
5. Open MyWeather workspace in Android Studio, note that these file will be already references under embeddinator. Ensure that you update the aar which lives in MyWeatherAndroid, or copy and paste it there.
6. Run the app

### Getting Started for macOS

1. Open Weather.sln
2. Build WeatherNet, which is a .NET library targeting 4.6.2 that can be consumed in a mac application
3. Right click on WetherNet project and note the build output
...We are running this command ```mono '${SolutionDir}/packages/Embeddinator-4000.0.3.0/tools/objcgen.exe' 'bin/Debug/Weather.dll' --target=framework --platform=mac --outdir='${SolutionDir}/macoutput' -c --debug```
4. This will run embeddinator and output all files needed for macOS and copy it into the correct location: Weather.framwork.
5. Open MyWeatherMac.xcodeproj, note that these file will be already references under embeddinator. Ensure that you update these files which live in MyWeatherMac, or copy and paste them there.
7. Run app
