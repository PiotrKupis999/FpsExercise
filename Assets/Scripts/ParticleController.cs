using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {

    }

    public void StartParticleSystem(Vector3 placement)
    {
        Debug.Log("dziala");
        transform.position = placement;
        particleSystem.Play();
    }


}
