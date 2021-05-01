using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Gadgets[] Gadgets;



    public int Points;
    public int PointsOnClick
    {
        get
        {
            var sum = 1;
            foreach (var gadget in Gadgets)
                sum += gadget.PointsOnClick;
            return sum;
        }
    }
    
    [Range(1,16)] public int Level;
    public int MaxPoints; //=> (int)Math.Pow(2.0, Level);

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    public void Click()
    {
        Points += PointsOnClick;
        if (Points >= MaxPoints)
            Level++;
        Debug.Log(MaxPoints);
    }
}
