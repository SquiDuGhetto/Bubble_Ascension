using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform _cameraTransform;
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

    public void RestartGame()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].enabled = false;
        }

        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].enabled = false;
            _players[i].transform.position = _spawnPoints[i].position;
            _players[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            _startText.text = (3 - i).ToString();
        }
        yield return new WaitForSeconds(1);
        _startText.text = "FIGHT";
        yield return new WaitForSeconds(1);
        _startText.DOFade(0, 0.1f);

        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].enabled = true;
        }
    }

    public void GameEnd(Transform deadPlayer)
    {
        if (deadPlayer == _players[0])
        {
            _cameraTransform.SetParent(_players[1].transform);
            Vector3 newPos = new Vector3(0, 0, -10);
            _cameraTransform.DOLocalMove(newPos, 1);
        }
        else
        {
            _cameraTransform.SetParent(_players[0].transform);
            Vector3 newPos = new Vector3(0, 0, -10);
            _cameraTransform.DOLocalMove(newPos, 1);
        }

        Camera.main.DOOrthoSize(2, 1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
