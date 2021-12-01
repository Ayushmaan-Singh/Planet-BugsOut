using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonResourceHandler : MonoBehaviour
{

    private GameObject currentObject;

    public Transform resourceHandler;

    public GameObject reshand1, reshand2, reshand3, reshand4;

    public void SelectResource()
    {
        if (reshand1.name == "DefrostMachine")
        {
            if (resourceHandler.transform.childCount <= 1)
            {
                currentObject = reshand1;
                Instantiate(reshand1, reshand1.transform);
                reshand1.transform.parent = resourceHandler;
            }
            else
            {
                return;
            }
        }

        else if (reshand2.name == "Geezer")
        {
            if (resourceHandler.transform.childCount <= 1)
            {
                currentObject = reshand2;
                Instantiate(reshand2, reshand2.transform);
                reshand2.transform.parent = resourceHandler;
            }
            else
            {
                return;
            }
        }

        else if (reshand3.name == "Freezer")
        {
            if (resourceHandler.transform.childCount <= 1)
            {
                currentObject = reshand3;
                Instantiate(reshand3, reshand3.transform);
                reshand3.transform.parent = resourceHandler;
            }
            else
            {
                return;
            }
        }

        else if (reshand4.name == "Terraformer")
        {
            if (resourceHandler.transform.childCount <= 1)
            {
                currentObject = reshand4;
                Instantiate(reshand4, reshand4.transform);
                reshand4.transform.parent = resourceHandler;
            }
            else
            {
                return;
            }
        }
    }

    private void CheckInput(GameObject resource)
    {
        if (Input.GetMouseButtonDown(1))
        {
            DestroyImmediate(resource, false);
        }
    }

    private void Update()
    {
        CheckInput(currentObject);
    }
}
