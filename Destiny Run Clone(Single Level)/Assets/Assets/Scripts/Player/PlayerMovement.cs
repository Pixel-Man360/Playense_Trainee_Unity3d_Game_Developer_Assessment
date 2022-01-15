using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IRotable
{
    [Header("Player Stats: ")]
    [SerializeField] private float _moveForwardSpeed = 10f;
    [SerializeField] private float _moveLeftRightSpeed = 2f;
    
 
    private bool _isDragging = false;
    private Vector3 _previousPos;
    private bool _canMove = false;

    void OnEnable() 
    {
        GameManager.OnGameStartedorEnded += CheckGameState;
    }

    void OnDisable() 
    {
        GameManager.OnGameStartedorEnded -= CheckGameState;
    }

    void CheckGameState(bool canPlayerMove) => _canMove = canPlayerMove;
    
    void Update()
    {
        if(_canMove)
        {
            MoveForward();
            MoveLeftAndRight();
        }
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _moveForwardSpeed);
    }

    void MoveLeftAndRight()
    {

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
        {
            _isDragging = true;
            Vector3 horizontal = Input.GetTouch(0).deltaPosition.normalized;
            
            transform.Translate(Vector3.right * horizontal.x * Time.deltaTime * _moveLeftRightSpeed); 
            _previousPos = transform.position;
        }

        if(_isDragging && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Canceled))
        {
            _isDragging = false;

            transform.position = new Vector3(_previousPos.x, _previousPos.y, _previousPos.z);
        }

    }

    public void Rotate(int direction)
    {
        StartCoroutine(RotateThePlayer(direction));
    }

    IEnumerator RotateThePlayer(int direction)
    {
        
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 90 * direction, 0);

        while (timeElapsed < 0.15f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / 0.15f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
    }
}

