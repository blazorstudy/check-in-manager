# Power Automate &ndash; QR코드 생성기

참석자 정보를 읽어들인 후 QR코드를 생성해서 이메일로 보내는 워크플로우입니다.

## 1. 사전 준비사항 &ndash; 참석자 데이터 준비

1. 아래 파워셸 명령어를 이용해서 인증용 GUID를 생성합니다. 기본적으로 50개의 GUID를 `verification-code.csv` 파일로 생성합니다.

   ```powershell
   pwsh ./infra/Get-VerificationCodes.ps1
   ```

2. 생성된 `verification-code.csv` 파일을 열어 `GUID`, `VerificationCode` 값을 엑셀 파일에 붙여넣습니다.
3. 엑셀 파일의 데이터를 Microsoft Lists에 저장합니다.

## 2. 사전 준비사항 &ndash; 커스텀 커넥터 엔드포인트 수정

1. [API &ndash; QR 코드 생성기](./api-qrcode-generator.md) 문서를 참고해서 QR코드 생성기 API를 실행시킨 후, DevTunnel 엔드포인트 URL을 복사합니다.
2. 파워 오토메이트 앱을 열어 QR Code Generator 커스텀 커넥터의 엔드포인트 URL을 수정합니다.

## 3. 워크플로우 실행

1. 파워 오토메이트의 QR Code Generator 워크플로우를 열어서 실행합니다.

