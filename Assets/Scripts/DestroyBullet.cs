using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DestroyBullet : MonoBehaviour {
  
  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.CompareTag("Bullet")) {
      Destroy(collision.gameObject, 0.0f);
    }
  }

}
