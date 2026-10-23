using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureLoader : MonoBehaviour
{

    //Make a texture dictionary to load them
    private Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();

    public Texture2D LoadTexture(string path)
    {
        //check if the texture is already cached
        if (loadedTextures.TryGetValue(path, out Texture2D cachedTexture))
        {
            //return the same thing isntead of doing all the stuff
            return cachedTexture;
        }

        //loads usign Unity's built in function
        Texture2D texture = Resources.Load<Texture2D>(path);

        if (texture != null)
        {
            //adds it to the dictionary and logs it
            loadedTextures.Add(path, texture);
            Debug.Log("Loaded and cached a texture!");
        }
        else
        {
            //logs it as a warning with the triangle
            Debug.LogWarning("A path was not found!");
        }

        return texture;
    }

    //IEnumerator for iteration
    public IEnumerator UnloadTexture(string path)
    {
        //remove from dictionary and trigger asset cleanup
        if (loadedTextures.Remove(path))
        {
            Debug.Log("Removed a texture from cache.");
            yield return Resources.UnloadUnusedAssets();
        }
    }
}