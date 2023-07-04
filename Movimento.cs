using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movimento : MonoBehaviour {

    private float horizontalInput;
    private Rigidbody2D rb;
    [SerializeField] private int velocidade = 10;
    [SerializeField] private Transform peDoPersonagem;
    [SerializeField] private LayerMask chaoLayer;
    private bool estaNoChao;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    bool imortal;
    public float tempoIP;
    private int movendoHash = Animator.StringToHash("movendo");
    private int saltandoHash = Animator.StringToHash("saltando");

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao) {
            rb.AddForce(Vector2.up * 600);
        }
        estaNoChao = Physics2D.OverlapCircle(peDoPersonagem.position, 0.2f, chaoLayer);
        animator.SetBool(movendoHash, horizontalInput != 0);
        animator.SetBool(saltandoHash, !estaNoChao);
        if(horizontalInput > 0) {
            spriteRenderer.flipX = false;
        }
        else if(horizontalInput < 0) {
            spriteRenderer.flipX = true;
        }
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(horizontalInput * velocidade, rb.velocity.y);
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!imortal)
        {
        if (col.CompareTag ("Obstaculo") ==true)
        {
            StartCoroutine(PiscarDano());
            imortal = true;
            Invoke("ResetImortal", tempoIP);
        }
        }
    }

    IEnumerator PiscarDano()
    {
        for (int i = 0; i < tempoIP; i++)
        {
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.enabled = true;
    }

    void ResetImortal()
    {
        imortal = false;
    }
}
