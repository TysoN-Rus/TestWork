using UnityEngine;
[RequireComponent(typeof(Health))]
public class DamageContact : MonoBehaviour {

    [SerializeField] private WhoIsIt whoIsIt;

    private Health health;
    void Start() {
        health = GetComponent<Health>();
        health.EvZeroHealth.AddListener(DisableGameObject);
    }

    public void DisableGameObject() {
        gameObject.SetActive(false);
    }

    public bool MakeDamage(float val, WhoIsIt whoIsIt = WhoIsIt.none) {
        if (this.whoIsIt != whoIsIt) {
            health.DeltaHealth(-val);
            return true;
        } else {
            return false;
        }
    }
}
