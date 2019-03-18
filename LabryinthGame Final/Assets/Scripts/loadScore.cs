using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadScore : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        Debug.Log("Score: " + PlayerPrefs.GetInt("score"));
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
        PlayerPrefs.DeleteAll();
    }
}
