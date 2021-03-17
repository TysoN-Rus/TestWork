using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHealthAndDamagePlayer : MonoBehaviour {

    private void Start() {
        ControlGame.Instance.EvStartGame.AddListener(UpdateValue);
    }

    private void UpdateValue() {
        Health health = GetComponent<Health>();
        health?.SetMax(Settings.Instance.PlayerHealth.Get());

        IFactorDamage factorDamage = GetComponent<IFactorDamage>();
        factorDamage?.UpdateDamage(Settings.Instance.PlayerPower.Get());
    }

}
