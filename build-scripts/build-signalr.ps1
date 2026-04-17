# Build: dcgshop-signalr → ghcr.io/dcgshoptest/dcgshop-signalr (linux/arm64)
param([string]$Registry = "ghcr.io/dcgshoptest", [switch]$Push)
$Tag = if ($Registry) { "$Registry/dcgshop-signalr" } else { "dcgshop-signalr" }
$buildArgs = @("buildx","build","--platform","linux/arm64","-f","Services/SignlRRealTimeApi/DCGShop.SignalRRealTimeApi/Dockerfile","-t",$Tag)
if ($Push) { $buildArgs += "--push" } else { $buildArgs += "--load" }
$buildArgs += "."
Write-Host "Building $Tag ..." -ForegroundColor Cyan
& docker @buildArgs
if ($LASTEXITCODE -eq 0) { Write-Host "SUCCESS: $Tag" -ForegroundColor Green } else { Write-Host "FAILED: $Tag" -ForegroundColor Red; exit 1 }
