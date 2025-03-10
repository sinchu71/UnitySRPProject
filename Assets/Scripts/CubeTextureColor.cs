using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTextureColor : MonoBehaviour
{
    public Material CubeMaterial = null; // Assign material in Inspector
    public Texture[] textures; // Assign 5 textures in Inspector

    private Color[] colors = 
    { 
        Color.red,          // Red
        Color.blue,         // Blue
        Color.green,        // Green
        Color.yellow,       // Yellow
        new Color(0.5f, 0, 0.5f) // Purple
    };

    private int colorIndex = 0;
    private int textureIndex = 0;

    void Start()
    {
        // Create a new material instance to avoid affecting shared materials
        if (CubeMaterial != null)
        {
            CubeMaterial = new Material(CubeMaterial);
            GetComponent<Renderer>().material = CubeMaterial;

            // Apply initial color and texture
            ApplyColor();
            ApplyTexture();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeColorRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeColorLeft();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && textures.Length > 0)
        {
            ChangeTextureUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && textures.Length > 0)
        {
            ChangeTextureDown();
        }
    }

    void ChangeColorRight()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        ApplyColor();
        Debug.Log("Color changed to: " + colors[colorIndex]);
    }

    void ChangeColorLeft()
    {
        colorIndex = (colorIndex - 1 + colors.Length) % colors.Length;
        ApplyColor();
        Debug.Log("Color changed to: " + colors[colorIndex]);
    }

    void ChangeTextureUp()
    {
        textureIndex = (textureIndex + 1) % textures.Length;
        ApplyTexture();
        Debug.Log("Texture changed to: " + textures[textureIndex].name);
    }

    void ChangeTextureDown()
    {
        textureIndex = (textureIndex - 1 + textures.Length) % textures.Length;
        ApplyTexture();
        Debug.Log("Texture changed to: " + textures[textureIndex].name);
    }

    void ApplyColor()
    {
        CubeMaterial.color = colors[colorIndex];
        CubeMaterial.SetColor("_BaseColor", colors[colorIndex]); // For materials using URP/HDRP shaders
    }

    void ApplyTexture()
    {
        CubeMaterial.mainTexture = textures[textureIndex];
    }
}
