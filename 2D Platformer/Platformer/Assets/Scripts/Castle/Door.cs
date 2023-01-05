using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Door : MonoBehaviour
{
    [SerializeField] private GameObject door_Text;

    private void OnCollisionStay2D(Collision2D collision)
    {        
        door_Text.SetActive(true);        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Inventory>().has_key)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        door_Text.SetActive(false);
    }
}
