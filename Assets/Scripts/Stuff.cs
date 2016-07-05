using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject {

	public Rigidbody Body { get; private set; }

	private MeshRenderer[] meshRenderers;

	private void Awake () {
		Body = GetComponent<Rigidbody> ();
		meshRenderers = GetComponentsInChildren<MeshRenderer> ();
	}

	private void OnTriggerEnter (Collider enteredCollider) {
		if (enteredCollider.CompareTag("KillZone")) {
			ReturnToPool ();
		}
	}

	public void SetMaterial (Material mat) {
		for (int i = 0; i < meshRenderers.Length; i++) {
			meshRenderers [i].material = mat;
		}
	}

	void OnLevelWasLoaded () {
		ReturnToPool ();
	}
}
