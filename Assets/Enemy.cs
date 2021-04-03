using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int Health = 5;
    public bool Regen = true;

    public Material IdleMat;
    public Material DeathMat;

    private Vector3 origPos;
    private Quaternion origRot;
    private int SavedHealth;

    private void Start() {
        origPos = transform.position;
        origRot = transform.rotation;
        SavedHealth = Health;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Bullet") {
            Health--;
            Debug.Log("Target Hit!");
        }
    }

    private void Update() {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (Health <= 0) {
            GetComponent<Rigidbody>().isKinematic = false;
            renderer.material = DeathMat;
            if (Regen == true) {
                StartCoroutine(Respawn());
            }
            
        } else {
            renderer.material = IdleMat;
        }
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(15f);
        gameObject.transform.position = origPos;
        gameObject.transform.rotation = origRot;
        GetComponent<Rigidbody>().isKinematic = true;
        Health = SavedHealth;
    }
}
