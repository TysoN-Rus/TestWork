using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorEnemy : MonoBehaviour {

    [SerializeField] private FactorEnemySO factorEnemySO;

    private void Start() {
        Health health = GetComponent<Health>();
        health?.SetMax(Settings.Instance.EnemyHealth.Get() * factorEnemySO.health);

        MoveRB moveRB = GetComponent<MoveRB>();
        moveRB?.SetSpeed(Settings.Instance.EnemySpeed.Get() * factorEnemySO.speed);

        IFactorDamage factorDamage = GetComponent<IFactorDamage>();
        factorDamage?.UpdateDamage(Settings.Instance.EnemyPower.Get() * factorEnemySO.damage);

        ScoreEnemy scoreEnemy = GetComponent<ScoreEnemy>();
        scoreEnemy?.SetScore(Settings.Instance.EnemyScore.Get() * factorEnemySO.score);
    }
}
