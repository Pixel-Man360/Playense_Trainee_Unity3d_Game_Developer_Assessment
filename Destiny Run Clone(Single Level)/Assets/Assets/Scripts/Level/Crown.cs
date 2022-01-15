using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    [SerializeField] private MeshRenderer _crown;

    void Start()
    {
        _crown.enabled = false;
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Player")
        {
            _crown.enabled = true;
        }
    }
}
