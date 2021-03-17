using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Damage : MonoBehaviour, IFactorDamage {

    [SerializeField] private float value;

    public void SetDamage(float val) {
        value = val;
    }

    [SerializeField] private WhoIsIt whoIsIt;
    public void SetWhoIsIt(WhoIsIt whoIsIt) {
        this.whoIsIt = whoIsIt;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageContact damageContact = collision.gameObject.GetComponent<DamageContact>();
        if (damageContact && damageContact.enabled) {
            if (damageContact.MakeDamage(value, whoIsIt)) {
                gameObject.SetActive(false);
            }
        }
    }

    public void UpdateDamage(float val) {
        value = val;
    }
}
