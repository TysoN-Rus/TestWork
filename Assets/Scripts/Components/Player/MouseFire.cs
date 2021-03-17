using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fire))]
public class MouseFire : MonoBehaviour {
    private Fire fire;

    private void Start() {
        fire = GetComponent<Fire>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            fire.Attack(true);
        }
        if (Input.GetMouseButtonUp(0)) {
            fire.Attack(false);
        }
    }
}
