using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [Header("Config")]
    public Transform[] pontoDeSpawn;
    public GameObject[] objetosParaSpawnar;
    public float tempoMaximoEntreOsSpwans;
    public float TempoAtualDosSpwans;
    internal static object instance;

    public bool PodeSpawnar { get; private set; } = true;

    void Start()
    {
        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }

    void Update()
    {
        if (!PodeSpawnar) return;

        TempoAtualDosSpwans -= Time.deltaTime;

        if (TempoAtualDosSpwans <= 0)
        {
            SpawnarObjeto();
        }
    }

    private void SpawnarObjeto()
    {
        int ObjetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontoDeSpawn.Length);

        Instantiate(objetosParaSpawnar[ObjetoAleatorio],
            pontoDeSpawn[pontoAleatorio].position,
            Quaternion.Euler(0f, 0f, -90f));

        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }

    // NOVOS MÉTODOS:
    public void PausarSpawns()
    {
        PodeSpawnar = false;
    }

    public void RetomarSpawns()
    {
        PodeSpawnar = true;
        TempoAtualDosSpwans = tempoMaximoEntreOsSpwans;
    }
}
