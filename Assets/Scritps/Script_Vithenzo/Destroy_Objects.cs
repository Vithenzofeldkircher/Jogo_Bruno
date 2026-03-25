using UnityEngine;

public class Destroy_Objects : MonoBehaviour
{
    public float Tempo_de_vida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, Tempo_de_vida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
