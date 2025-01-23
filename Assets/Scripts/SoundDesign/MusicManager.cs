using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager musicManager;
    private void Awake() 
    {
        if(musicManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            musicManager = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
