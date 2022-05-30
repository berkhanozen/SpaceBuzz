using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour {
    //Time that takes in activate the shooting star after generation
    [Range(0f, 30.0f)]
    public float spawnTime = 4f;
    float currentSpawnTime;

    //This speed value to move the shooting star
    [Range(0.3f, 10.0f)]
    public float speed = 1f;
    float currentSpeed;

    //If not activated, the shooting star does not move
    bool activated = false;

    //Define if the spawnTime and the speed should be randomized or not at generation
    public bool randomize = true;

    //Apply modifications if the camera is not orthogonal
    float modificator = 1f;
    //Distance from the camera. Used if the camera is not orthogonal
    float cameraDistance = 10f;

    ScrollDirection direction = ScrollDirection.LeftToRight;
    void Start ()
    {
        if(SpaceManager.instance != null)
        {
            direction = SpaceManager.instance.scrollDirection;
        }

        if (!Camera.main.orthographic)
        {
            modificator = Mathf.Max(Screen.width, Screen.height);
            cameraDistance = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
        }
        if (!randomize)
        {
            currentSpawnTime = spawnTime;
            currentSpeed = speed;
        }
        Generate();
	}
	
    public void Generate()
    {
        //Deactivate the shoting star
        Activate(false);
        //Randomize spawn time and speed
        if (randomize)
        {
            currentSpawnTime = Random.Range(0.3f, spawnTime);
            currentSpeed = Random.Range(0.3f, speed);
        }
        //Wait for currentSpawnTime to reactivate the shooting star
        StartCoroutine(waitToActivate(currentSpawnTime));
    }

    IEnumerator waitToActivate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //After waiting, activate the shooting star
        Activate(true);
    }

    //Activate or deactivate the shooting star movement
    public void Activate(bool activate)
    {
        activated = activate;
        if (activated)
        {
            //Once activated, the first action is to give the shooting star a new position
            Vector3 newPosition = Vector3.zero;

            switch (direction)
            {
                case ScrollDirection.LeftToRight:
                    if (Camera.main.orthographic)
                        newPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1.5f), (Random.Range(0, 100) < 50 ? -0.5f : 1.5f), 0f));
                    else
                        newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-0.5f, 1f) * modificator, (Random.Range(0, 100) < 50 ? -0.5f : 1.5f) * modificator, cameraDistance));
                    break;
                case ScrollDirection.RightToLeft:
                    if (Camera.main.orthographic)
                        newPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-0.5f, 1f), (Random.Range(0, 100) < 50 ? -0.5f : 1.5f), 0f));
                    else
                        newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-0.5f, 1f) * modificator, (Random.Range(0, 100) < 50 ? -0.5f : 1.5f) * modificator, cameraDistance));
                    break;
                case ScrollDirection.DownToUp:
                    if (Camera.main.orthographic)
                        newPosition = Camera.main.ViewportToWorldPoint(new Vector3((Random.Range(0, 100) < 50 ? -0.5f : 1.5f), Random.Range(0f, 1.5f), 0f));
                    else
                        newPosition = Camera.main.ScreenToWorldPoint(new Vector3((Random.Range(0, 100) < 50 ? -0.5f : 1.5f) * modificator, Random.Range(0f, 1.5f) * modificator, cameraDistance));
                    break;
                case ScrollDirection.UpToDown:
                    if (Camera.main.orthographic)
                        newPosition = Camera.main.ViewportToWorldPoint(new Vector3((Random.Range(0, 100) < 50 ? -0.5f : 1.5f), Random.Range(-0.5f, 1f), 0f));
                    else
                        newPosition = Camera.main.ScreenToWorldPoint(new Vector3((Random.Range(0, 100) < 50 ? -0.5f : 1.5f) * modificator, Random.Range(-0.5f, 1f) * modificator, cameraDistance));
                    break;
            }
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            //It defines the point to the shooting star will be pointing
            Vector3 forwardDirection = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0f) - transform.position;
            //Force the forwardDirection to don't change the position in the z axis
            transform.forward = new Vector3(forwardDirection.x, forwardDirection.y, 0f);
        }
    }
    
	void Update () {
        //If is not activated, don't update
        if (!activated) return;
        transform.position += transform.forward * currentSpeed;
        //Ask if the shooting star has reached the limit to be regenerated
        Rect rect = new Rect(-1f, -1f, 3f, 3f);
        if (!Camera.main.orthographic)
        {
            Vector3 rectPosition = Camera.main.ScreenToWorldPoint(new Vector3(-1f * modificator, -1f * modificator, 10f));
            Vector3 rectSize = Camera.main.ScreenToWorldPoint(new Vector3(3f * modificator, 3f * modificator, 10f));
            rect = new Rect(rectPosition.x, rectPosition.y, rectSize.x, rectSize.y);
            if (!rect.Contains(transform.position))
            {
                Generate();
            }
        }
        else
        {
            if (!rect.Contains(Camera.main.WorldToViewportPoint(transform.position)))
            {
                Generate();
            }
        }
    }
}
