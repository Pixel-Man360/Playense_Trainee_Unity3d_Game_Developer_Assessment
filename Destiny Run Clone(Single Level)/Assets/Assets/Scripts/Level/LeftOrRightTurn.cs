using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftOrRightTurn : MonoBehaviour
{
    [Header("Left or Right Control: ")]
    [SerializeField] private int _direction = 1;

    void Awake()
    {
        _direction = Mathf.Clamp(_direction, -1, 1);
    }

    private void OnTriggerEnter(Collider other) 
    {
        IRotable player = other.GetComponent<IRotable>();
        
        player.Rotate(_direction);

    }
}
