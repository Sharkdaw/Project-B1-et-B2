using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    int iron = 0;
    int nickel = 0;
    int silicate = 0;
    int silicium = 0;
    int methane = 0;

    public Text ironText;
    public Text nickelText;

    public Text timerText;
    public float gameTime;

    private bool stopTimer;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        ironText.text = "Fer: " + iron.ToString();
        nickelText.text = "Nickel: " + nickel.ToString();

        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
        {
            stopTimer = true;
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;

        }
    }

    public void addResources(string name, int qte) {
        switch (name)
        {
            case "Fer":
                iron += qte;
                break;
            case "Nickel":
                nickel += qte;
                break;
            case "Silicate":
                silicate += qte;
                break;
            case "Silicium":
                silicium += qte;
                break;
            case "Méthane":
                methane += qte;
                break;
            default:
                break;
        }
    }
}
