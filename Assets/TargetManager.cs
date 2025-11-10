using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [Header("Configurações dos alvos")]
    public GameObject targetPrefab; // Prefab do alvo
    public float spawnRadius = 5f;  // Distância do centro
    public Vector2 heightRange = new Vector2(1f, 3f); // Altura mínima e máxima

    private GameObject currentTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTarget();
    }

        public void SpawnTarget()
    {
        // Destroi o anterior se ainda existir
        if (currentTarget != null)
            DestroyImmediate(currentTarget);

        // Gera posição aleatória
        Vector3 randomPos = Random.onUnitSphere * spawnRadius;
        randomPos.y = Random.Range(heightRange.x, heightRange.y);
        randomPos.y = Mathf.Max(randomPos.y, heightRange.x); // garante altura mínima
        randomPos.y = Mathf.Min(randomPos.y, heightRange.y); // garante altura máxima
        randomPos.y = Mathf.Abs(randomPos.y); // evita negativos

        // Cria novo alvo
        currentTarget = Instantiate(targetPrefab, randomPos, Quaternion.identity);
        currentTarget.tag = "Target";
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
