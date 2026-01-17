using UnityEngine;

public class player : MonoBehaviour
{
    // variaveis em ingles por favor
    public float speed;
    public Rigidbody2D rig;

    float direction;
    bool canJump;

    void Start()
    {
   
    }

    
    void Update()
    {
        // Se pressionar direita, retorna 1. Se esquerda, retorna -1. Se não pressionar nada, retorna 0
        direction = Input.GetAxis("Horizontal");

        // Ação de pular
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rig.AddForce(Vector2.up * 300);
            canJump = false;
        }
        
    }
    //Aplica física
    void FixedUpdate()
    {
        rig.linearVelocity = new Vector2(direction * speed, rig.linearVelocity.y);
    }

    //Colisão
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
