using UnityEngine;

[RequireComponent(typeof(Health))]
public class DefeatGame : MonoBehaviour {
    private void Start() {
        GetComponent<Health>().EvZeroHealth.AddListener(ControlGame.Instance.EvDefeatGame.Invoke);
    }
}
