using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    private SpriteRenderer ren;
    private float fadeOut;

    void Start()
    {

        ren = GetComponent<SpriteRenderer>();
        fadeOut = 1f;
    }

    void Update()
    {
        ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, fadeOut);
        fadeOut -= 0.01f;
    }
}
