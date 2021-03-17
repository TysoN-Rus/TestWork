using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScorePlayer : MonoBehaviour {
    public static ScorePlayer Instance { private set; get; }

    [SerializeField] private TextMeshProUGUI scorePlayerValue;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance == this) {
            Destroy(gameObject);
            return;
        }
    }
    private void Start() {
        EvAddScorePlayer.AddListener(AddScorePlayer);
        ControlGame.Instance.EvStartGame.AddListener(ResetScorePlayer);
    }

    [HideInInspector] public UnityEvent<float> EvAddScorePlayer = new UnityEvent<float>();

    private float scorePlayer = 0;

    private void AddScorePlayer(float value) {
        scorePlayer += value;
        PrintScorePlayer();
        if (scorePlayer >= Settings.Instance.ScorePlayerToWin.Get()) {
            ControlGame.Instance.EvWinGame.Invoke();
        }
    }

    private void PrintScorePlayer() {
        scorePlayerValue.text = scorePlayer.ToString("0");
    }

    private void ResetScorePlayer() {
        scorePlayer = 0;
        PrintScorePlayer();
    }
}
