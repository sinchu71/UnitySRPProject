UnitySRPProject->FirstAssign->assignment3.

 UnitySRPProject  
   Assets  
   Scenes        # Contains all scenes  
   Scripts       # Contains all C# scripts  
   Plugins       # LeanTween (Tweening Library)  
   Prefabs       # Prefabs for reusable objects  
   Materials     # Materials and shaders  
   Textures      # Texture assets  
  .gitignore      # Excludes unnecessary Unity files  
   README.md       # Project documentation  
   UnitySRPProject.sln  # Unity project solution file  

 UnitySRPProject ->Repository
 FirstAssign->Unity project folder
  
Steps for to Run Project folder in local Machine:
-> Clone the Repository
-> git clone https://github.com/Sinchu71/UnitySRPProject.git
-> cd UnitySRPProject

Open the Project in Unity
  Ensure you have Unity 2022 003.59f installed.

Open Unity Hub and click on "Open".
  Select the FirstAssign folder.

Install LeanTween:
  follow these link:https://assetstore.unity.com/packages/tools/animation/leantween-3595

Open Window > Package Manager
     Click "Add package from Git URL"
     https://github.com/dentedpixel/LeanTween.git
 And check leantween package Installed:
   goto->package manager->Select MyAssests.

Following commands are used to create a branch and adding files to github.
     git branch           # Check the current branch
     git checkout -b Assignment_3   # Create and switch to new branch
     git branch           # Verify the branch
     git add .            # Stage changes
     git commit -m "Added Assignment 3 functionality"   # Commit changes
     git push origin Assignment_3   # Push the branch to GitHub

Create a Pull Request
  Goto Code->select Branches click->select Your branches->click 3 dots overthere and select->New Pull Request->Next Create Pull request.
