using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
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

    // private UnityEngine.XR.XRNode hand;

    // private List<UnityEngine.XR.InputDevice> leftHandDevices = new List<UnityEngine.XR.InputDevice>();


    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the sprite and all the necessary declared fields
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //curSpriteIndex = System.Array.IndexOf(availableSprites, spriteRenderer.sprite);
        curSpriteIndex = GetIndex();
        // hand = UnityEngine.XR.XRNode.RightHand;

        // UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
    }

    // Update is called once per frame
    void Update()
    {

        // bool triggerValue;
        // if (leftHandDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        // {
        //     curSpriteIndex++;
        //     // Allow for the sprite index to wrap around
        //     if (curSpriteIndex >= availableSprites.Length)
        //     {
        //         curSpriteIndex = 0;
        //     }
        //     ChangeSprite();
        // }
        if (Input.GetMouseButtonDown(0))
        {
            curSpriteIndex++;
            // Allow for the sprite index to wrap around
            if (curSpriteIndex >= availableSprites.Length)
            {
                curSpriteIndex = 0;
            }
            ChangeSprite();
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("press");
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
