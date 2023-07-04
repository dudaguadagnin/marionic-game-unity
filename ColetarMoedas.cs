using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetarMoedas : MonoBehaviour {

    public Text scoreTxt;
    private int score;
    
    private void Start() {
        score = 0;
    }
    private void Update() {
        scoreTxt.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag ("Moeda") ==true) {
            score = score +1;
            Destroy (col.gameObject);
            

        }
        if (col.CompareTag ("Obstaculo") ==true) {
            score = score -1;
            // Destroy (col.gameObject) ;

        }
    }
}