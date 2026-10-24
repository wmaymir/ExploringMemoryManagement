using UnityEngine;
using UnityEngine.UIElements;

public class ResourceCacheTesting : MonoBehaviour
{
    [SerializeField]
    public TextureLoader cacheScript;

    public Texture2D currentTexture;
    public Renderer daRenderer;

    //so that the coroutine can theoretically run in peace
    //and not run into problems if x is spammed
    private bool isUnloading = false;

    void Start()
    {
        daRenderer = GetComponent<Renderer>();

        //gets a reference to the texture
        currentTexture = cacheScript.LoadTexture("Textures/Texture2");

        //applies the reference
        daRenderer.sharedMaterial.mainTexture = currentTexture;

        //this is the bad alternative that automatically makes a brand new instance
        //of the material just for the renderer
        //daRenderer.material.mainTexture = currentTexture;

        Debug.Log("Load was attempted.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isUnloading)
        {
            isUnloading = true;

            //links need to be broken for Unity to see the content as unused

            //breaks the material link
            daRenderer.material.mainTexture = null;
            //breaks the script link
            currentTexture = null;

            //de-allocates the memory
            StartCoroutine(cacheScript.UnloadTexture("Textures/Texture2"));

            Debug.Log("Unload was attempted.");
        }
    }
}