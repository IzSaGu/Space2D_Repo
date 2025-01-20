using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgInfinite : MonoBehaviour
{
    [SerializeField] private RawImage spaceimg;
    [SerializeField] private float _x, _y;
  

    void Update()
    {
        spaceimg.uvRect = new Rect(spaceimg.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, spaceimg.uvRect.size);
    }
}
