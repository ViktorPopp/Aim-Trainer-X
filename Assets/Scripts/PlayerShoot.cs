using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootRange = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        DataManager.shots++;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
        {
            if (hit.collider.CompareTag("Target"))
            {
                DataManager.hits++;
                FindFirstObjectByType<AudioManager>().PlaySound("TargetHit");
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
