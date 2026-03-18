using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Start_Scene()
    {
        SceneManager.LoadScene("PortasScene");
    }

    public void Melissa_Scene()
    {
        SceneManager.LoadScene("Melissa");
    }

    public void Matheus_Scene()
    { 
    
        SceneManager.LoadScene("Matheus");
    }
    public void Vithenzo_Scene()
    {
        SceneManager.LoadScene("Vithenzo");
    }
}
