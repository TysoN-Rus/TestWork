using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlGame : MonoBehaviour {
    public static ControlGame Instance;

    public UnityEvent EvStartGame = new UnityEvent();
    public UnityEvent EvStopGame = new UnityEvent();
    public UnityEvent EvWinGame = new UnityEvent();
    public UnityEvent EvDefeatGame = new UnityEvent();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance == this) {
            Destroy(gameObject);
            return;
        }
    }
    private void Start() {
        EvDefeatGame.AddListener(EvStopGame.Invoke);
        EvWinGame.AddListener(EvStopGame.Invoke);
    }

    public void StartGame() {
        EvStartGame.Invoke();
    }
    public void StopGame() {
        EvStopGame.Invoke();
    }
    public void ExitGame() {
        Application.Quit();
    }
}
