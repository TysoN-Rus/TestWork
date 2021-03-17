using UnityEngine.Events;
using UnityEngine;
using System;

[Serializable] public class Health : MonoBehaviour {
    [SerializeField] private float max;
    private float value;

    public void Start() {
        value = max;
    }
    public float Value { 
        get => value;
        set {
            this.value = Mathf.Clamp(value, 0, max);
            EvChangeNormal.Invoke(value / max);
        }
    }

    public void SetMax(float val) {
        max = val;
        Start();
    }

    public float GetNormal() {
        return value / max;
    }

    public void OnEnable() {
        Value = max;
    }

    [HideInInspector] public UnityEvent<float> EvChangeNormal = new UnityEvent<float>();
    [HideInInspector] public UnityEvent EvZeroHealth = new UnityEvent();

    public void DeltaHealth(float val) {
        value += val;
        value = Mathf.Clamp(value, 0, max);
        EvChangeNormal.Invoke(value / max);
        if (value <= 0) {
            EvZeroHealth.Invoke();
        }
    }
}
