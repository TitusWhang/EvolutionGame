using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwinTraits : MonoBehaviour
{
    private float mass;
    private float drag;

    private float chargeCoolDown;
    private float chargeStrength;

    private float deltaDeviationAngle;

    public int energy;
    public int breedEnergy;

    public DarwinTraits(float mass, float drag, float chargeCoolDown, float chargeStrength, float deltaDeviationAngle, int energy, int breedEnergy)
    {
        this.mass = mass;
        this.drag = drag;
        this.chargeCoolDown = chargeCoolDown;
        this.chargeStrength = chargeStrength;
        this.deltaDeviationAngle = deltaDeviationAngle;
        this.energy = energy;
        this.breedEnergy = breedEnergy;
    }

    public float getMass()
    { return mass; }

    public float getDrag()
    { return drag; }

    public float getChargeCoolDown()
    { return chargeCoolDown; }

    public float getChargeStrength()
    { return chargeStrength; }

    public float getDeltaDeviationAngle()
    { return deltaDeviationAngle; }
}
