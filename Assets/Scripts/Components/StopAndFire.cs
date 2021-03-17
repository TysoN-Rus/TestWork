using UnityEngine;

[RequireComponent(typeof(Fire))]
[RequireComponent(typeof(MoveRB))]
public class StopAndFire : MonoBehaviour {

    [SerializeField] private float distanceDivider;

    private float halfDistance;
    private Fire fire;
    private MoveRB moveRB;

    private void Start() {
        fire = GetComponent<Fire>();
        moveRB = GetComponent<MoveRB>();
        halfDistance = Vector3.SqrMagnitude(transform.position) / (distanceDivider * distanceDivider);
    }

    private void Update() {
        CheckDistanse();
    }

    private void CheckDistanse() {
        if (Vector3.SqrMagnitude(transform.position) < halfDistance) {
            moveRB.StopMove();
            fire.Attack(true);
        }
    }
}
