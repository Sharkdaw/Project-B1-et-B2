using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCam : MonoBehaviour
{
    public static string zoomActive = "n";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera> ().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomActive == "y")
        {
            GetComponent<Camera>().enabled = true;
        } else
        {
            GetComponent<Camera>().enabled = false;
        }
    }
}
