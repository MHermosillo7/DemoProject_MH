using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_ByCamera : MonoBehaviour
{
    public GameObject projectile;

    public Transform cam;

    public Transform projectileSpawn;

    public float projectileSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Vector3 direction = (cam.forward).normalized;

            direction = new Vector3(direction.x, 0, direction.z);

            GameObject newProjectile = Instantiate(projectile, projectileSpawn.position, Quaternion.identity);

            newProjectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
        }
    }
}
