using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Device[] devices => MonoSingleton<GameManager>.Instance.Devices;
    VirusEvent virusEvent => MonoSingleton<VirusEvent>.Instance;

    void Start()
    {
        Device device = devices[virusEvent.DeviceIndex];
    }

    void Update()
    {
        
    }
}
