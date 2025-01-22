using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("ExitScene");
    }
}
