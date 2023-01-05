using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject key_img;
    private void Start()
    {
        key_img.SetActive(false);
    }

    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.GetComponent<Player_Inventory>().has_key)
        {
            key_img.SetActive(true);
            Debug.Log("ключики");
        }
    }
}
