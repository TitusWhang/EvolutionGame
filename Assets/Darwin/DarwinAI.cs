using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwinAI : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private DarwinTraits traits;
    private TriggerArea triggerArea;
    public GameObject thing;
    private float timeStamp = 0.0f;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        traits = gameObject.GetComponent<DarwinTraits>();
        triggerArea = gameObject.GetComponentInChildren<TriggerArea>();
    }

    void Update()
    {
        if(timeStamp <= Time.time)
        {
            thing = getClosestObject(triggerArea.darwinsInArea, triggerArea.cookiesInArea);
            if (thing == null)
                charge(Random.Range(0.0f, 360.0f), 200.0f);
            else
                charge(getAngle(thing), 200.0f);
            timeStamp = Time.time + 5.0f;
        }
    }

    void charge(float angle, float strength)
    {
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        rigidBody.AddForce(dir * strength);
    }

    float getAngle(GameObject other)
    {
        Vector3 dir = other.transform.position - transform.position;
        dir = other.transform.InverseTransformDirection(dir);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }

    GameObject getClosestObject(List<GameObject> darwins, List<GameObject> cookies)
    {
        float dist = float.MaxValue;
        GameObject closestObject = null;

        for (int i=1;i<darwins.Count;i++)
        {
            if (Vector3.Distance(darwins[i].transform.position, transform.position) < dist)
            {
                closestObject = darwins[i];
                dist = Vector3.Distance(darwins[i].transform.position, transform.position);
            }
        }
        if (closestObject == null)
        {
            dist = float.MaxValue;
            foreach (GameObject potentialTarget in cookies)
            {
                if (Vector3.Distance(potentialTarget.transform.position, transform.position) < dist)
                {
                    closestObject = potentialTarget;
                    dist = Vector3.Distance(potentialTarget.transform.position, transform.position);
                }
            }
        }
        return closestObject;
    }
}
