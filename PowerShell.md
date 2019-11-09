![logo](https://upload.wikimedia.org/wikipedia/commons/a/af/PowerShell_Core_6.0_icon.png)

### Named function params
```powershell
function DoSomething {
	[OutputType([void])]
	param (
		[Parameter(Mandatory = $true)][string] $Param1,
	)
	...
}
```
```powershell
DoSomething -Param1 "Some arg"
```

### Test if path does not exists
```powershell
if(!(Test-Path $path)){
	...
}
```

### Function that return multiple params eg. two strings
```powershell
function DoSomething {
	[OutputType([string], [string])]
	param (
	)

	return $value1, $value2
}
```
```powershell
$value1, $value2 = DoSomething()
```

### Switch param
```powershell
param(
    [switch]$Force
)
```
```powershell
<script>.ps1 -Force
```

### Get location of profile file
```powershell
echo $PROFILE
```