using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Commands : MonoBehaviour
{

    public Text commandText;
    public Button acceptButton;
    public Button denyButton;
    public GameObject commandCanvas;

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
        System.Random rnd = new System.Random();
        nextMission = rnd.Next(15, 30);

        commandCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

        if (timer >= nextMission)
        {
            System.Random rnd = new System.Random();
            int miss  = rnd.Next(2);
            commandText.text = missions[miss];
            timer = 0; 
            nextMission = rnd.Next(15, 30);
            commandCanvas.SetActive(true);
            
        }
        
    }

    public void removeCanvas() {
        
        commandCanvas.SetActive(false);
    }
}