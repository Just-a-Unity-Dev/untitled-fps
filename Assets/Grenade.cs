using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay;

    public float blastRadius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    private void Start() {
        countdown = delay;
    }

    private void Update() {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded) {
            Explode();
            hasExploded = true;
        }
    }

    void Explode() {
        Debug.Log("BOOM!");
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObject in collidersToDestroy) {
            Enemy enemy = nearbyObject.GetComponent<Enemy>();   

            if (enemy != null) {
                enemy.Health =  enemy.Health - 3;
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in collidersToMove) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null) {
                rb.AddExplosionForce(force, transform.position, blastRadius);
            }
        }

        Destroy(gameObject);
    }

}
