using UnityEngine;
using UnityEngine.SceneManagement;

public class InteracaoPorta : MonoBehaviour
{
    public GameObject textoE;
    public string nomeDaCena;

    private bool playerPerto = false;

    void Start()
    {
        textoE.SetActive(false);
    }

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Vithenzo");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textoE.SetActive(true);
            playerPerto = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textoE.SetActive(false);
            playerPerto = false;
        }
    }
}