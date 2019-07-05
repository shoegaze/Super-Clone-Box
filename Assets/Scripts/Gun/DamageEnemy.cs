using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageEnemy : MonoBehaviour {
  [SerializeField]
  uint damage;
  [SerializeField]
  bool destroyOnContact;

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag("Enemy")) {
      collision.GetComponent<Health>().Take(damage);

      if (destroyOnContact) {
        Destroy(gameObject, 0.0f);
      }
    }
  }

}
