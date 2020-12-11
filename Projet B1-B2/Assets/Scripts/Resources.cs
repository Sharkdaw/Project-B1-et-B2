using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    // Variables modifiables depuis l'inspecteur
    public string name = ""; // Nom de la ressource
    public int level = 1; // Niveau du bâtiment (inutile pour le moment)

    // Variables qui dépendent du type de la ressource
    int qteOnClick = 0; // Quantité de ressources récupérables au click sur le bâtiment
    int upgradePrice = 0; // Prix de l'augmentation de niveau (inutile pour le moment)
    int qtePerTime = 15; // Quantité de ressources produites tous les x temps
    int timeToGetResource = 5; // Temps nécessaire à la production de ressources

    // Variables propre au script
    int stock = 0; // Stock actuel du bâtiment
    float timer = 0; // Temps écoulé actuellement

    TextMesh text; // Texte affiché au dessus du bâtiment
    ResourcesManager rm; // Ressource manager (le canvas)

    // Start is called before the first frame update
    void Start()
    {
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        text = (TextMesh)child.GetComponent(typeof(TextMesh)); // On récupère le GameObject du texte

        GameObject go = GameObject.Find("ResourceManager");
        rm  = (ResourcesManager) go.GetComponent(typeof(ResourcesManager)); // On récupère le Canvas

        // On récupère le nom de la ressources pour mettre les bonnes valeurs de variables
        switch (name)
        {
            case "Fer":
                qteOnClick = 100;
                upgradePrice = 20;
                break;
            case "Nickel":
                qteOnClick = 75;
                upgradePrice = 30;
                qtePerTime = 10;
                timeToGetResource = 7;
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

    // Si on clique sur le bâtiment, on éxécute ce bloc
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            /* 
                1) vérifier qu'on ait suffisamment de ressources pour en récupérer
                2) récupérer lesdites ressources
                3) supprimer les ressources du stock
            */
            rm.addResources(name, qteOnClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Si on a atteint le temps limite, on ajoute la bonne quantité de ressource au stock
        if (timer >= timeToGetResource) {
            timer -= timeToGetResource;
            stock += qtePerTime;
        }

        // Et on l'affiche
        text.text = name + " " + stock.ToString();
    }
}
