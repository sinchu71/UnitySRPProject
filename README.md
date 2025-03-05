📦 UnitySRPProject  
 ┣ 📂 Assets  
 ┃ ┣ 📂 Scenes        # Contains all scenes  
 ┃ ┣ 📂 Scripts       # Contains all C# scripts  
 ┃ ┣ 📂 Plugins       # LeanTween (Tweening Library)  
 ┃ ┣ 📂 Prefabs       # Prefabs for reusable objects  
 ┃ ┣ 📂 Materials     # Materials and shaders  
 ┃ ┗ 📂 Textures      # Texture assets  
 ┣ 📜 .gitignore      # Excludes unnecessary Unity files  
 ┣ 📜 README.md       # Project documentation  
 ┗ 📜 UnitySRPProject.sln  # Unity project solution file  
 
Installation & Setup
Follow these steps to get the project running on your local machine:

1️⃣ Clone the Repository
git clone https://github.com/YOUR_GITHUB_USERNAME/UnitySRPProject.git
cd UnitySRPProject

2️⃣ Open the Project in Unity
Ensure you have Unity 202X.X.X installed.
Open Unity Hub and click on "Open".

Select the UnitySRPProject folder.
3️⃣ Install LeanTween (If Not Included)
If the LeanTween package is missing, install it via the Unity Package Manager:

Open Window > Package Manager
Click "Add package from Git URL"
https://github.com/dentedpixel/LeanTween.git

🎮 How It Works

The Cube in the scene rotates at a fixed speed using LeanTween.
The animation is controlled by a script located in the Scripts folder.


🔹 Initial Setup (Already Completed)

Initialized Git in the project folder
Added a .gitignore file
Pushed the initial project to the main branch

Created Pull Request and Merging a branch
A Pull Request (PR) must be created before merging into main.
Example workflow for an assignment:

git checkout -b Assignment-1
# Make changes and commit
git add .
git commit -m "Added rotating cube using LeanTween"
git push origin Assignment-1
