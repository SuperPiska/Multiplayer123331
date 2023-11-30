using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    public Canvas Canvas;
    public Camera Camera;
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;
    [SerializeField] private Button ServerButton;
    void Awake()
    {
        HostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            Destroy(Camera.gameObject);
            Destroy(Canvas.gameObject);
        });

        ServerButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            Destroy(Camera.gameObject);
            Destroy(Canvas.gameObject);
        });

        ClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            Destroy(Camera.gameObject);
            Destroy(Canvas.gameObject);
        });
    }
}
