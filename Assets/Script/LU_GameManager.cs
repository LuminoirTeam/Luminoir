using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.InputSystem.InputAction;

public class LU_GameManager : MonoBehaviour
{
	/*public Transform lumisSpawn;
    public Transform noctisSpawn;

    public GameObject lumisPrefab;
    public GameObject noctisPrefab;

    

    private List<PlayerInput> players = new List<PlayerInput>();
    private PlayerInputManager playerInputManager;

    public List<InputDevice> inputDevices = new List<InputDevice>();

    private void Awake()
    {
        playerInputManager = FindAnyObjectByType<PlayerInputManager>();

        camBehaviour = GetComponentInChildren<CameraBehaviour>();
        camBehaviour.player1 = lumisPrefab;
        camBehaviour.player2 = noctisPrefab;

        PlayerInput lumisInput = Instantiate(lumisPrefab, lumisSpawn.position, Quaternion.identity).GetComponent<PlayerInput>();
        PlayerInput noctisInput = Instantiate(noctisPrefab, noctisSpawn.position, Quaternion.identity).GetComponent<PlayerInput>();

        players.Add(lumisInput);
        players.Add(noctisInput);

        lumisInput.actions.FindActionMap("Player1").Enable();
        noctisInput.actions.FindActionMap("Player2").Enable();

        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added)
        {
            inputDevices.Add(device);
            AssignControllerToPlayer(device);
        }
        else if (change == InputDeviceChange.Removed)
        {
            inputDevices.Remove(device);
        }
    }

    private void AssignControllerToPlayer(InputDevice device)
    {
        if (players.Count == 0 || players.Count == 1)
        {
            if (players.Count == 0)
            {
                players[0].SwitchCurrentControlScheme(device);
            }
            else if (players.Count == 1)
            {
                players[1].SwitchCurrentControlScheme(device);
            }
        }
    }

    private void OnDestroy()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }*/

	//   private PlayerInput playerInput;
	//   private LU_CharacterController characterController;
	//   private CameraBehaviour camBehaviour;
	//   private bool isNoctis;
	//   private GameObject lumisPrefab;
	//   private GameObject noctisPrefab;


	//public Transform lumisSpawn;
	//   public Transform noctisSpawn;

	//   public GameObject emptyPlayer;

	//   private void Awake()
	//   {
	//       playerInput = GetComponent<PlayerInput>();
	//       var controller = FindAnyObjectByType<LU_CharacterController>();
	//       noctisPrefab = emptyPlayer.transform.Find("Noctis_Temp")?.gameObject;
	//	lumisPrefab = emptyPlayer.transform.Find("Lumis_Temp")?.gameObject;
	//	//var index = playerInput.playerIndex;

	//       camBehaviour = GetComponentInChildren<CameraBehaviour>();
	//       camBehaviour.player1 = emptyPlayer;
	//       camBehaviour.player2 = emptyPlayer;



	//  //     if (!isNoctis)
	//  //     {
	//  //         Instantiate(emptyPlayer, noctisSpawn);
	//  //         noctisPrefab.gameObject.SetActive(true);
	//  //         lumisPrefab.gameObject.SetActive(false);

	//  //     }
	//  //     else
	//  //     {
	//  //         Instantiate(emptyPlayer, lumisSpawn);
	//		//noctisPrefab.gameObject.SetActive(true);
	//		//lumisPrefab.gameObject.SetActive(false);

	//  //     }
	//   }

	//public void OnPlayerJoined(PlayerInput playerInput)
	//{
	//	if (!isNoctis)
	//	{
	//		Instantiate(emptyPlayer, noctisSpawn);
	//		noctisPrefab.gameObject.SetActive(true);
	//		lumisPrefab.gameObject.SetActive(false);

	//	}
	//	else
	//	{
	//		Instantiate(emptyPlayer, lumisSpawn);
	//		noctisPrefab.gameObject.SetActive(true);
	//		lumisPrefab.gameObject.SetActive(false);
	//           isNoctis = true;
	//	}

	//}




	//[SerializeField] private Transform lumisSpawn;
	//[SerializeField] private Transform noctisSpawn;
	//[SerializeField] private GameObject emptyPlayer;

	//private List<PlayerInput> activePlayers = new List<PlayerInput>(); // Liste des joueurs actifs

	//private void Awake()
	//{
	//	if (emptyPlayer == null)
	//	{
	//		Debug.LogError("Le prefab 'emptyPlayer' n'est pas assign� !");
	//	}
	//}

	//public void OnPlayerJoined(PlayerInput playerInput)
	//{
	//	// V�rifie si ce joueur est d�j� ajout�
	//	if (activePlayers.Contains(playerInput))
	//	{
	//		Debug.LogWarning("Ce joueur est d�j� actif !");
	//		return;
	//	}

	//	// V�rifie si le nombre maximum de joueurs est atteint
	//	if (activePlayers.Count >= 2)
	//	{
	//		Debug.LogWarning("Deux joueurs maximum sont autoris�s !");
	//		return;
	//	}

	//	// Ajoute le joueur � la liste active
	//	activePlayers.Add(playerInput);

	//	GameObject spawnedPlayer = null;

	//	// Instancie en fonction du nombre de joueurs actuels
	//	if (activePlayers.Count == 1) // Premier joueur : Lumis
	//	{
	//		spawnedPlayer = Instantiate(emptyPlayer, lumisSpawn.position, lumisSpawn.rotation);
	//		ConfigureCharacter(spawnedPlayer, isLumis: true);
	//		Debug.Log("Joueur 1 rejoint : Lumis");
	//	}
	//	else if (activePlayers.Count == 2) // Deuxi�me joueur : Noctis
	//	{
	//		spawnedPlayer = Instantiate(emptyPlayer, noctisSpawn.position, noctisSpawn.rotation);
	//		ConfigureCharacter(spawnedPlayer, isLumis: false);
	//		Debug.Log("Joueur 2 rejoint : Noctis");
	//	}
	//}

	//private void ConfigureCharacter(GameObject player, bool isLumis)
	//{
	//	// Trouver les prefabs enfants
	//	Transform lumisChild = player.transform.Find("Lumis_Temp");
	//	Transform noctisChild = player.transform.Find("Noctis_Temp");

	//	if (lumisChild == null || noctisChild == null)
	//	{
	//		Debug.LogError("Les enfants 'Lumis_Temp' ou 'Noctis_Temp' sont introuvables !");
	//		return;
	//	}

	//	// Activer/d�sactiver les enfants en fonction du joueur
	//	lumisChild.gameObject.SetActive(isLumis);
	//	noctisChild.gameObject.SetActive(!isLumis);

	//	// Assigner le pouvoir correspondant
	//	var characterController = player.GetComponent<LU_CharacterController>();
	//	if (characterController != null)
	//	{
	//		if (isLumis)
	//		{
	//			characterController.power = player.AddComponent<LU_PowerLumis>();
	//		}
	//		else
	//		{
	//			characterController.power = player.AddComponent<LU_PowerNoctis>();
	//		}
	//	}
	//	else
	//	{
	//		Debug.LogError("LU_CharacterController est introuvable sur le prefab !");
	//	}
	//}
	//}

	[SerializeField] private Transform lumisSpawn;
	[SerializeField] private Transform noctisSpawn;
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
		activePlayers.Add(playerInput);

		GameObject spawnedPlayer = null;

		// Instancie et configure en fonction de l'ordre des joueurs
		if (activePlayers.Count == 0) // Premier joueur : Lumis
		{
			spawnedPlayer = Instantiate(emptyPlayer, lumisSpawn.position, lumisSpawn.rotation);
			ConfigureCharacter(spawnedPlayer, isLumis: true);
			Debug.Log("Joueur 1 rejoint : Lumis");
		}
		else if (activePlayers.Count == 1) // Deuxi�me joueur : Noctis
		{
			spawnedPlayer = Instantiate(emptyPlayer, noctisSpawn.position, noctisSpawn.rotation);
			ConfigureCharacter(spawnedPlayer, isLumis: false);
			Debug.Log("Joueur 2 rejoint : Noctis");
		}

		// Associer le prefab au PlayerInput
		if (spawnedPlayer != null)
		{
			// D�place le PlayerInput actuel sur le nouvel objet cr��
			playerInput.transform.SetParent(spawnedPlayer.transform);
			playerInput.transform.localPosition = Vector3.zero; // Optionnel : r�initialise la position relative
			playerInput.transform.localRotation = Quaternion.identity;

			// Associe le PlayerInput au nouvel objet
			playerInput.gameObject.SetActive(false); // D�sactive temporairement pour �viter les conflits
			playerInput.transform.SetParent(null); // D�tache du prefab temporaire
			playerInput.gameObject.SetActive(true); // R�active le PlayerInput

			// V�rification suppl�mentaire
			Debug.Log($"PlayerInput r�assign� � l'objet : {spawnedPlayer.name}");
		}
		else
		{
			Debug.LogError("Le joueur n'a pas pu �tre associ� au prefab !");
		}
	}

	private void ConfigureCharacter(GameObject player, bool isLumis)
	{
		// Trouver les prefabs enfants
		Transform lumisChild = player.transform.Find("Lumis_Temp");
		Transform noctisChild = player.transform.Find("Noctis_Temp");

		if (lumisChild == null || noctisChild == null)
		{
			Debug.LogError("Les enfants 'Lumis_Temp' ou 'Noctis_Temp' sont introuvables !");
			return;
		}

		// Activer/d�sactiver les enfants en fonction du joueur
		lumisChild.gameObject.SetActive(isLumis);
		noctisChild.gameObject.SetActive(!isLumis);

		// Assigner le pouvoir correspondant
		var characterController = player.GetComponent<LU_CharacterController>();
		if (characterController != null)
		{
			if (isLumis)
			{
				characterController.power = player.AddComponent<LU_PowerLumis>();
			}
			else
			{
				characterController.power = player.AddComponent<LU_PowerNoctis>();
			}
		}
		else
		{
			Debug.LogError("LU_CharacterController est introuvable sur le prefab !");
		}
	}
}