using UnityEngine;

public class PipesPooling : MonoBehaviour {
    [SerializeField] private GameObject _pipesPrefab;
    [SerializeField] private int _pipesPoolSize = 5;
    [SerializeField] private float _spawnRate = 4f;
    [SerializeField] private float _pipesPositionMin = 0.0f;
    [SerializeField] private float _pipesPositionMax = 1.0f;
    [SerializeField] private float _spawnXPos = 20f;

    private int _currentPipes = 0;
    private float _timeSinceLastSpawn;
    private GameObject[] _pipesPool;
    private Vector2 objectPoolPosition = new Vector2(-15f, -20f);

    void Start() {
        _pipesPool = new GameObject[_pipesPoolSize];
        for (int i = 0; i < _pipesPoolSize; i++) {
            _pipesPool[i] = (GameObject)Instantiate(_pipesPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update() {
        _timeSinceLastSpawn += Time.deltaTime;
        
        if (!GameController.Instance.isGameOver &&  _timeSinceLastSpawn >= _spawnRate) {
            _timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(_pipesPositionMin, _pipesPositionMax);
            _pipesPool[_currentPipes].transform.position = new Vector2(_spawnXPos, spawnYPos);
            _currentPipes++;

            if( _currentPipes >= _pipesPoolSize ) {
                _currentPipes = 0;
            }
        }
    }
}
