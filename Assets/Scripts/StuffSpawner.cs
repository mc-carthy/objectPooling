using UnityEngine;

public class StuffSpawner : MonoBehaviour {

	public float timeBetweenSpawns;
	public float velocity;
	public Stuff[] stuffPrefabs;

	private float timeSinceLastSpawn;

	private void FixedUpdate () {
		timeSinceLastSpawn += Time.fixedDeltaTime;
		if (timeSinceLastSpawn >= timeBetweenSpawns) {
			timeSinceLastSpawn -= timeBetweenSpawns;
			SpawnStuff ();
		}
	}

	private void SpawnStuff () {
		Stuff prefab = stuffPrefabs [Random.Range (0, stuffPrefabs.Length)];
		Stuff spawn = Instantiate<Stuff> (prefab);
		spawn.transform.localPosition = transform.position;
		spawn.Body.velocity = transform.up * velocity;
	}
}
