# todo-electron-netcore
Yet another ToDo list app written in .Net core and Electron.net

# To Do List [Electron.net / Net Core]

## Why another to do list app
To do list app is an effective way to explore a tech stack. The purpose of this app is to explore electron.net APIs using .net core (C#). **This app MUST NOT be used for any real purpose except reading code**.

## What do I want to implement
1. Three level of to dos - workspace, folder and tasks
2. Save to database (sqlite or json file)
3. Full text search (with option to restrict search within workspace)
4. Basic NLP for tasks
5. Keyboard shortcuts
6. Not yet decided


# Learnings
1. Begin with ASP.net core web application. I started with console app and then had to redo with asp.net core app.
2. Install nuget pachage ElectronNET.API. Do not isntall ElectronNET.CLI.
3. Activate Electron.net calling UseElectron(args) from the web builder in program.cs.
4. Activate electron window by updating startup.cs. Add bootstrap method and call it from configure.
5. Install ElectronNET.CLI as global package - Run in windows command prompt:  dotnet tool install ElectronNET.CLI -g
    - this should give a message that You can invoke the tool using the following command: electronize. Tool 'electronnet.cli' (version '7.30.2') was successfully installed.
6. Initialize electronize. You should get following response:

`
	C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web>electronize init
	Adding our config file to your project...
	Search your .csproj to add the needed electron.manifest.json...
	Found your .csproj: C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\todo-e-nc-web.csproj - check for existing config or update it.
	electron.manifest.json will be added to csproj.
	electron.manifest.json added in csproj!
	Search your .launchSettings to add our electron debug profile...
	Debug profile added!
	Everything done - happy electronizing!
`

7. This creates a file electron.menifest.json.
8. Run: electronize start and wait for some time (only the first electonize start is slode. Next is expected to be faster.) From 1:08 to 1:15 (7 minutes)
    - It also runs `npm install` and  `node install.js` They are also intalling something core-js
    - Ans here you are. The default asp.net core web page is being shows inside an electron window.
9. You can build the app on CLI:
    - electronize build /target win
    - electronize build /target osx
    - electronize build /target linux


### Outoput of running `electronize start` command:

`
C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web>electronize start
Start Electron Desktop Application...
Microsoft Windows [Version 10.0.18363.778]
(c) 2019 Microsoft Corporation. All rights reserved.
C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web>dotnet publish -r win-x64 --output "C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\bin"
Microsoft (R) Build Engine version 16.4.0+e901037fe for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.
  Restore completed in 1.93 min for C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\todo-e-nc-web.csproj.
  todo-e-nc-web -> C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\bin\Debug\netcoreapp3.1\win-x64\todo-e-nc-web.dll
  todo-e-nc-web -> C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\bin\Debug\netcoreapp3.1\win-x64\todo-e-nc-web.Views.dll
  todo-e-nc-web -> C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\bin\
C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web>
node_modules missing in: C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\node_modules
Start npm install...
Microsoft Windows [Version 10.0.18363.778]
(c) 2019 Microsoft Corporation. All rights reserved.
C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host>npm install
 > core-js@3.6.5 postinstall C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\node_modules\core-js
 > node -e "try{require('./postinstall')}catch(e){}"
[96mThank you for using core-js ([94m https://github.com/zloirock/core-js [96m) for polyfilling JavaScript standard library![0m
[96mThe project needs your help! Please consider supporting of core-js on Open Collective or Patreon: [0m
[96m>[94m https://opencollective.com/core-js [0m
[96m>[94m https://www.patreon.com/zloirock [0m
[96mAlso, the author of core-js ([94m https://github.com/zloirock [96m) is looking for a good job -)[0m
 > electron@7.2.3 postinstall C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\node_modules\electron
 > node install.js
npm notice created a lockfile as package-lock.json. You should commit this file.
added 174 packages from 169 contributors and audited 262 packages in 208.858s
4 packages are looking for funding
  run `npm fund` for details
found 0 vulnerabilities
C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host>
ElectronHostHook handling started...
Invoke electron.cmd - in dir: C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\node_modules\.bin
Microsoft Windows [Version 10.0.18363.778]
(c) 2019 Microsoft Corporation. All rights reserved.
C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\node_modules\.bin>electron.cmd "..\..\main.js"
Electron Socket IO Port: 8000
Electron Socket started on port 8000 at 127.0.0.1
ASP.NET Core Port: 8001
stdout: Use Electron Port: 8000
stdout: info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://127.0.0.1:8001
stdout: info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\obj\Host\bin\
ASP.NET Core Application connected... global.electronsocket UgKdGpWcxonM9dAkAAAA 2020-04-25T19:45:23.057Z
stdout: BridgeConnector connected!
stdout: warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
`



