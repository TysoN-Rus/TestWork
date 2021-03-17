using UnityEngine;

public class DisableAtDistance : MonoBehaviour {
    [SerializeField] private Timer timer;
    [SerializeField] private float maxDistanse;

    private void Start() {
        timer.EvSignal.AddListener(CheckDistanse);
        timer.PauseTikPause(true);
    }

    private void CheckDistanse() {
        if (Vector3.SqrMagnitude(transform.position) > maxDistanse * maxDistanse) {
            gameObject.SetActive(false);
        }
    }

}
