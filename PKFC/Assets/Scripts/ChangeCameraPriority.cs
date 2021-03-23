using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraPriority : MonoBehaviour
{
    
    private bool storeCamera;
    [SerializeField]
    private CinemachineVirtualCamera actioncamera;
    [SerializeField]
    private CinemachineVirtualCamera storecamera;

    void Start()
    {
        storeCamera = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("cambio" + storeCamera);
        if (other.gameObject.tag=="Player")
        {
            
            storeCamera = !storeCamera;
            
        }
    }
    void Update()
    {
        Switchpriority(storeCamera);
    }
    private void Switchpriority(bool actualcamera)
    {
        if (actualcamera)
        {
            actioncamera.m_Priority = 0;
            storecamera.m_Priority = 1;
        }
        else if(!actualcamera)
        {
            storecamera.m_Priority = 0;
            actioncamera.m_Priority = 1;
        }
        
    }
}
