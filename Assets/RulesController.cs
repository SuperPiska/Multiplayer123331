using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class RulesController : NetworkBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    public Vector3 PlayerPosition = new Vector3(15f, 3f, 4.5f);

    private void Start()
    {
        SpawnBallServerRpc();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            SpawnBallServerRpc();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SpawnBallServerRpc();
        }
    }

    [ServerRpc]
    public void SpawnBallServerRpc()
    {
            GameObject spawnedObject = Instantiate(ball, new Vector3(6f, 1f, 4.5f), Quaternion.identity);
            spawnedObject.GetComponent<NetworkObject>().Spawn(destroyWithScene: true);
    }
}
