using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractM : MonoBehaviour
{
    public GameObject textoE;

    private bool playerPerto = false;

    void Start()
    {
        if (textoE != null)
            textoE.SetActive(false);
    }

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Matheus");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (textoE != null)
                textoE.SetActive(true);

            playerPerto = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (textoE != null)
                textoE.SetActive(false);

            playerPerto = false;
        }
    }
}