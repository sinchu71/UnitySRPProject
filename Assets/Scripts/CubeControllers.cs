using UnityEngine;

public class CubeControllers : MonoBehaviour
{
    public GameSettings gameSettings;
    public Material cubeMaterial;
    public Texture[] textures;

    private int currentTextureIndex = 0;
    private int currentColorIndex = 0;
    private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta };

    private void Start()
    {
        UpdateTexture(); 
        UpdateColor(currentColorIndex); 
        transform.localScale = Vector3.one * gameSettings.cubeScale; // Set initial scale
    }

    private void Update()
    {
        RotateCube();
        HandleInput();
    }

    private void RotateCube()
    {
        transform.Rotate(Vector3.up, gameSettings.rotationSpeed * gameSettings.rotationDirection * Time.deltaTime);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateColor(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateColor(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateTexture(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RotateTexture(-1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            gameSettings.rotationSpeed += 10f * Time.deltaTime; 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameSettings.rotationSpeed = Mathf.Max(0, gameSettings.rotationSpeed - 10f * Time.deltaTime); 
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            gameSettings.rotationDirection = -1f; 
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameSettings.rotationDirection = 1f; 
        }

        if (Input.GetKey(KeyCode.Q))
        {
            gameSettings.cubeScale += 0.5f * Time.deltaTime;
            transform.localScale = Vector3.one * gameSettings.cubeScale;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            gameSettings.cubeScale = Mathf.Max(0.1f, gameSettings.cubeScale - 0.5f * Time.deltaTime);
            transform.localScale = Vector3.one * gameSettings.cubeScale;
        }
    }

    private void RotateColor(int direction)
    {
        currentColorIndex = (currentColorIndex + direction) % colors.Length;
        if (currentColorIndex < 0) currentColorIndex = colors.Length - 1;

        UpdateColor(currentColorIndex);
    }

    public void UpdateColor(int index)
    {
        currentColorIndex = index;
        cubeMaterial.color = colors[currentColorIndex];
        gameSettings.currentColorIndex = currentColorIndex; 
    }

    private void RotateTexture(int direction)
    {
        if (textures.Length == 0) return;

        currentTextureIndex = (currentTextureIndex + direction) % textures.Length;
        if (currentTextureIndex < 0) currentTextureIndex = textures.Length - 1;

        UpdateTexture();
    }

    private void UpdateTexture()
    {
        if (textures.Length > 0 && cubeMaterial != null)
        {
            cubeMaterial.mainTexture = textures[currentTextureIndex];
        }
    }

    public void UpdateRotationSpeed(float newSpeed)
    {
        gameSettings.rotationSpeed = newSpeed;
    }
}
