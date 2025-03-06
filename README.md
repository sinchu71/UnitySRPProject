Structure of the UnitySRPProject  

  UnitySRPProject is Repository
  FirstAssign is Project Folder it contains all these files:
  
  Assets  
  Scenes        # Contains all scenes  
  Scripts       # Contains all C# scripts (RotateCube.cs)  
  Plugins       # LeanTween (Tweening Library) (To smooth the Animation)
  Prefabs       # Prefabs for reusable objects  
  Materials     # Materials and shaders  
  Textures      # Texture assets  
 .gitignore      # Excludes unnecessary Unity files  
  README.md      # Project documentation  
  UnitySRPProject.sln  # Unity project solution file  
 
Clone the Repository
  git clone https://github.com/Sinchu71/UnitySRPProject.git
  cd UnitySRPProject

Select the Unity Project Folder.

   Add a path of the project folder
   Path:cd D:\FirstAssign

To Install LeanTween Package

   Go through these->Unity Asset Store https://assetstore.unity.com/packages/tools/animation/leantween-3595
   Open Window > Package Manager
   Click "Add package from Git URL"
   https://github.com/dentedpixel/LeanTween.git




Initialized Git in the project folder:
    Added a .gitignore file
    Pushed the FirstAssign to the main branch
Following git commands are used to create a branch and push,commit and adding a files:
  git checkout -b main
  git add .
  git commit -m "Added rotating cube using LeanTween"
  git push origin main
  
  To Create a Pull request follow these steps:
      Goto Github->Code->Select Branches->select Your Branches->select New Pull Request->Assignee Your Self->Create Pull Request.
      Note:Main(Master)Branch to another main branch (Main to Main) 
      we can't create a pull request because github won't allow to create pull request of the both same branches  and we can't merge and git never allows that.
