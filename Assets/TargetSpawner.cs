using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Configurações do Spawner")]
    public GameObject targetPrefab;   // Prefab do alvo
    public int numberOfTargets = 10;  // Quantos alvos spawnar
    public float radius = 5f;         // Distância do centro (0,0,0)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTargets();
    }

    void SpawnTargets()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            // Gera um ângulo aleatório de 0 a 360 graus
            float angle = Random.Range(0f, 360f);

            // Converte o ângulo em uma direção (somente no plano XZ)
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

            // Altura aleatória acima de 1.0f (ex: entre 1 e 3 metros)
            float y = Random.Range(1.0f, 3.0f);

            // Cria a posição e instancia o alvo
            Vector3 spawnPosition = new Vector3(x, y, z);

            // Faz o alvo olhar para o centro da cena (0,0,0)
            Quaternion rotation = Quaternion.LookRotation(-spawnPosition.normalized);

            Instantiate(targetPrefab, spawnPosition, rotation);
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
