using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public GameObject[] entityPrefab= new GameObject[1];
    public float spawnDelay, waveDelay;
    public int spawnCooldownInFrames = 50;
    private int _spawnCooldownInFrames=0;
	

	void Update ()
    {
        if (_spawnCooldownInFrames >= spawnCooldownInFrames)
        {
            SpawnEntity();
            _spawnCooldownInFrames = 0;
        }
        _spawnCooldownInFrames++;
	}

    void SpawnWave()
    {
    }

    void SpawnEntity()
    {
        int a = Random.Range(0, entityPrefab.Length);
        Instantiate(entityPrefab[a], transform.position, transform.rotation);
    }
}
