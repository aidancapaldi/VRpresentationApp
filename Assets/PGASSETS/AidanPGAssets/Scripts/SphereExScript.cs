using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereExScript : MonoBehaviour
{
    Color lerpedColor = Color.white;
    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        renderer.material.color = lerpedColor;
    }
}
