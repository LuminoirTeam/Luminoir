using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LU_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject lumisSpawn;
    [SerializeField] private GameObject noctisSpawn;
    [SerializeField] private GameObject emptyPlayer;

    private List<PlayerInput> activePlayers = new List<PlayerInput>();

    private void Awake()
    {
        if (emptyPlayer == null)
        {
            Debug.LogError("Le prefab 'emptyPlayer' n'est pas assign� !");
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        // V�rifie si le joueur est d�j� ajout�
        if (activePlayers.Contains(playerInput))
        {
            Debug.LogWarning("Ce joueur est d�j� actif !");
            return;
        }

        // V�rifie si le nombre maximum de joueurs est atteint
        if (activePlayers.Count >= 2)
        {
            Debug.LogWarning("Deux joueurs maximum sont autoris�s !");
            return;
        }

        // Ajoute le joueur � la liste active
        GameObject spawnedPlayer = null;

        // Instancie et configure en fonction de l'ordre des joueurs
        if (activePlayers.Count == 0) // Premier joueur : Lumis
        {
            spawnedPlayer = playerInput.gameObject;
            playerInput.gameObject.transform.position = lumisSpawn.transform.position;
            playerInput.gameObject.GetComponent<LU_SetPlayer>().isNoctis = false;
            playerInput.gameObject.GetComponent<LU_SetPlayer>().SetActivePrefab();
            Debug.Log("Joueur 1 rejoint : Lumis");
        }
        else if (activePlayers.Count == 1) // Deuxi�me joueur : Noctis
        {
            spawnedPlayer = playerInput.gameObject;
            playerInput.gameObject.transform.position = noctisSpawn.transform.position;
            playerInput.gameObject.GetComponent<LU_SetPlayer>().isNoctis = true;
            playerInput.gameObject.GetComponent<LU_SetPlayer>().SetActivePrefab();
            playerInput.defaultActionMap = "Player";
            Debug.Log("Joueur 2 rejoint : Noctis");
        }

        activePlayers.Add(playerInput);
    }
}