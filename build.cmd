@echo off
cls


if not exist paket.lock  (
    .paket\paket.bootstrapper.exe
    .paket\paket.exe install
)

packages\FAKE\tools\Fake.exe %* --fsiargs build.fsx