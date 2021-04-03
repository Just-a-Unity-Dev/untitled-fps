using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public int MaxHealth;
    public int Health = 5;
    public TMP_Text Display;

    private FirstPersonAIO FP;
    private Rigidbody rb;
    public GameObject weaponSelect;

    private void Start() {
        FP = GetComponent<FirstPersonAIO>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Health > MaxHealth) {
            Health = MaxHealth;
        }
        if (Health == 0) {
            FP.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            weaponSelect.SetActive(false);
        }

        Display.text = Health.ToString();
    }
}
