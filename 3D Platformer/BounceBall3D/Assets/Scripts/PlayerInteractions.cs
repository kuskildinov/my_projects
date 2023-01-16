using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private CurrentSceneManager currentScemeManager;
    [SerializeField] private ScenesManager scenesManager;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private DoorController door;
    [SerializeField] private ParticleSystem deadParticle;

    public bool characterOnFloor = true; 

   
    private void OnTriggerEnter(Collider other)
    {        
        //Запускается, когда игрок заходит в зону перехода в Следующий уровень
        if (other.tag == "nextLevelZone")
        {
            scenesManager.NextScene();
        }
        //Запускается когда игрок попадает в зону Смерти
        if (other.tag == "deadZone")
        {            
            deadParticle.Play();
            gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }               
    }    
    private void OnTriggerStay(Collider other)
    {
        //Находится в триггере перед дверью
        if (other.tag == "openDoor")
        {
            Debug.Log("Door");
            door.ShowE();
            if (Input.GetKeyDown(KeyCode.E)) 
                door.OpenDoor();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // выключает подсказку "Нажмите Е"
        if (other.tag == "openDoor")
        {
            door.HideE();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Проверяет что игрок находится на столе
        if (collision.gameObject.tag == "floor")
        {
            characterOnFloor = true;
            gameObject.GetComponent<Animator>().SetBool("jump", false);
        }
    }

}
