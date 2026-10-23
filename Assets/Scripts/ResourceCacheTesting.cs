using UnityEngine;

public class ResourceCacheTesting : MonoBehaviour
{
    [SerializeField]
    public TextureLoader cacheScript;

    public Texture2D currentTexture;
    public Material currentMaterial;
    public Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();

        Texture2D currentTexture = cacheScript.LoadTexture("Textures/Texture2");

        renderer.material.mainTexture = currentTexture;

        Debug.Log("Load was attempted.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(cacheScript.UnloadTexture("Textures/Texture2"));

            currentTexture = null;
            renderer.material.mainTexture = null;

            Debug.Log("Unload was attempted.");
        }
    }
}