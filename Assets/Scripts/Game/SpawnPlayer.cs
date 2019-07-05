using UnityEngine;

public class SpawnPlayer : MonoBehaviour {
  [SerializeField]
  GameObject player;

  private Transform _spawnPoint;

  private void Awake() {
    _spawnPoint = GameObject.FindWithTag("PlayerSpawn").transform;
  }

  private void Start() {
    Spawn();
  }
  
  private void Spawn() {
    GameObject p = Instantiate(player, _spawnPoint.position, Quaternion.identity);
    GameObject gun = Instantiate(GetComponent<GameController>().NextGun, p.transform);

    gun.GetComponent<GunController>()
      .GiveTo(player);
  }

}
