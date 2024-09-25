using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;

    public bool isGameOver = false;
    public static GameController Instance { get; private set; }
    public float ScrollSpeed = -1.5f;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    void Update() {
        if (isGameOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored() {
        if (isGameOver) return;
        _score++;
        _scoreText.text = "Score: " + _score.ToString();
    }

    public void BirdDied() {
        _gameOverText.SetActive(true);
        isGameOver = true;
    }
}
