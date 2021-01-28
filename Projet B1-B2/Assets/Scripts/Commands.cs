using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Commands : MonoBehaviour
{

    public Text commandText;
    public Button acceptButton;
    public Button denyButton;

    string[] missions = {
        "Bonjour contrebandier. Vous savez à quel point il est difficile de se procurez du fer de qualité par les temps qui cours. L'arrivé de casque Corindon rend certaine transaction... comment dire... officieuse compliqué. (300 Fer)",
        "Mon cher ami, désolé de vous sollicité à nouveau, mais le centre à encore besoin de méthane. Notre dernière transaction c'est avérée insuffisante pour nos recherches. (200 Nickel)"
    };
    int[] rewards = {
        100,
        200
    };

    float timer = 0; // Temps écoulé
    float nextMission = 0; // Temps avant prochaine mission

    // Start is called before the first frame update
    void Start()
    {
        // Créer un nombre aléatoire et le stocker dans "nextMission"
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Regarder si le temps avant prochaine mission est atteint
        // Choisir une mission aléatoire
        // Afficher la mission si les ressources sont suffisantes
        // Reset le timer
        // Créer un nouveau nombre aléatoire pour "nextMission"
    }
}