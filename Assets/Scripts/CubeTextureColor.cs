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
            applyColor();
            applyTexture();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            changeColorRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changeColorLeft();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && textures.Length > 0)
        {
            changeTextureUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && textures.Length > 0)
        {
            changeTextureDown();
        }
    }

    void changeColorRight()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        applyColor();
        Debug.Log("Color changed to: " + colors[colorIndex]);
    }

    void changeColorLeft()
    {
        colorIndex = (colorIndex - 1 + colors.Length) % colors.Length;
        applyColor();
        Debug.Log("Color changed to: " + colors[colorIndex]);
    }

    void changeTextureUp()
    {
        textureIndex = (textureIndex + 1) % textures.Length;
        applyTexture();
        Debug.Log("Texture changed to: " + textures[textureIndex].name);
    }

    void changeTextureDown()
    {
        textureIndex = (textureIndex - 1 + textures.Length) % textures.Length;
        applyTexture();
        Debug.Log("Texture changed to: " + textures[textureIndex].name);
    }

    void applyColor()
    {
        CubeMaterial.color = colors[colorIndex];
        CubeMaterial.SetColor("_BaseColor", colors[colorIndex]); // For materials using URP/HDRP shaders
    }

    void applyTexture()
    {
        CubeMaterial.mainTexture = textures[textureIndex];
    }
}
