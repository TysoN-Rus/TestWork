using UnityEngine;

public class Bar : MonoBehaviour {

    [SerializeField] private Gradient gradient;
    [SerializeField] private Vector3 deltaPos;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        GetComponentInParent<Health>().EvChangeNormal.AddListener(SetVal);
        SetVal(1);
    }

    public void SetVal(float val) {
        spriteRenderer.color = gradient.Evaluate(val);
        transform.localScale = new Vector3(val, 1, 1);
    }

    public void RefreshPosAndRot() {
        transform.position = deltaPos + transform.parent.position;
        transform.eulerAngles = Vector3.zero;
    }

    private void LateUpdate() {
        RefreshPosAndRot();
    }

    private void OnEnable() {
        RefreshPosAndRot();
    }

    private void OnDisable() {
        SetVal(1);
    }

    [ContextMenu("SaveDeltaPosition")]
    private void SetDefPos() {
        deltaPos = transform.localPosition;
    }
}
