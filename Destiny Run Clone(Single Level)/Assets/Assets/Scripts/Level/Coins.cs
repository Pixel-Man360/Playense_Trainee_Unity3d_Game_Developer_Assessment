using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [Header("Dependencies: ")]
    [SerializeField] private Transform _player;

    [Header("Stats: ")]
    [SerializeField] private float _rotationSpeed = 5f;

    public static event Action OnCoinCollected;

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Player")
        {
            OnCoinCollected?.Invoke();
            
        }
    }

    
    void Update()
    {
        transform.Rotate(90f * _rotationSpeed * Time.deltaTime, 0f, 0f);

        if(_player.position.z - transform.position.z >= 5f)
        {
            this.gameObject.SetActive(false);
        }

        if(this.gameObject.activeSelf == false)
        return;

    }
}
