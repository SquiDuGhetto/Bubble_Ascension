using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private ScriptableItemList _itemList;
    [SerializeField] private bool _spawnItemOnStart = false;
    [SerializeField] private float _minTimer = 10;
    [SerializeField] private float _maxTimer = 30;
    private bool _timerStarted = false;
    private float _currentTime = 0;

    private void Start()
    {
        if (_spawnItemOnStart)
        {
            SpawnItem();
        }
        else
        {
            StartTimer();
        }
    }

    private void Update()
    {
        if (_timerStarted)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                SpawnItem();
                _timerStarted = false;
            }
        }
    }

    private void SpawnItem()
    {
        ItemObtainer clone = Instantiate(_itemList.Items.GetRandom(), transform.position, Quaternion.identity, transform);
        clone.Spawner = this;
    }

    public void StartTimer()
    {
        _currentTime = Random.Range(_minTimer, _maxTimer);
        _timerStarted = true;
    }
}
