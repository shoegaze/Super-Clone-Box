using UnityEngine;

public class CrateController : MonoBehaviour {
  private Rigidbody2D _rb2d;
  private Collider2D _collider;

  private bool _isTaken = false;
  private GameObject _game;

  private void Awake() {
    _rb2d = GetComponent<Rigidbody2D>();
    _collider = GetComponent<Collider2D>();
    _game = GameObject.FindWithTag("GameController");
  }
  
  private void FixedUpdate() {
    if (_rb2d.IsSleeping()) {
      _rb2d.bodyType = RigidbodyType2D.Static;
      _collider.isTrigger = true;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (!_isTaken && collision.gameObject.CompareTag("Player")) {
      GetTakenBy(collision.gameObject);
    } 
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (!_isTaken && collision.CompareTag("Player")) {
      GetTakenBy(collision.gameObject);
    }
  }

  private void GetTakenBy(GameObject player) {
    GameObject gun = Instantiate(_game.GetComponent<GameController>().NextGun, player.transform);
    gun.GetComponent<GunController>()
      .GiveTo(player);
    
    _game.GetComponent<ScoreKeeper>().IncrementScore();
    _game.GetComponent<SpawnCrates>().SpawnCrate();

    _isTaken = true;
    Destroy(gameObject, 0.0f);
  }
  
}
