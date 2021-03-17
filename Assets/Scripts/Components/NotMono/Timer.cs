using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Timer {

    [SerializeField] protected float deltaTime;

    [HideInInspector] public UnityEvent EvSignal;

    private IEnumerator coroutine;

    public void SetDeltaTime(float val) {
        deltaTime = val;
    }

    public void StartStop(bool on, IEnumerator enumerator) {
        if (Settings.Instance) {
            if (on) {
                if (coroutine == null) {
                    coroutine = enumerator;
                    Settings.Instance.StartCoroutine(coroutine);
                }
            } else {
                if (coroutine != null) {
                    Settings.Instance.StopCoroutine(coroutine);
                    coroutine = null;
                }
            }
        }
    }

    public virtual void TikPauseTik(bool on) {
        StartStop(on, ITikPauseTik(deltaTime));
    }

    public virtual void PauseTikPause(bool on) {
        StartStop(on, IPauseTikPause(deltaTime));
    }

    private IEnumerator ITikPauseTik(float waitTime) {
        while (true) {
            EvSignal.Invoke();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator IPauseTikPause(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            EvSignal.Invoke();
        }
    }
}
