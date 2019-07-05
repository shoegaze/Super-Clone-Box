using UnityEngine;

public class SpawnCrates : MonoBehaviour {
  [SerializeField]
  GameObject crate;

  private GameObject[] _crateSpawners;

  private void Start() {
    CacheCrateSpawners();
    //HACK: Move this to GameController...
    SpawnCrate();
  }
  
  private void CacheCrateSpawners() {
    _crateSpawners = GameObject.FindGameObjectsWithTag("CrateSpawner");
  }

  public void SpawnCrate() {
    Vector2 p = _crateSpawners[Random.Range(0, _crateSpawners.Length)]
      .GetComponent<CrateSpawner>()
      .RandomPoint();

    Instantiate(crate, p, Quaternion.identity);
  }

}
