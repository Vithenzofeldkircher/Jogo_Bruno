using UnityEngine;
using TMPro;

public class GameManeger : MonoBehaviour
{
    public static GameManeger instance;

    [Header("Sistema de Inimigos")]
    public int inimigosDerrotados;
    public int inimigosParaVitoria = 20;

    [Header("UI")]
    public TMP_Text textoInimigos;
    public GameObject telaVitoria;

    [Header("Referências Extras")]
    public GeradorDeObjetos geradorInimigos;
    public GameObject painelDialogo;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inimigosDerrotados = 0;
        AtualizarTexto();

        if (telaVitoria != null)
            telaVitoria.SetActive(false);

        if (painelDialogo != null)
            painelDialogo.SetActive(false);
    }

    public void ContarInimigoDerrotado()
    {
        inimigosDerrotados++;
        AtualizarTexto();

        Debug.Log("Inimigos derrotados: " + inimigosDerrotados);

        VerificarProgresso();
    }

    private void AtualizarTexto()
    {
        if (textoInimigos != null)
            textoInimigos.text = "Inimigos: " + inimigosDerrotados + "/" + inimigosParaVitoria;
    }

    private void VerificarProgresso()
    {
        if (inimigosDerrotados >= inimigosParaVitoria)
        {
            if (telaVitoria != null)
                telaVitoria.SetActive(true);
        }
    }

    public void RetomarJogoAposDialogo()
    {
        Debug.Log("Diálogo terminou, retomando spawns...");

        if (geradorInimigos != null)
            geradorInimigos.RetomarSpawns();

        if (painelDialogo != null)
            painelDialogo.SetActive(false);
    }
}