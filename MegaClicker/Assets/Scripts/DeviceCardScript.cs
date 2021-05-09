using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceCardScript : MonoBehaviour
{
    [SerializeField] float pointsPerSecond;
    [SerializeField] List<GameObject> characteristics;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCharacteristic(0, pointsPerSecond);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeCharacteristic(int index, float value)
    {
        if(index < characteristics.Count)
            characteristics[index].GetComponent<Text>().text = value.ToString();
    }
}


