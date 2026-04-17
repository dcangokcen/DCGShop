# DCGShop - Linux ARM64 Docker Image Build Script
# GitHub Container Registry: ghcr.io/dcgshoptest
# Requires: Docker Desktop with BuildKit + docker login ghcr.io
# Usage:
#   .\build-arm64-images.ps1              # Build all (tag: ghcr.io/dcgshoptest/...)
#   .\build-arm64-images.ps1 -Push        # Build & push to ghcr.io/dcgshoptest
#   .\build-arm64-images.ps1 -Registry "ghcr.io/baskakisi" -Push  # Override registry

param(
    [string]$Registry = "ghcr.io/dcgshoptest",
    [switch]$Push = $false
)

$ErrorActionPreference = "Stop"
$ROOT = $PSScriptRoot

# Ensure a buildx builder that supports linux/arm64 is active
$BUILDER_NAME = "dcgshop-arm64-builder"
$existingBuilder = docker buildx ls | Select-String $BUILDER_NAME
if (-not $existingBuilder) {
    Write-Host "Creating buildx builder for ARM64..." -ForegroundColor Cyan
    docker buildx create --name $BUILDER_NAME --driver docker-container --bootstrap
}
docker buildx use $BUILDER_NAME

# Service definitions: [image-name, dockerfile-path]
$services = @(
    @{ Name = "dcgshop-identityserver";  Dockerfile = "IdentityServer/DCGShop.IdentityServer/Dockerfile" },
    @{ Name = "dcgshop-catalog";         Dockerfile = "Services/Catalog/DCGShop.Catalog/Dockerfile" },
    @{ Name = "dcgshop-basket";          Dockerfile = "Services/Basket/DCGShop.Basket/Dockerfile" },
    @{ Name = "dcgshop-discount";        Dockerfile = "Discount/DCGShop.Discount/Dockerfile" },
    @{ Name = "dcgshop-order";           Dockerfile = "Services/Order/Presentation/DCGShop.Order.WebApi/Dockerfile" },
    @{ Name = "dcgshop-cargo";           Dockerfile = "Services/Cargo/DCGShop.Cargo.WebApi/Dockerfile" },
    @{ Name = "dcgshop-comment";         Dockerfile = "Services/Comment/DCGShop.Comment/Dockerfile" },
    @{ Name = "dcgshop-message";         Dockerfile = "Services/Message/DCGShop.Message/Dockerfile" },
    @{ Name = "dcgshop-payment";         Dockerfile = "Services/Payment/DCGShop.Payment/Dockerfile" },
    @{ Name = "dcgshop-images";          Dockerfile = "Services/Images/DCGShop.Images/Dockerfile" },
    @{ Name = "dcgshop-signalr";         Dockerfile = "Services/SignlRRealTimeApi/DCGShop.SignalRRealTimeApi/Dockerfile" },
    @{ Name = "dcgshop-ocelot-gateway";  Dockerfile = "ApiGateway/DCGShop.OcelotGateway/Dockerfile" },
    @{ Name = "dcgshop-web-ui";          Dockerfile = "Frontends/DCGShop.WebUI/Dockerfile" }
)

$failed = @()

foreach ($svc in $services) {
    $imageName = if ($Registry) { "$Registry/$($svc.Name)" } else { $svc.Name }
    
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host " Building: $imageName" -ForegroundColor Cyan
    Write-Host "========================================" -ForegroundColor Cyan

    $buildArgs = @(
        "buildx", "build",
        "--platform", "linux/arm64",
        "--file", $svc.Dockerfile,
        "-t", $imageName,
        "--load",   # Load into local Docker (use --push instead to push directly)
        "."
    )

    if ($Push) {
        # Replace --load with --push when pushing to a registry
        $buildArgs = $buildArgs | Where-Object { $_ -ne "--load" }
        $buildArgs += "--push"
    }

    Write-Host "docker $($buildArgs -join ' ')" -ForegroundColor DarkGray

    & docker @buildArgs

    if ($LASTEXITCODE -ne 0) {
        Write-Host "FAILED: $($svc.Name)" -ForegroundColor Red
        $failed += $svc.Name
    } else {
        Write-Host "SUCCESS: $imageName" -ForegroundColor Green
    }
}

Write-Host ""
Write-Host "========================================"
if ($failed.Count -eq 0) {
    Write-Host "All images built successfully for linux/arm64!" -ForegroundColor Green
} else {
    Write-Host "The following images FAILED to build:" -ForegroundColor Red
    $failed | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
    exit 1
}
