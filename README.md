# ScriptHelper001
Window based movie scriptwriting tool using GPT. This is a quick update of the tool built by Jim Rutt and described in his podcast https://www.jimruttshow.com/. When I went to look for ScriptHelper001, it was deleted from his GitRepo but I was able to find a fork and get it running.  

## Before starting
Install
- Git
- Visual Studio Code

## Steps
1. **Download C# and DotNet dependencies**
    - https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.204-windows-x64-installer
    - https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net481-developer-pack-offline-installer
    - https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit

2. **Set up and fund an OpenAPI account**
    - https://platform.openai.com/docs/overview

3. **Create an API key**
    - https://platform.openai.com/api-keys

4. **Set up authentication**
    - Create a file called ./openai in the project root dir and paste the key there.
    - https://github.com/OkGoDoIt/OpenAI-API-dotnet?tab=readme-ov-file#authentication
  	 
## Useful links
- https://rogerpincombe.com/openai-dotnet-api
- https://medium.com/@memetic007/scripthelper-001-an-experimental-gpt-4-based-movie-script-writing-program-c755faab46b8

## Important Note about C# OpenAI-API-dotnet Library from Mr Rutt
*For long running processes (pretty much anything running in GPT-4 mode), the NuGet version 1.7.2 of the library 
will timeout after 100 seconds.  The library doesn't offer a way to set the timeout.
I have modified the library to increase the timeout to 1000 seconds.  That is a quick and dirty hack, but it works.
I have uploaded my modified version as OpenAI_API.dll into the project.  DO NOT use the NuGet version until they fix the problem.
There is a github issue open on the problem.  You can monitor it to see if and when they fix it: 
https://github.com/OkGoDoIt/OpenAI-API-dotnet/issues/102*
