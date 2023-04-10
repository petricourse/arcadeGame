using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] tileSprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tileSprites[Random.Range(0, tileSprites.Length)];
        spriteRenderer.color = Color.black;
        gameObject.transform.Rotate(new Vector3(0, 0, 90f * Random.Range(0, 4)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
