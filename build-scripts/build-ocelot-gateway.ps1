# Build: dcgshop-ocelot-gateway → ghcr.io/dcgshoptest/dcgshop-ocelot-gateway (linux/arm64)
param([string]$Registry = "ghcr.io/dcgshoptest", [switch]$Push)
$Tag = if ($Registry) { "$Registry/dcgshop-ocelot-gateway" } else { "dcgshop-ocelot-gateway" }
$buildArgs = @("buildx","build","--platform","linux/arm64","-f","ApiGateway/DCGShop.OcelotGateway/Dockerfile","-t",$Tag)
if ($Push) { $buildArgs += "--push" } else { $buildArgs += "--load" }
$buildArgs += "."
Write-Host "Building $Tag ..." -ForegroundColor Cyan
& docker @buildArgs
if ($LASTEXITCODE -eq 0) { Write-Host "SUCCESS: $Tag" -ForegroundColor Green } else { Write-Host "FAILED: $Tag" -ForegroundColor Red; exit 1 }
