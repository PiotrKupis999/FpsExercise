using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpener : MonoBehaviour, IDestroyable
{
    public OpponentController enemy;

    void Start()
    {
        enemy.AddObserver(GetComponent<DoorsOpener>());
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
        Debug.Log("Doors are open");
    }


}
