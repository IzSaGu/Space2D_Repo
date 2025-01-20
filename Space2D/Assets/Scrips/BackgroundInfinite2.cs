using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInfinite2 : MonoBehaviour
{
    public float vertical_speed = 0.1f;

    private Renderer re;

    void Start()
    {
        re = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * vertical_speed);
        re.material.mainTextureOffset = offset;
    }
}
