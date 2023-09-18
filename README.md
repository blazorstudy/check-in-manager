# Check-in Manager

QR 코드로 참가자 정보를 생성하고 스캔한 후 프린트합니다.

## 전제조건

* 이벤트 참석자의 데이터는 [온오프믹스](https://onoffmix.com/)에서 제공하는 엑셀 파일 형식을 기준으로 합니다.
* [망고슬래브](https://mangoslab.com)의 [네모닉 라벨 프린터(MIP-001)](https://nemonicbiz.com/product/%eb%84%a4%eb%aa%a8%eb%8b%89%eb%9d%bc%eb%b2%a8-%eb%9d%bc%eb%b2%a8%ed%94%84%eb%a6%b0%ed%84%b0-%eb%9d%bc%eb%b2%a8-3x2%ec%9d%b8%ec%b9%98-%ec%9a%a9%ec%a7%80%ec%a0%9c%ea%b3%b5/)를 사용합니다.
* 프린트 기능은 맥OS에서 동작합니다.

## 사전 준비사항

### 호스트 PC (맥OS 기준)

* [.NET 8.0 SDK](https://dotnet.microsoft.com/ko-kr/download/dotnet/8.0)를 설치합니다.
* `fonts` 폴더 아래의 나눔고딕 폰트를 설치합니다.
* 아래 순서를 따라 프린터 드라이버를 설치하고 프린터를 연결합니다.
  1. 아래 명령어를 통해 프린터 드라이버를 설치합니다.

     ```bash
     sudo mkdir /Library/Printers
     sudo cp ./drivers/cups/nemonic/nemonic.icns /Library/Printers/nemonic.icns
     sudo cp ./drivers/cups/nemonic/rastertonemonic /usr/libexec/cups/filter/rastertonemonic
     sudo chown root /usr/libexec/cups/filter/rastertonemonic
     ```

  2. 네모닉 라벨 프린터와 호스트 PC를 연결합니다.
  3. 호스트 PC에서 네모닉 라벨 프린터를 새 프린터로 추가합니다.
  4. 드라이버 소프트웨어 선택이 필요한 경우, [Nemonic_MIP_001.ppd](./drivers/cups/nemonic/Nemonic_MIP_001.ppd) 파일을 선택합니다.

### 개발 PC

* [.NET 8.0 SDK](https://dotnet.microsoft.com/ko-kr/download/dotnet/8.0)를 설치합니다.
* [Visual Studio](https://visualstudio.microsoft.com/downloads) 혹은 [Visual Studio Code](https://code.visualstudio.com)를 설치합니다.
* Visual Studio Code를 사용할 경우 [C# Dev Kit 익스텐션](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)을 추가로 설치합니다.
* Microsoft 365 구독 + 파워 플랫폼 프리미엄 라이센스가 필요합니다.
  * [Microsoft 365 개발자 프로그램](https://learn.microsoft.com/ko-kr/office/developer-program/microsoft-365-developer-program)과 [파워 앱 개발자 플랜](https://learn.microsoft.com/ko-kr/power-platform/developer/plan)을 사용하면 개발 목적에 한해 무료로 사용할 수 있습니다.

## 시작하기

### QR 코드 생성기

* [API &ndash; QR 코드 생성기](./docs/api-qrcode-generator.md)
* [Power Automate &ndash; QR코드 생성기](./docs/pau-qrcode-generator.md)

### 체크인 프린터

* [API &ndash; 체크인 프린터](./docs/api-checkin-printer.md)
* [Power Automate &ndash; 체크인 스캐너](./docs/pau-checkin-scanner.md)
* [Power Automate &ndash; 체크인 프린터](./docs/pau-checkin-printer.md)
* [Power Apps &ndash; 체크인 키오스크](./docs/paa-checkin-kiosk.md)

## 향후 개선사항

* 다양한 이벤트 플랫폼([페스타](https://festa.io), [이벤터스](https://event-us.kr) 등) 데이터 형식 지원
* 다양한 라벨 프린터 지원
* 윈도우즈 운영체제 및 리눅스 운영체제(라즈베리파이 포함) 지원
