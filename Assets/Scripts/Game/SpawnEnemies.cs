using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
  [SerializeField]
  private float spawnInterval;

  private Transform _spawnPoint;

  private void Awake() {
    _spawnPoint = GameObject.FindWithTag("EnemySpawner").transform;
  }

  private void Start() {
    StartCoroutine(SpawnWavesAtInterval());
  }
  
  public IEnumerator SpawnWavesAtInterval() {
    // TODO: while (!_game.IsGameOver) {
    while (true) {
      yield return new WaitForSeconds(spawnInterval);

      Debug.Log("Spawning wave!");
    }
  }

  public void SpawnWave() {
    //TODO:
    //StartCoroutine(Random.Select(WaveRoutines))
    Debug.Log("Spawning wave");
  }

  public void RespawnAngry(GameObject enemy) {
    enemy.GetComponent<Animator>().SetBool("IsAngry", true);
    enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    enemy.transform.position = _spawnPoint.position;
  }

}
