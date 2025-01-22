using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    private List<PlayerInput> _players = new();

    public void OnPlayerJoin(PlayerInput playerInput)
    {
        if (playerInput == null)
            return;

        _players.Add(playerInput);
        _players[_players.Count - 1].transform.position = _spawnPoints[_players.Count - 1].position;
    }
}
