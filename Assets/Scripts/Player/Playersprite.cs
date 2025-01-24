using System;
using System.Collections.Generic;
using UnityEngine;

public class Playersprite : MonoBehaviour
{
    [Serializable]
    public struct CharaterList
    {
        public Animator prefab;
        public Vector2 _positionCorrection;
    }

    [SerializeField] private List<CharaterList> _characters = new();
    private Animator _animator;

    public Animator CharAnimator { get { return _animator; } set { _animator = value; } }

    private void Start()
    {
        int index = UnityEngine.Random.Range(0, _characters.Count);
        Animator clone = Instantiate(_characters[index].prefab, transform);
        clone.transform.localPosition = _characters[index]._positionCorrection;
        CharAnimator = GetComponentInChildren<Animator>();
    }
}
