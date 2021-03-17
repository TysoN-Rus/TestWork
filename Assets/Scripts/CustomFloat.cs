using UnityEngine;
using TMPro;
using System;

[Serializable] 
public class CustomFloat {
    [SerializeField] private TMP_InputField inputField;

    [SerializeField] private float defValue;
    private float value;

    public void Initialization() {
        inputField.onEndEdit.AddListener(Set);
        Reset();
    }

    public void Set(string newValue) => value = float.Parse(newValue);
    public void Set(float newValue) => value = newValue;
    public float Get() => value;
    public void Reset() {
        value = defValue;
        inputField.text = value.ToString();
    }
}
