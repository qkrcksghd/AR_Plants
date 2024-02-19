using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject particlePrefab;
    public GameObject particlePosition;
    void OnMouseDown()
    {
        GameObject particle = Instantiate(particlePrefab, particlePosition.transform.position, Quaternion.identity);
        Destroy(particle, 3);
    }
}
