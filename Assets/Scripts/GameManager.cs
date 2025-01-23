using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _player1, _player2;
    [SerializeField] private List<Transform> _spawnPoints;
    [Header("UI")]
    [SerializeField] private TMP_Text _startText;
    private List<PlayerInput> _players = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void OnPlayerJoin(PlayerInput playerInput)
    {
        if (playerInput == null)
            return;

        Debug.Log("Joined : ");

        _players.Add(playerInput);
        if (_players.Count == 2)
        {
            StartCoroutine(StartGame());
        }
    }

    public IEnumerator StartGame()
    {
        _players[_players.Count - 1].transform.position = _spawnPoints[_players.Count - 1].position;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            _startText.text = (3 - i).ToString();
        }
        yield return new WaitForSeconds(1);
        _startText.text = "GO";
        yield return new WaitForSeconds(1);
        _startText.DOFade(0, 1);
    }

    public void GameEnd(Transform deadPlayer)
    {
        if (deadPlayer == _player1)
        {
            _cameraTransform.SetParent(_player2);
            Vector3 newPos = new Vector3(0, 0, -10);
            _cameraTransform.DOLocalMove(newPos, 1);
        }
        else
        {
            _cameraTransform.SetParent(_player1);
            Vector3 newPos = new Vector3(0, 0, -10);
            _cameraTransform.DOLocalMove(newPos, 1);
        }

        Camera.main.DOOrthoSize(2, 1);

    }
}
