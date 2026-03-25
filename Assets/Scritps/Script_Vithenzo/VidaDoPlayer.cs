using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VidaDoPlayer : MonoBehaviour
{
    public int VidaMaximadoPlayer;

    public int VidaatualDoPlayer;

    public Slider BarradeVidaDoplayer;

    public int vidaParaReceber;

    public GameObject telaDerrota;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VidaatualDoPlayer = VidaMaximadoPlayer;

        BarradeVidaDoplayer.value = VidaatualDoPlayer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GanharVida(int VidaRecuperada)
    {
        if (VidaatualDoPlayer + VidaRecuperada <= VidaMaximadoPlayer)
        {
            VidaatualDoPlayer += VidaRecuperada;
        }
        else
        {
            VidaatualDoPlayer = VidaMaximadoPlayer;
        }

        BarradeVidaDoplayer.value = VidaatualDoPlayer;

    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; // despausa o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // recarrega a cena atual
    }


    public void DanoAoPlayer(int DanoParaReceber)
    {
        VidaatualDoPlayer -= DanoParaReceber;

        BarradeVidaDoplayer.value = VidaatualDoPlayer;

        Debug.Log("Vida do Player: " + VidaatualDoPlayer);

        if (VidaatualDoPlayer <= 0)
        {
            if (telaDerrota != null)
                telaDerrota.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
