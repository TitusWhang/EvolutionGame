using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwinAI : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private DarwinTraits traits;
    private TriggerArea triggerArea;
    public GameObject thing;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        traits = gameObject.GetComponent<DarwinTraits>();
        triggerArea = gameObject.GetComponent<TriggerArea>();
        //charge(Random.Range(0.0f, 360.0f), 200.0f);
        //charge(0.0f, 200.0f);
        //GameObject thing = getClosestObject(triggerArea.darwinsInArea, triggerArea.cookiesInArea);
        charge(getAngle(thing), 200.0f);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (closestObject != null)
            return closestObject;
        else
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
