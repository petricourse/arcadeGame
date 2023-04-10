using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadrin : MonoBehaviour
{
    public GameObject faceObject;
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer faceRenderer;
    public Sprite[] faces;

    public int[] pos = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        faceRenderer.sprite = faces[Random.Range(0, faces.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
