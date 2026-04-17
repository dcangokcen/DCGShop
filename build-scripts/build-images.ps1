# Build: dcgshop-images → ghcr.io/dcgshoptest/dcgshop-images (linux/arm64)
param([string]$Registry = "ghcr.io/dcgshoptest", [switch]$Push)
$Tag = if ($Registry) { "$Registry/dcgshop-images" } else { "dcgshop-images" }
$buildArgs = @("buildx","build","--platform","linux/arm64","-f","Services/Images/DCGShop.Images/Dockerfile","-t",$Tag)
if ($Push) { $buildArgs += "--push" } else { $buildArgs += "--load" }
$buildArgs += "."
Write-Host "Building $Tag ..." -ForegroundColor Cyan
& docker @buildArgs
if ($LASTEXITCODE -eq 0) { Write-Host "SUCCESS: $Tag" -ForegroundColor Green } else { Write-Host "FAILED: $Tag" -ForegroundColor Red; exit 1 }
