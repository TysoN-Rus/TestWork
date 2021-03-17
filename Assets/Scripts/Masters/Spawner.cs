using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject[] enemy;

    [SerializeField] private float radius;
    [SerializeField] private Timer timerSpawn;

    private void Start() {
        ControlGame.Instance.EvStartGame.AddListener(StartSpawn);
        ControlGame.Instance.EvStopGame.AddListener(StopSpawn);
        timerSpawn.EvSignal.AddListener(SpawnEnemy);
    }

    private void StartSpawn() {
        timerSpawn.SetDeltaTime(Settings.Instance.EnemyTimeSpawn.Get());
        timerSpawn.TikPauseTik(true);
    }

    private void StopSpawn() {
        timerSpawn.TikPauseTik(false);
    }

    private void SpawnEnemy() {
        int num = Settings.Instance.MyRand(enemy.Length);
        GameObject temp = Creator.Instance.GetPoolGO(enemy[num].gameObject, NewPosSpawn());
        temp.transform.up = -temp.transform.position;
        temp.GetComponent<MoveRB>().StartMove();
    }

    private Vector2 NewPosSpawn() {
        Vector3 newPositionSpawn;
        newPositionSpawn = Settings.Instance.OnUnitCircle() * radius;
        return newPositionSpawn;
    }

    private void OnDestroy() {
        StopSpawn();
        timerSpawn.EvSignal.RemoveListener(SpawnEnemy);
    }

}
