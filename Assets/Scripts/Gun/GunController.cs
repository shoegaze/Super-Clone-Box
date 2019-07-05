using UnityEngine;

public class GunController : MonoBehaviour {
  [SerializeField]
  GameObject bullet;
  [SerializeField]
  Vector2 bulletSpawn;
  [SerializeField]
  Vector2 gripOffset;
  [SerializeField]
  bool isAutomatic;
  [SerializeField]
  float fireRate;
  [SerializeField]
  float bulletSpreadAngle;
  [SerializeField]
  float bulletSpeed;

  private float _nextFireTime;

  private void OnDrawGizmos() {
    Gizmos.color = Color.magenta;
    Gizmos.DrawRay(
      transform.position,
      transform.right * 0.5f
    );
  }

  private void OnDrawGizmosSelected() {
    Vector2 pos = transform.position;

    //Draw bulletSpawn
    Gizmos.color = Color.red;
    Gizmos.DrawSphere(pos + bulletSpawn, 0.025f);

    //Draw gripOffset
    Gizmos.color = Color.magenta;
    Gizmos.DrawSphere(pos + gripOffset, 0.025f);
  }

  private void Update() {
    if (isAutomatic && Input.GetButton("Fire") || 
        Input.GetButtonDown("Fire")) {

      if (Time.time >= _nextFireTime) {
        Fire();
      }
    }
  }

  private void UpdateDirection() {
    //TODO
  }

  public void Fire() {
    GameObject b = Instantiate(
      bullet, 
      (Vector2)transform.position + bulletSpawn,
      Quaternion.identity
    );

    //HACK:
    b.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

    _nextFireTime = Time.time + fireRate;
  }

  public void GiveTo(GameObject player) {
    GunController prev = player.GetComponentInChildren<GunController>();
    if (prev != null) {
      Destroy(prev.gameObject, 0.0f);
    }

    transform.position = player.transform.position;
    transform.localPosition = gripOffset;
  }

}
