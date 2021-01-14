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

    bool isLoading = false; // Une resource est-elle en chargement ?
    float timer = 0; // Temps écoulé
    float resourceCooldown = 0; // Temps à atteindre
    string loadingResource = ""; // Ressource à charger
    int loadingQte = 0; // Quantité à charger

    public Text ironText;
    public Text nickelText;
    public Slider loadingBar;
    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ironText.text = "Fer: " + iron.ToString();
        nickelText.text = "Nickel: " + nickel.ToString();

        timer += Time.deltaTime;
        if (isLoading) {
            // a / b = x / 100
            // x = a * 100 / b
            float percent = timer * 100 / resourceCooldown;
            loadingBar.value = percent / 100;
            loadingText.text = loadingResource + " - " + percent.ToString() + "%";

            if (timer >= resourceCooldown) {
                addResources(loadingResource, loadingQte);
                isLoading = false;
                loadingBar.value = 0;
                loadingText.text = "0%";
            }
        }
    }

    public void loadResource(string name, int qte, float cooldown) {
        if (isLoading == false) {
            loadingResource = name;
            loadingQte = qte;
            resourceCooldown = cooldown;
            timer = 0;
            isLoading = true;
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
