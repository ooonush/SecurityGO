using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Gadgets[] Gadgets;

    public int PointsCurrentLevel;
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
    
    public int Level;
    public int MaxPoints => Level*5;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    public void AddPointOnClick()
    {
        PointsCurrentLevel += PointsOnClick;
        if (PointsCurrentLevel > MaxPoints)
        {
            Level++;
            PointsCurrentLevel = 0;
        }
        Points += PointsOnClick;
    }
}
