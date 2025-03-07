   ->Repository ->UnitySRPProject  
   ->FirstAssign->Unity Project
   
FirstAssign Project contains the following files:

  Assets  
  Scenes        # Contains all scenes  
  Scripts       # Contains all C# scripts  
  Plugins       # LeanTween (Tweening Library)  
  Prefabs       # Prefabs for reusable objects  
  Materials     # Materials and shaders  
  Textures      # Texture assets  
 .gitignore     # Excludes unnecessary Unity files  
  README.md     # Project documentation  
  UnitySRPProject.sln  # Unity project solution file  
 
 Set up the Project:
   Clone the Repository
      git clone https://github.com/Sinchu71/UnitySRPProject.git
      cd UnitySRPProject

Open the Project in Unity
     Ensure you have Unity 2022 3.59f installed.
     Open Unity Hub and click on Open.

    ->Select the FirstAssign folder.
    -> Install LeanTween Folowing link:
       https://assetstore.unity.com/packages/tools/animation/leantween-3595
    
    
 Another way of installing Leantween package:If the package are missing go through these step
      ->Open Window > Package Manager
      ->Click "Add package from Git URL"
      ->https://github.com/dentedpixel/LeanTween.git

 Create folowing Folders:
     Materials //Create a CubeMaterial 
        Right click->Create->Material->select cube in hierarchy->Inspector->attach CubeMaterial->Material slot.
        Select Material->Inspector->shader->Universal Render Pipeline.
     Prefabs // Place cube into Prefab
        select Cube in hierarchy->drag and drop into prefabs folder
     Textures // Stores all Textures into these folder
         it contains list of images: Texture 1 
                                     Texture 2
                                     Texture 3
                                     Texture 4
                                     Texture 5

       Create a Script Folder->project->C# script rename it as CubeTextureColor.cs->Placed in Cube and Select Array size 5->Attach the textures.
       
Folowing git commands are used to commit,Add and push files into github:
     git status
     git branch
     Added a .gitignore file
     git checkout -b assignment_4
     git add .
     git commit -m "Added Cube Texture and color"
     git push origin assignment_4
     Create a Pull Request 
          goto->github account->select branches->Your branches->select new pull request->Add a Description->Create Pull Request
          Assignee->Yourself
