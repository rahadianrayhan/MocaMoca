using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider playerHP;
    public Slider enemyHP;
    public Text fightTxt;
    private float fadeOut;

    void Start()
    {
        fadeOut = 1f;
    }

    void Update()
    {
        fightTxt.color = new Color(fightTxt.color.r, fightTxt.color.g, fightTxt.color.b, fadeOut);
        fadeOut -= 0.005f;
    }
	
}
