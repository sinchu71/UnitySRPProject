using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeControl: MonoBehaviour
{
        public Material cubeMaterial;  
        public Texture[] textures;
        private int colorIndex = 0;
        private int textureIndex = 0;
        private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta };

        void Start()
        {
            cubeMaterial.color = colors[colorIndex];  
            cubeMaterial.mainTexture = textures[textureIndex];
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeColor(-1);
            if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeColor(1);
            if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeTexture(1);
            if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeTexture(-1);
        }

        void ChangeColor(int direction)
        {
            colorIndex = (colorIndex + direction + colors.Length) % colors.Length;
            cubeMaterial.color = colors[colorIndex];
        }

        void ChangeTexture(int direction)
        {
            textureIndex = (textureIndex + direction + textures.Length) % textures.Length;
            cubeMaterial.mainTexture = textures[textureIndex];
        }
}


