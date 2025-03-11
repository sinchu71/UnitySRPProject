 UnitySRPProject  
  Assets  
  Scenes        # Contains all scenes  
  Scripts       # Contains all C# scripts  
  ScriptableObject #Contains all GameSettings.assest and KeyBindings.Assest
  Plugins       # LeanTween (Tweening Library)  
  Prefabs       # Prefabs for reusable objects  
  Materials     # Materials and shaders  
  Textures      # Texture assets  
 .gitignore     # Excludes unnecessary Unity files  
  README.md     # Project documentation  
  UnitySRPProject.sln  # Unity project solution file  
  
 ->UnitySRPProject->Repository
 ->FirstAssign->Unity Project Folder

 Open the Project in Unity
->Ensure you have Unity 2023 3.58 installed.
->Open Unity Hub and click on Open

Select the UnitySRPProject folder.
->Install LeanTween (If Not Included) use this link:https://assetstore.unity.com/packages/tools/animation/leantween-3595
If the LeanTween package is missing, install it via the Unity Package Manager:
->Open Window > Package Manager
->Click "Add package from Git URL"
->https://github.com/dentedpixel/LeanTween.git

- >Create an UI which lets us edit the values of the scriptable object.
    ->Assest->Create->ScriptableObject->GameSetting.assest
- >The UI should leverage the use of Buttons, Sliders or Input Fields as per the requirements.
     ->Hierarchy->UI->Panel->Rename it as ->SettingPanel-
     UI->Silder->Rename it as->VolumeSlider
     UI->DropDownMenu->Rename it as->DifficultyDropDown
     UI->InputField->Rename it as->PlayerInputName
     UI->Button->CloseButton
  
-> Any changes made in the UI should make the respective changes in the Scriptable Objects. 
-> One should be able to bring up this UI by pressing the Escape key. 
-> Pressing the Escape key again disables the UI.

The following commands are used to push ,commit and Add the files into github:
->git init
->git status
->git branch
->git checkout -b assignment_6
->git add .
->git commit -m "created UI editor"
->git push origin assignment_6
