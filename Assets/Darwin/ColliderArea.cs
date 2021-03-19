using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderArea : MonoBehaviour
{
    public GameObject darwin;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cookie"))
        {
            Debug.Log("Darwin");
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Darwin"))
        {
            DarwinTraits otherDarwinTraits = other.gameObject.GetComponent<DarwinTraits>();
            DarwinTraits darwinTraits = gameObject.GetComponent<DarwinTraits>();
            
            if (otherDarwinTraits.energy >= otherDarwinTraits.breedEnergy && darwinTraits.energy >= darwinTraits.breedEnergy)
            {
                if (otherDarwinTraits.energy > darwinTraits.energy)
                {
                    Instantiate(darwin, other.transform.position, other.transform.rotation);
                    otherDarwinTraits.energy /= 2;
                    darwinTraits.energy /= 2;
                }
                else
                {
                    Instantiate(darwin, gameObject.transform.position, other.transform.rotation);
                    otherDarwinTraits.energy /= 2;
                    darwinTraits.energy /= 2;
                }
            }
        }
    }
}
