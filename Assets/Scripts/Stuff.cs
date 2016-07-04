using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : MonoBehaviour {

	public Rigidbody Body { get; private set; }

	private void Awake () {
		Body = GetComponent<Rigidbody> ();
	}

	private void OnTriggerEnter (Collider enteredCollider) {
		if (enteredCollider.CompareTag("KillZone")) {
			Destroy(gameObject);
		}
	}
}
