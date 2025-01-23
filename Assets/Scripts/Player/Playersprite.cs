using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersprite : MonoBehaviour
{
    [SerializeField] private List<Animator> _characters;
    [SerializeField] private Vector2 _position;

    public Animator CharAnimator { get; private set; }

    private void Start()
    {
        CharAnimator = _characters.GetRandom();
        Instantiate(CharAnimator, _position, Quaternion.identity, transform);
    }
}
