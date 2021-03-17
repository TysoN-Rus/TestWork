using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Random = UnityEngine.Random;

public enum WhoIsIt {
    none,
    Player,
    Enemy,
}

public class Settings : MonoBehaviour {

    public static Settings Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance == this) {
            Destroy(gameObject);
            return;
        }

        Random.InitState((int)DateTime.Now.Ticks);
    }

    public CustomFloat PlayerHealth;
    public CustomFloat PlayerPower;
    public CustomFloat ScorePlayerToWin;
    public CustomFloat EnemyHealth;
    public CustomFloat EnemyPower;
    public CustomFloat EnemySpeed;
    public CustomFloat EnemyTimeSpawn;
    public CustomFloat EnemyScore;

    private void Start() {
        PlayerHealth.Initialization();
        PlayerPower.Initialization();
        ScorePlayerToWin.Initialization();
        EnemyHealth.Initialization();
        EnemyPower.Initialization();
        EnemySpeed.Initialization();
        EnemyTimeSpawn.Initialization();
        EnemyScore.Initialization();
    }

    public void ResetSettings() {
        PlayerHealth.Reset();
        PlayerPower.Reset();
        ScorePlayerToWin.Reset();
        EnemyHealth.Reset();
        EnemyPower.Reset();
        EnemySpeed.Reset();
        EnemyTimeSpawn.Reset();
        EnemyScore.Reset();
    }

    #region MyRandom

    public float MyRand() {
        return Random.value;
    }

    public float MyRand(float val) {
        return Random.Range(0, val);
    }

    public int MyRand(int val) {
        return Random.Range(0, val);
    }

    public float MyRand(float min, float max) {
        return Random.Range(min, max);
    }

    public int MyRand(int min, int max) {
        return Random.Range(min, max);
    }

    public Vector2 OnUnitCircle() {
        return Random.insideUnitCircle.normalized;
    }

    #endregion
}
