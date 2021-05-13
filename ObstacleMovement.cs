using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Vector3 startLocation;
    [SerializeField] private Vector3 finishLocation;
    [SerializeField] private float movementSpeed = 2.0f;
    private Vector3 positionDifference;
    const float tau = Mathf.PI * 2;


    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position;     
        positionDifference = finishLocation - startLocation;
    }

    // Update is called once per frame
    void Update()
    {             
        float cycles = Time.time * movementSpeed;  
        float sinWave = (1 + Mathf.Sin(cycles * Mathf.PI * 2)) / 2;            
        transform.position = startLocation + (positionDifference * sinWave);
    }
}
