using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Fire : MonoBehaviour, IFactorDamage {

    [SerializeField] private WhoIsIt whoIsIt;

    [SerializeField] private Transform firePoints;
    [SerializeField] private Timer timer;

    [SerializeField] private GameObject shellPref;
    [SerializeField] private float speedShell;
    [SerializeField] private float baseDamageShell;
    private float powerDamageShell = 1;

    public void Start() {
        timer.EvSignal.AddListener(OnAttack);
    }

    private bool onAttack;

    public void Attack(bool on) {
        onAttack = on;
        timer.TikPauseTik(onAttack);
    }

    private void OnAttack() {
        GameObject temp = Creator.Instance.GetPoolGO(shellPref, firePoints.transform.position);
        temp.transform.rotation = firePoints.transform.rotation;

        MoveRB moveRB = temp.GetComponent<MoveRB>();
        if (moveRB) {
            moveRB.SetSpeed(speedShell);
            moveRB.StartMove();
        }

        Damage damage = temp.GetComponent<Damage>();
        if (damage) {
            damage.SetDamage(baseDamageShell * powerDamageShell);
            damage.SetWhoIsIt(whoIsIt);
        }
    }

    private void OnDisable() {
        timer.TikPauseTik(false);
    }

    public void UpdateDamage(float val) {
        baseDamageShell = val;
    }
}
