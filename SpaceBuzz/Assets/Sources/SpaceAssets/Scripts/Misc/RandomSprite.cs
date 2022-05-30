using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomSprite : MonoBehaviour {
	SpriteRenderer spriteRenderer;
    //Sprites that will be used randomly in this spriteRenderer
	public Sprite[] sprites;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
		Generate ();
	}

    //Generate and assign one of the sprites randomly
    public void Generate(){
		if(sprites.Length > 0){
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
		}
	}
	
	void Update () {
	
	}
}
