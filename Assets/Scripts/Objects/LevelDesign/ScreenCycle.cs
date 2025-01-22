using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCycle : MonoBehaviour
{
    [SerializeField] private Transform _teleportPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = _teleportPosition.position;
        }
    }
}
