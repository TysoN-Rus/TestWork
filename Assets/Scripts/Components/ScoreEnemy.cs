using UnityEngine;

[RequireComponent(typeof(Health))]
public class ScoreEnemy : MonoBehaviour {
    [SerializeField] private float value;

    private void Start() {
        GetComponent<Health>().EvZeroHealth.AddListener(SendScore);
    }

    public void SetScore(float val) {
        value = val;
    }

    private void SendScore() {
        ScorePlayer.Instance.EvAddScorePlayer.Invoke(value);
    }
}
