#!/bin/sh

command -v xbuild >/dev/null 2>&1 || { echo >&2 "xbuild - command not found"; exit; }

echo
echo build current release
echo

# ---------------------------------------------
# /target:  Rebuild  Build  Clean  KeepBack
# /toolsversion: 4.0
# /verbosity:  quiet  minimal  normal  detailed  diagnostic
# /property:  TargetFrameworkVersion= v4.5.1  Configuration= Debug | Release   NoLogo= true | false  Platform= "Any CPU" | "x86" | "x64"
# /nologo

xbuild  KeepBack.sln  /target:Rebuild  /toolsversion:4.0  "/property:TargetFrameworkVersion=v4.5.1;Configuration=Release;Platform=Any CPU" /nologo

