using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// System.SceneManager

// Script to change the sprite of its parent renderer when mouse button is clicked
// NOTE: This may need to be changed to a different input when in VR
public class SpriteChanger : MonoBehaviour
{
    // Need a reference to the sprite renderer
    private SpriteRenderer spriteRenderer;
    // Array of sprites from which to choose 
    public Sprite[] availableSprites;
    // Index of the sprite on which the renderer started
    private int curSpriteIndex;


    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the sprite and all the necessary declared fields
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //curSpriteIndex = System.Array.IndexOf(availableSprites, spriteRenderer.sprite);
        curSpriteIndex = GetIndex();
        Debug.Log("First index: " + curSpriteIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            curSpriteIndex++;
            Debug.Log("New index after click: " + curSpriteIndex);
            // Allow for the sprite index to wrap around
            if (curSpriteIndex >= availableSprites.Length)
            {
                curSpriteIndex = 0;
            }
            ChangeSprite();
        }
    }

    // Handler invoked to actually change the sprite
    void ChangeSprite()
    {
        // No matter where we started in the array of sprites, 
        // scroll to the next sprite in the array, and allow wraparound
        spriteRenderer.sprite = availableSprites[curSpriteIndex];
    }

    // Method to get the index of start in sprite array
    // Necessary due to array init issues not allowing 
    int GetIndex()
    {
        for (int i = 0; i < availableSprites.Length; i++)
        {
            if (availableSprites[i].name == spriteRenderer.sprite.name)
            {
                return i;
            }
        }
        return -2;
    }
}
