using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    [SerializeField] private GameObject _crown;

    void Start()
    {
        _crown.SetActive(false);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Player")
        {
            _crown.SetActive(true);
        }
    }
}
