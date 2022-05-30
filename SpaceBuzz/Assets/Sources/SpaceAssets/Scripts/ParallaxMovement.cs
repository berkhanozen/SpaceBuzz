using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour {
    //Set the direction that the screen or the camera is moving
    ScrollDirection direction;
    //This speed value create the parallax effect
    //Note: This speed affect the movement of the object based on the camera speed
    public float minSpeed = 0.2f;
    public float maxSpeed = 0.6f;
    Vector3 speed;
    float scrollValue;
    float lastScrollValue;

    public enum BehaviourOnExit { Destroy, Regenerate };
    //Define if the object is destroyed or regenerate when the object is out of the screen
    public BehaviourOnExit behaviourOnExit = BehaviourOnExit.Regenerate;

    Transform cameraTransform;
    //Determine the value offScreen that the object has to be to consider out of screen
    //It also is used to regenerate it
    //if the value is 1f is the screen's width or heigth depending on the direction   
    public float limitOffScreen = 1f;

    void Start () {
        if(SpaceManager.instance != null)
            direction = SpaceManager.instance.scrollDirection;
        cameraTransform = Camera.main.transform;
        if (minSpeed > maxSpeed) Debug.LogError("The variable minSpeed cannot be greater than maxSpeed");
        //Set the speed vector based on the scroll direction
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                lastScrollValue = cameraTransform.position.x;
                speed = new Vector3(Random.Range(minSpeed, maxSpeed), 0f, 0f);
                break;
            case ScrollDirection.RightToLeft:
                lastScrollValue = cameraTransform.position.x;
                speed = new Vector3(-Random.Range(minSpeed, maxSpeed), 0f, 0f);
                break;
            case ScrollDirection.DownToUp:
                lastScrollValue = cameraTransform.position.y;
                speed = new Vector3(0f, -Random.Range(minSpeed, maxSpeed), 0f);
                break;
            case ScrollDirection.UpToDown:
                lastScrollValue = cameraTransform.position.y;
                speed = new Vector3(0f, Random.Range(minSpeed, maxSpeed), 0f);
                break;
        }
    }

    void Regenerate()
    {
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1f + limitOffScreen, Random.Range(0f, 1f), 10f));
                break;
            case ScrollDirection.RightToLeft:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-limitOffScreen, Random.Range(0f, 1f), 10f));
                break;
            case ScrollDirection.DownToUp:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1f + limitOffScreen, 10f));
                break;
            case ScrollDirection.UpToDown:
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), -limitOffScreen, 10f));
                break;
        }
        //Check for random components to randomize the object
        RandomSize[] randomSizes = gameObject.GetComponentsInChildren<RandomSize>();
        RandomRotation[] randomRotations = gameObject.GetComponentsInChildren<RandomRotation>();
        RandomColor[] randomColors = gameObject.GetComponentsInChildren<RandomColor>();
        RandomSprite[] randomSprites = gameObject.GetComponentsInChildren<RandomSprite>();

        //Randomize the components in the object and his children objects
        if (randomSizes != null) foreach (RandomSize r in randomSizes) r.Generate();
        if (randomRotations != null) foreach (RandomRotation r in randomRotations) r.Generate();
        if (randomColors != null) foreach (RandomColor r in randomColors) r.Generate();
        if (randomSprites != null) foreach (RandomSprite r in randomSprites) r.Generate();
    }
	
	void Update () {
        //Set the current scroll position based on the camera position and the scroll direction
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                scrollValue = cameraTransform.position.x - lastScrollValue;
                lastScrollValue = cameraTransform.position.x;
                break;
            case ScrollDirection.RightToLeft:
                scrollValue = -cameraTransform.position.x + lastScrollValue;
                lastScrollValue = cameraTransform.position.x;
                break;
            case ScrollDirection.DownToUp:
                scrollValue = -cameraTransform.position.y + lastScrollValue;
                lastScrollValue = cameraTransform.position.y;
                break;
            case ScrollDirection.UpToDown:
                scrollValue = cameraTransform.position.y - lastScrollValue;
                lastScrollValue = cameraTransform.position.y;
                break;
        }

        //Apply the speed vector to the object
        transform.position += speed * scrollValue;

        //Check if the object is out of the screen
        switch (direction)
        {
            case ScrollDirection.LeftToRight:
                if(Camera.main.WorldToViewportPoint(transform.position).x < -limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
            case ScrollDirection.RightToLeft:
                if (Camera.main.WorldToViewportPoint(transform.position).x > 1f + limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
            case ScrollDirection.DownToUp:
                if (Camera.main.WorldToViewportPoint(transform.position).y < -limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
            case ScrollDirection.UpToDown:
                if (Camera.main.WorldToViewportPoint(transform.position).y > 1f + limitOffScreen)
                {
                    switch (behaviourOnExit)
                    {
                        case BehaviourOnExit.Destroy:
                            Destroy(gameObject);
                            break;
                        case BehaviourOnExit.Regenerate:
                            Regenerate();
                            break;
                    }
                }
                break;
        }
    }
}
