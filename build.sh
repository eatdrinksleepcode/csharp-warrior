#!/bin/bash

mono .nuget/nuget.exe Install FAKE -OutputDirectory packages -ExcludeVersion -Version 2.15.5
mono packages/FAKE/tools/Fake.exe build.fsx
