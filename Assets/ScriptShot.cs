using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptShot : MonoBehaviour
{
    [Header("Configurações do tiro")]
    public float maxDistance = 50f;  // Alcance do tiro
    public LayerMask targetLayer;    // Camada dos alvos
    public InputActionProperty testActionButton;
    public Transform firePoint;      // 🔹 Novo campo para o ponto de disparo
    
    [Header("Som de acerto")]
    public AudioSource audioSource;      // 🔊 Arraste o AudioSource aqui
    public AudioClip hitSound;           // 🔹 Som que vai tocar quando acertar

    [Header("Som do tiro")]
    public AudioClip shootSound; // som do disparo
    
    [Header("Gerenciamento de alvos")]
    public TargetManager targetManager; // 🔹 Referência ao TargetManager
    public GameManager gameManager;



    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        bool button = testActionButton.action.WasPressedThisFrame();
        // Detecta se o gatilho do controle direito foi pressionado
        if (button == true) // Para Oculus
        {
            Debug.Log("atira");
            Shoot();
        }
    }

    void Shoot()
    {
        // 🔊 Toca o som do disparo
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
        
        if (gameManager != null)
            gameManager.RegisterShot(); // 🔹 Conta o tiro

        // 🔹 Agora o tiro sai do firePoint
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Target"))
            {
                // 🔊 Toca o som
                if (audioSource && hitSound)
                    audioSource.PlayOneShot(hitSound);

                Destroy(hit.collider.gameObject);
                Debug.Log("🎯 Acertou o alvo!");

                // 🔹 Cria novo alvo
                if (targetManager != null)
                    Debug.Log("spawnar alvo");
                    targetManager.SpawnTarget();

                if (gameManager != null)
                    gameManager.RegisterHit(); // 🔹 Conta o acerto
                    
            }
        }

        Debug.DrawRay(firePoint.position, firePoint.forward * maxDistance, Color.red, 2f);
    }

}
