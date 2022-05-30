using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollDirection { LeftToRight, RightToLeft, DownToUp, UpToDown };

public class SpaceManager : MonoBehaviour {
    //Set the direction that the screen or the camera is moving
    public ScrollDirection scrollDirection = ScrollDirection.LeftToRight;
    ScrollDirection direction;

    public static SpaceManager instance = null;

    void Start () {
        direction = scrollDirection;
        instance = this;
    }
	
	void Update () {
        //Prevent that the variable could be changed in execution mode (removing this could cause bugs)
        if(direction != scrollDirection)
        {
            scrollDirection = direction;
        }
	}
}
