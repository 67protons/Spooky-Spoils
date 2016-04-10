using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatuePuzzleManager : MonoBehaviour {
	// Use this for initialization
    public GhostStatue norm, pleb, kawaii, nerd;
    //private List<GhostStatue> activated;

    void Awake()
    {
    }
	
	// Update is called once per frame
    void Update()
    {

        if ((norm.hasGaze && norm.activated) || (pleb.hasGaze && pleb.activated) || (kawaii.hasGaze && kawaii.activated) || (nerd.hasGaze && nerd.activated))
        {

            norm.isChasing = false;
            pleb.isChasing = false;
            nerd.isChasing = false;
            kawaii.isChasing = false;
        }

        else
        {
            norm.isChasing = true;
            pleb.isChasing = true;
            nerd.isChasing = true;
            kawaii.isChasing = true;
        }
    }
}
