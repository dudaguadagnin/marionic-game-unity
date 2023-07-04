using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    // Variável que armazena quantos pontos são adicionados no totalScore ao ser coletado
    public int Score;

    // Função que é chamada quando algo atravessa o objeto
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Se a tag do objeto de quem colidiu for igual a Player
        if(collider.gameObject.tag == "personagem") {
            // Soma o totalScore da classe GameController ao Score
            GameController.instance.totalScore += Score;
            // Atualiza o texto da UI através da função da classe GameController
            GameController.instance.UpdateScoreText();
            // Destroy o objeto dono deste Script (Point)
            Destroy(gameObject);
        }
    }
}