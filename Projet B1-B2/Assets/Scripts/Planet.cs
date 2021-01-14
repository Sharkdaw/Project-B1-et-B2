using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private Color startcolor;

    // Start is called before the first frame update
    void Start()
    {
        startcolor = GetComponent<Renderer>().material.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
                    {
                        if(ship.GetComponent<Vehicule>().isActive == true)
                        {  
                            ship.GetComponent<Vehicule>().setTargetPlanet(this.gameObject);
                        }
                    }
                }
            }
        }
    }

    void OnMouseEnter()
    {
        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Ship"))
        {
            if(ship.GetComponent<Vehicule>().isActive == true)
            {  
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }
}
