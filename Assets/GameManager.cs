using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Configurações do jogo")]
    public int totalTargets = 5; // Quantos alvos no total

    private int targetsHit = 0;
    private int shotsFired = 0;
    private float startTime;
    private bool gameStarted = false;
    private bool gameEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        targetsHit = 0;
        shotsFired = 0;
        gameEnded = false;
        startTime = Time.time;
        gameStarted = true;
        Debug.Log("🏁 Jogo iniciado!");
    }

    public void RegisterShot()
    {
        if (!gameStarted || gameEnded) return;
        shotsFired++;
    }

    public void RegisterHit()
    {
        if (!gameStarted || gameEnded) return;
        targetsHit++;

        if (targetsHit >= totalTargets)
        {
            EndGame();
        }
    }

        void EndGame()
    {
        gameEnded = true;
        float totalTime = Time.time - startTime;
        float accuracy = shotsFired > 0 ? (float)targetsHit / shotsFired * 100f : 0f;

        Debug.Log($"🏆 Fim de jogo!");
        Debug.Log($"🎯 Acertos: {targetsHit}/{shotsFired} ({accuracy:F1}%)");
        Debug.Log($"⏱️ Tempo total: {totalTime:F2} segundos");
    }

    public bool IsGameActive()
    {
        return gameStarted && !gameEnded;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
