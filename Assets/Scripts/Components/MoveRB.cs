using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRB : MonoBehaviour {
    private Rigidbody2D rb;

    [SerializeField] private float speed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(float val) {
        speed = val;
        if (rb.velocity != Vector2.zero) {
            StartMove();
        }
    }

    public void StartMove() {
        rb.velocity = transform.up * speed;
    }

    public void StopMove() {
        rb.velocity = Vector3.zero;
    }
}
