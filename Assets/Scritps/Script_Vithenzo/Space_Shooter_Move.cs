using UnityEngine;

public class Space_Shooter_Move : MonoBehaviour
{
    public GameObject laserDojogador;
    public Transform LocalDoDisparo;

    public float velocidadeDaNave;

    private Vector2 TeclasApertadas;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovimentarJogador();
        AtirarLaserDoPlayer();
    }

    public void MovimentarJogador()
    {
        TeclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        body.linearVelocity = TeclasApertadas.normalized * velocidadeDaNave;
    }

    public void AtirarLaserDoPlayer()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (laserDojogador == null || LocalDoDisparo == null)
            {
                Debug.LogError("Laser ou ponto de disparo não estão atribuídos!");
                return;
            }

            Instantiate(laserDojogador, LocalDoDisparo.position, LocalDoDisparo.rotation);
        }
    }
}