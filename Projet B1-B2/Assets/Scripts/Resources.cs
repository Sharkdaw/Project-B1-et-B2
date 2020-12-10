using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public string name = "";
    public int level = 1;

    int qteOnClick = 0;
    int upgradePrice = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch (name)
        {
            case "Fer":
                qteOnClick = 100;
                upgradePrice = 20;
                break;
            case "Nickel":
                qteOnClick = 75;
                upgradePrice = 30;
                break;
            case "Silicate":
                qteOnClick = 60;
                upgradePrice = 40;
                break;
            case "Silicium":
                qteOnClick = 45;
                upgradePrice = 70;
                break;
            case "Méthane":
                qteOnClick = 30;
                upgradePrice = 100;
                break;
            default:
                break;
        }
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject go = GameObject.Find("ResourceManager");
            ResourcesManager other = (ResourcesManager) go.GetComponent(typeof(ResourcesManager));
            other.addResources(name, qteOnClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
