using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    bool fix = false;
    public Animator playerAnim;
    public RuntimeAnimatorController playerContr;
    public PlayableDirector director;

    private void OnEnable()
    {
        playerContr = playerAnim.runtimeAnimatorController;
        playerAnim.runtimeAnimatorController = null;
    }

    private void Update()
    {
        if(director.state !=PlayState.Playing && !fix)
        {
            fix = true;
            playerAnim.runtimeAnimatorController = playerContr;
        }
    }
}
