# RedM Named Natives Compiler

This is a simple tool that will compile a list of RedM natives into a lua file that can be used in your scripts to use
natives as names.

**NOTE:** This tool is not perfect and may not work with all natives, if you find any issues ~~please open an issue.~~ revert back to using `Citizen.InvokeNative`

## How it works
The tool will get the latest natives from the [RedM natives json](https://runtime.fivem.net/doc/natives_rdr3.json)
and compile them into a lua file that can be used in your scripts.

## Requirements
- A brain

## Usage
1. Download the `natives.lua` latest release from the [releases page](https://github.com/Alexr03/RedmNamedNativesCompiler/releases)
2. Place the `natives.lua` file in your resource folder
3. Add `client_script 'natives.lua'` to your `fxmanifest.lua` file
4. Profit