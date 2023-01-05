using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] caff;

    private int Layers_count;
    void Start()
    {
        Layers_count = layers.Length;
    }

    
    void Update()
    {
        for (int i = 0; i < Layers_count; i++)
        {
            
            layers[i].position = transform.position * -caff[i];
        }
    }
}
