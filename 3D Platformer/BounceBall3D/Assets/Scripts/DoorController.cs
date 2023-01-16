using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject textE;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Включает анимацию открытия дверей
    /// </summary>
    public void OpenDoor()
    {
        anim.SetBool("openDoor", true);
    }

    /// <summary>
    ///  Показать подсказку "Нажмите E"
    /// </summary>
    public void ShowE()
    {
        textE.SetActive(true);
    }
    /// <summary>
    /// Скрыть подсказку "Нажмите E"
    /// </summary>
    public void HideE()
    {
        textE.SetActive(false);
    }
}
