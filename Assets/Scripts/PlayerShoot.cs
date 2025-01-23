using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootRange = 100f;     // Range of the shot

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
        {
            if (hit.collider.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

    }
}
