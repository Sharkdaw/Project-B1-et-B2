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

    // J'ai déplacé tout le système de génération des nouvelles missions pour que ce soit plus simple à modifier
    System.Random rnd = new System.Random();
    int timeMinMission = 15;
    int timeMaxMission = 30;

    Command[] missions = {
        new Command("Se fer la main", "Bonjour contrebandier. Vous savez à quel point il est difficile de se procurez du fer de qualité par les temps qui cours. L'arrivé de casque Corindon rend certaine transaction... comment dire... officieuse compliqué", "Fer", 100, 300),
        new Command("Ok nickel", "Mon cher ami, désolé de vous sollicité à nouveau, mais le centre à encore besoin de méthane. Notre dernière transaction s'est avérée insuffisante pour nos recherches.", "Nickel", 200, 200),
    };

    // Ici on passe par une List<> car on ne sait pas à l'avance quelle sera la taille de notre tableau
    List<Command> accepted = new List<Command>(); // Pour stocker les commandes en cours
    int currentMiss; // Id de la mission aléatoirement désignée pour être affichée
    int maxCommands = 1; // Nombre max de commandes en simultané, stocké pour potentiellement le faire évoluer au fil du jeu

    float timer = 0; // Temps écoulé
    float nextMission = 0; // Temps avant prochaine mission

    // Start is called before the first frame update
    void Start()
    {
        // Créer un nombre aléatoire et le stocker dans "nextMission"
        nextMission = rnd.Next(timeMinMission, timeMaxMission);

        commandCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= nextMission && commandCanvas.active == false && maxCommands > accepted.Count)
        {
            System.Random rnd = new System.Random();
            currentMiss = rnd.Next(missions.Length); // On change la mission à afficher
            commandText.text = missions[currentMiss].description;
            commandCanvas.SetActive(true);
        }
        
    }

    public void acceptCommand() {
        accepted.Add(missions[currentMiss]);
        commandCanvas.SetActive(false);
    }

    public void removeCanvas() {
        timer = 0;
        nextMission = rnd.Next(timeMinMission, timeMaxMission);
        commandCanvas.SetActive(false);
    }
}

// On crée une structure qui contient les informations nécessaires à une mission
// Ça permet de structurer plus proprement les missions et venir ajouter des fonctions spécifiques et faciliter les modifs
public struct Command
{
    public string name, description, rewardType;
    public int price, reward;

    // Cette fonction est nécessaire et a pour seul but de remplir les variables quand on crée la commande
    public Command(string name, string description, string rewardType, int price, int reward) {
        this.name = name;
        this.description = description;
        this.rewardType = rewardType;
        this.price = price;
        this.reward = reward;
    }
}