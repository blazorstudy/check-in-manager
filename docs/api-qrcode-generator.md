# API &ndash; QR 코드 생성기

파워 오토메이트에서 데이터를 받아서 QR 코드를 생성하는 API입니다.

## 시작하기

1. Visual Studio Code를 열고 터미널을 실행합니다.
2. 아래 명령어를 순차적으로 실행시켜 로컬에서 애저 펑션 앱을 실행시킵니다.

   ```powershell
   dotnet restore && dotnet build
   cd src/CheckInManager.Api.QRGenerator
   func start
   ```

3. Visual Studio Code의 port forwarding 기능을 이용해 7071번 포트를 오픈합니다. 이 때 반드시 Visibility 옵션을 `public`으로 설정해 주세요.
