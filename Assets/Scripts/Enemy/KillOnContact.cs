using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KillOnContact : MonoBehaviour {
  [SerializeField]
  private string[] tags;

  private GameObject _game;

  private void Awake() {
    _game = GameObject.FindWithTag("GameController");
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    GameObject go = collision.gameObject;

    if (CompareTags(go, tags)) {
      if (go.CompareTag("Player")) {
        _game.GetComponent<GameController>().NotifyGameOver();
        Destroy(go, 0.0f);
      }
      else if (go.CompareTag("Enemy")) {
        _game.GetComponent<SpawnEnemies>().RespawnAngry(go);
      }
    }
  }

  private bool CompareTags(GameObject go, string[] tags) {
    foreach (var tag in tags) {
      if (go.CompareTag(tag)) {
        return true;
      }
    }

    return false;
  }

}
