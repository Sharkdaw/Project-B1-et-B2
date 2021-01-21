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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ironText.text = "Fer: " + iron.ToString();
        nickelText.text = "Nickel: " + nickel.ToString();
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
