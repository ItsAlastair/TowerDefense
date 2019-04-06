using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScript : MonoBehaviour
{
    private Renderer thisMaterial;
    private Vector2 scroll;
    private float x;
    private float y;

    [Header("Randome between Min and Max Scollspeed")]
    [Range(-0.1f, 0.1f)] public float minX;
    [Range(-0.1f, 0.1f)] public float maxX;
    [Range(-0.1f, 0.1f)] public float minY;
    [Range(-0.1f, 0.1f)] public float maxY;

    private void Start()
    {
        thisMaterial = GetComponent<Renderer>();
        InvokeRepeating("ChangeDir", 1f, 1f);
    }

    private void Update()
    {

        scroll = new Vector2(scroll.x + x, scroll.y + y);
        thisMaterial.material.mainTextureOffset = scroll;
    }

    void ChangeDir()
    {
        x = Random.Range(minX, maxX);
        y = Random.Range(minY, maxY);
    }

}
