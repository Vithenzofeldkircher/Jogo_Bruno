using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject LaserDoInimigo;

    public Transform LocalDoDisparo;
    public Transform SegundoLocalDeDisparo;

    public float velocidadeDoInimigo;

    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;

    public bool InimigoAtirador;
    public bool InimigosDeDisparoDuplo;

    public int VidaMaximaDoInimigo;
    public int VidaAtualDoInimigo;

    void Start()
    {
        VidaAtualDoInimigo = VidaMaximaDoInimigo;
    }

    void Update()
    {
        MovimentarInimigo();

        if (InimigoAtirador)
        {
            AtirarLaser();
        }
    }

    public void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidadeDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;

        if (tempoAtualDosLasers <= 0)
        {
            Instantiate(LaserDoInimigo, LocalDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));

            if (InimigosDeDisparoDuplo && SegundoLocalDeDisparo != null)
            {
                Instantiate(LaserDoInimigo, SegundoLocalDeDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            }

            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        VidaAtualDoInimigo -= danoParaReceber;

        if (VidaAtualDoInimigo <= 0)
        {
            if (GameManeger.instance != null)
            {
                GameManeger.instance.ContarInimigoDerrotado();
            }
            else
            {
                Debug.LogError("GameManeger instance não encontrado!");
            }

            Destroy(gameObject);
        }
    }
}