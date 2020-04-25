# To Do List [Electron.net / Net Core]

## Why another to do list app
To do list app is an effective way to explore a tech stack. The purpose of this app is to explore electron.net APIs using .net core (C#). **This app MUST NOT be used for any real purpose except reading code**.

## What do I want to implement
1. Three level of to dos - workspace, folder and tasks
2. Save to database (sqlite or json file)`
3. Full text search (with option to restrict search within workspace)
4. Basic NLP for tasks
5. Keyboard shortcuts
6. Not yet decided

# Learnings
1. Begin with ASP.net core web application. I started with console app and then had to redo with asp.net core app.
2. Install nuget pachage ElectronNET.API. Do not isntall ElectronNET.CLI.
3. Activate Electron.net calling UseElectron(args) from the web builder in program.cs.
4. Activate electron window by updating startup.cs. Add bootstrap method and call it from configure.
  
