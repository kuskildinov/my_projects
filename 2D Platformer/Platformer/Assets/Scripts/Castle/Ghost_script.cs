using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_script : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] points;
    private Vector3 target_point;
    private Rigidbody2D rb;
    void Start()
    {
        target_point = points[0].position;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {        
        for (int i = 1; i < points.Length; i++)
        {            
            if (transform.position != target_point) transform.position = Vector2.MoveTowards(transform.position, target_point, speed * Time.deltaTime);           
            else target_point = points[i++].position;             
        }       
    }
}
