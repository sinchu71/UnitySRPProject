  UnitySRPProject  
    Assets  
    Scenes        # Contains all scenes  
    Scripts       # Contains all C# scripts  Ball.cs BallSpawner.cs ObjectPoolig.cs
    ScriptableObject #GameSetting.cs GameSetting.asset
    Plugins       # LeanTween (Tweening Library)  
    Prefabs       # Prefabs for reusable objects  Ball.Prefab
    Materials     # Materials and shaders  
    Textures      # Texture assets  
    .gitignore      # Excludes unnecessary Unity files  
    README.md       # Project documentation  
    UnitySRPProject.sln  # Unity project solution file  
  
UnitySRPProject->Repository
FirstAssign->Unity project folder

Open the Project in Unity
->Ensure you have Unity 2023.3.58 installed.
->Open Unity Hub and click on Open

Ball Spawner with Object Pooling in Unity
This Unity project demonstrates a Ball Spawner System that uses a generic Object Pooling system to efficiently manage the spawning and destruction of balls. The project focuses on improving performance by reusing objects, making it suitable for scenarios involving continuous spawning and destruction of objects.

Features

1. Ball Creation
->Uses a sphere with a default white material.
->Bounces a certain number of times before coming to rest.
->Disappears after a configurable amount of time.
->Stored as a prefab to be managed by the Object Pooler.

2. Ball Spawner System
->Continuously spawns balls within a defined area.
->Limits the maximum number of active balls (e.g., 5 at a time).
Automatically stops spawning when the limit is reached.

3. Object Pooling System

->Efficiently reuses inactive balls instead of creating new ones.
->Generic and standalone, making it reusable for other objects.
->Improves performance and reduces garbage collection.

Technologies Used

->Unity 2023 (SRP Universal 3D)
->C# Scripting
->Object Pooling Design Pattern


Click Open and select the cloned project folder.

->Running the FirstAssign Project
->Open the desired scene.
->Press the Play button to see the Ball Spawner in action.


The Ball Spawner will automatically start spawning balls when you press Play.
Balls will bounce and disappear after a certain time (configurable in the script).
Adjust spawning area and limit in the script as needed.

The Following commands are used to commit,push and adding files remotely and locally:
->cd D:/FirstAssign
->git init
->git status
->git branch
->git checkout -b assignment_7
->git add .
->git commit -m "Ball Spawner with object pooling"
git push origin assignment_7
