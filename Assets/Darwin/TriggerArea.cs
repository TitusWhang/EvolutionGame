using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int numCookies = 0;
    public int numDarwins = 0;
    public List<GameObject> cookiesInArea = new List<GameObject>();
    public List<GameObject> darwinsInArea = new List<GameObject>();

    //public GameObject closestObject = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cookie"))
        {
            Debug.Log("TriggerArea - Cookie");
            cookiesInArea.Add(other.gameObject);
            numCookies++;
            Debug.Log(numCookies);
        }
        else if (other.gameObject.CompareTag("Darwin"))
        {
            Debug.Log("TriggerArea - Darwin");
            darwinsInArea.Add(other.gameObject);
            numDarwins++;
            Debug.Log(numDarwins);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(cookiesInArea.IndexOf(other.gameObject)>=0)
        {
            cookiesInArea.Remove(other.gameObject);
            numCookies--;
            Debug.Log(numCookies+"Cookie(s)");
        }
        else if (darwinsInArea.IndexOf(other.gameObject) >= 0)
        {
            darwinsInArea.Remove(other.gameObject);
            numDarwins--;
            Debug.Log(numDarwins+"Darwin(s)");
        }
    }

    /*public void getClosestObject()
    {
        float dist = float.MaxValue;
        GameObject closestObject = null;

        for (int i = 1; i < darwinsInArea.Count; i++)
        {
            if (Vector3.Distance(darwinsInArea[i].transform.position, transform.position) < dist)
            {
                closestObject = darwinsInArea[i];
                dist = Vector3.Distance(darwinsInArea[i].transform.position, transform.position);
            }
        }
        if (closestObject != null)
        {
            darwinAi.thing = closestObject;
            return;
        }
        else
        {
            dist = float.MaxValue;
            for (int i = 0; i < cookiesInArea.Count; i++)
            {
                if (Vector3.Distance(cookiesInArea[i].transform.position, transform.position) < dist)
                {
                    closestObject = cookiesInArea[i];
                    dist = Vector3.Distance(cookiesInArea[i].transform.position, transform.position);
                }
            }
        }
        darwinAi.thing = closestObject;
        return;
    }*/
}
