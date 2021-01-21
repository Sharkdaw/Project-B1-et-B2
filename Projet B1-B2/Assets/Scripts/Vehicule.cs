using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule : MonoBehaviour
{
    public int speed = 50;
    public bool isActive = false;

    Transform target; // On récupère le bâtiment de stockage
    GameObject targetPlanet; // La planète de destination
    ResourcesManager rm; // Ressource manager (le canvas)
    
    Color startcolor; // Couleur de base de l'objet
    int stock = 0; // Ressources actuellement dans le vaisseau

    // Start is called before the first frame update
    void Start()
    {
        GameObject storageBuilding = GameObject.Find("StorageBuilding");
        target = storageBuilding.transform;

        GameObject go = GameObject.Find("ResourceManager");
        rm  = (ResourcesManager) go.GetComponent(typeof(ResourcesManager)); // On récupère le Canvas

        startcolor = GetComponent<Renderer>().material.color;
        
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle + 120f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (targetPlanet != null) {
            Resources planetScript = targetPlanet.transform.GetChild(0).GetComponent<Resources>();

            if (stock == 0) {
                Transform pos = targetPlanet.transform.GetChild(0).gameObject.transform;
                transform.position = Vector3.MoveTowards(transform.position, pos.position, step);

                if (Vector3.Distance(transform.position, targetPlanet.transform.GetChild(0).gameObject.transform.position) < 50) {
                    int planetStock = planetScript.stock;
                    int planetQteMin = planetScript.qteOnClick;

                    if (planetStock >= planetQteMin) {
                        stock += planetQteMin;
                        planetScript.getSomeStock(stock);
                    }
                }
            } else {
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

                if (Vector3.Distance(transform.position, target.transform.position) < 50) {
                    rm.addResources(planetScript.name, stock);
                    stock = 0;
                }
            }
        }

        if (Input.GetMouseButtonDown (0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isActive = isActive ? false : true;
                }
            } else {
                isActive = false;
            }
        }
        if (isActive) {
            GetComponentInChildren<Renderer>().material.color = Color.yellow;
        } else {
            GetComponentInChildren<Renderer>().material.color = startcolor;
        }
    }

    public void setTargetPlanet(GameObject tp) {
        targetPlanet = tp;
    }
}