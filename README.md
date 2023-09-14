# Check-in Manager

QR 또는 바코드로 참가자 정보를 생성하고 스캔한 후 프린트합니다

## 사전 준비사항

### 준비물
* [네모닉 라벨](https://nemonicbiz.com) 프린터(MIP-001, 네모닉 미니 아님!)

### 호스트 PC
* 네모닉 라벨 드라이버 설치
* `fonts` 폴더의 폰트 설치(나눔고딕)
* .NET 8.0 설치

### 드라이버 설치(Linux/macOS)
1. `driver/Nemonic_MIP_001.ppd` 파일을 `/etc/cups/ppd` 위치로 복사합니다.
2. `driver/nemonic.icns` 파일을  `/Library/Printers/nemonic.icns` 위치로 복사합니다.
3. `driver/rastertonemonic` 파일을 `/usr/libexec/cups/filter/rastertonemonic` 위치로 복사합니다.
4. 방금 복사한 `rasteronemonic` 파일을 소유자를 OS에 맞게 변경합니다(macOS는 `root`). `sudo chown root /usr/libexec/cups/filter/rastertonemonic`
5. 네모닉 라벨 프린터와 호스트 PC를 연결합니다.
6. 호스트 PC에서 네모닉 라벨 프린터를 새 프린터로 추가합니다.
7. 드라이버 소프트웨어 선택이 필요한 경우, 1번에서 복사한 `Nemonic_MIP_001.ppd` 파일을 선택합니다.

## 시작하기

TBD
