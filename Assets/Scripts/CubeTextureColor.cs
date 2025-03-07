using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTextureColor: MonoBehaviour
{
    public Material CubeMaterial; // Assign material in Inspector
    public Texture[] textures; // Assign 5 textures in Inspector

    private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow, new Color(0.5f, 0, 0.5f) }; // Purple
    private int colorIndex = 0;
    private int textureIndex = 0;

    void Start()
    {
        // Create a new material instance to avoid affecting shared materials
        CubeMaterial = new Material(CubeMaterial);
        GetComponent<Renderer>().material = CubeMaterial;

        // Apply initial color and texture
        CubeMaterial.color = colors[colorIndex];
        CubeMaterial.SetColor("_BaseColor", colors[colorIndex]);

        if (textures.Length > 0)
        {
            CubeMaterial.mainTexture = textures[textureIndex];
        }

    }

    

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                colorIndex = (colorIndex + 1) % colors.Length;
                CubeMaterial.color = colors[colorIndex];
                Debug.Log("Color changed to: " + colors[colorIndex]);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                colorIndex = (colorIndex - 1 + colors.Length) % colors.Length;
                CubeMaterial.color = colors[colorIndex];
                Debug.Log("Color changed to: " + colors[colorIndex]);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && textures.Length > 0)
            {
                textureIndex = (textureIndex + 1) % textures.Length;
                CubeMaterial.mainTexture = textures[textureIndex];
                Debug.Log("Texture changed to: " + textures[textureIndex].name);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && textures.Length > 0)
            {
                textureIndex = (textureIndex - 1 + textures.Length) % textures.Length;
                CubeMaterial.mainTexture = textures[textureIndex];
                Debug.Log("Texture changed to: " + textures[textureIndex].name);
            }
        }
}





