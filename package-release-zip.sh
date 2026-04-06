#!/bin/bash

set -e

Arch="$1"
OutputPath="$2"

remove_mihomo_bundle() {
    local root="$1"
    find "$root" -path "*/bin/mihomo" -prune -exec rm -rf {} + 2>/dev/null || true
    find "$root" -path "*/bin/mihomo*" -type f -exec rm -f {} + 2>/dev/null || true
    find "$root" -path "*/bin/mihomo*" -type l -exec rm -f {} + 2>/dev/null || true
}

OutputArch="v2rayN-${Arch}"
FileName="v2rayN-${Arch}.zip"
TempDir="$(mktemp -d)"
trap 'rm -rf "$TempDir" "./$OutputArch"' EXIT

BundleZip="$TempDir/$FileName"
BundleDir="$TempDir/extracted"
StagePath="./$OutputArch/$OutputArch"

wget -nv -O "$BundleZip" "https://github.com/2dust/v2rayN-core-bin/raw/refs/heads/master/$FileName"
mkdir -p "$BundleDir"
7z x "$BundleZip" -o"$BundleDir" >/dev/null
mkdir -p "$StagePath"

cp -rf "$BundleDir/$OutputArch"/. "$StagePath"
cp -rf "$OutputPath"/. "$StagePath"
remove_mihomo_bundle "$StagePath"

rm -f "$FileName"
7z a -tZip "$FileName" "$StagePath" -mx1 >/dev/null
