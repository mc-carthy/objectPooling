﻿using UnityEngine;

public class StuffSpawner : MonoBehaviour {

	public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
	public float velocity;
	public Stuff[] stuffPrefabs;
	public Material stuffMaterial;

	private float timeSinceLastSpawn;
	private float currentSpawnDelay;

	private void FixedUpdate () {
		timeSinceLastSpawn += Time.fixedDeltaTime;
		if (timeSinceLastSpawn >= currentSpawnDelay) {
			timeSinceLastSpawn -= currentSpawnDelay;
			currentSpawnDelay = timeBetweenSpawns.RandomInRange;
			SpawnStuff ();
		}
	}

	private void SpawnStuff () {
		Stuff prefab = stuffPrefabs [Random.Range(0, stuffPrefabs.Length)];
		Stuff spawn = prefab.GetPooledInstance<Stuff> ();
		//spawn.GetComponent<MeshRenderer> ().material = stuffMaterial;
		spawn.SetMaterial (stuffMaterial);
		spawn.transform.localPosition = transform.position;
		spawn.transform.localScale = Vector3.one * scale.RandomInRange;
		spawn.transform.localRotation = Random.rotation;
		spawn.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
		spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;
		spawn.transform.SetParent (this.transform);
	}
}
