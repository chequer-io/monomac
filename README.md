
https://github.com/AvaloniaUI/monomac 프로젝트가 arm64 cocoa를 지원하지 않기에 커스텀 빌드하여 사용합니다.

`src/generator.csproj`에서 AfterBuild 매직을 부립니다. M1 Mac에서 arch가 꼬이는 경우 빌드가 실패할 수 있습니다. 참고해주세요.

---

This is a fork of MonoMac but with .NET Standard support so it can run on .NET Core.

This will be maintained until such time as Xamarin.Mac runs on .NET Core as it is a much more mature runtime for macOS.

Building:

To build, you must be running on macOS with mono installed, then run the following on the command line:

> ./build.sh
