# This randomly generates verification codes for the given number of users
Param(
    [int]
    [Parameter(Mandatory=$false)]
    $NumberOfRecords = 50,

    [string]
    [Parameter(Mandatory=$false)]
    $OutputFile = "./verification-codes.csv"
)

$collection = [System.Collections.ArrayList]@()

$guids = Invoke-RestMethod "https://www.uuidtools.com/api/generate/v4/count/$NumberOfRecords"
$codes = [int[]]::new($NumberOfRecords) | ForEach-Object { Get-Random -Minimum 100000 -Maximum 999999 }

$guids | ForEach-Object {
    $i = [array]::IndexOf($guids, $_);
    $item = @{ GUID = $_; VerificationCode = $codes[$i]; };
    $collection.Add($item)
}

"GUID,VerificationCode" | Out-File -FilePath $OutputFile -Append
$collection | ForEach-Object { "$($_.GUID),$($_.VerificationCode)" | Out-File -FilePath $OutputFile -Append }
