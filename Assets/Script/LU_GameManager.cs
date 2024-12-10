using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
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

    private PlayerInput playerInput;
    private LU_CharacterController characterController;
    private CameraBehaviour camBehaviour;
    private bool isNoctis;

    public Transform lumisSpawn;
    public Transform noctisSpawn;

    public GameObject emptyPlayer;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var controller = FindAnyObjectByType<LU_CharacterController>();
        var index = playerInput.playerIndex;

        camBehaviour = GetComponentInChildren<CameraBehaviour>();
        camBehaviour.player1 = emptyPlayer;
        camBehaviour.player2 = emptyPlayer;

        if (isNoctis)
        {
            Instantiate(emptyPlayer, noctisSpawn);
            emptyPlayer.gameObject.GetComponent<LU_CharacterController>().power = GetComponent<LU_PowerNoctis>();
        }
        else
        {
            Instantiate(emptyPlayer, lumisSpawn);
            emptyPlayer.gameObject.GetComponent<LU_CharacterController>().power = GetComponent<LU_PowerLumis>();
        }
    }
}