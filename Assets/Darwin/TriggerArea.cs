using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int numCookies = 0;
    public int numDarwins = 0;
    public List<GameObject> cookiesInArea = new List<GameObject>();
    public List<GameObject> darwinsInArea = new List<GameObject>();

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
            Debug.Log(numCookies);
        }
        else if (darwinsInArea.IndexOf(other.gameObject) >= 0)
        {
            darwinsInArea.Remove(other.gameObject);
            numDarwins--;
            Debug.Log(numDarwins);
        }
    }
}
