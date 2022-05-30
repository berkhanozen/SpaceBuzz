using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomColor : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public Color[] colors;
    //From 0 to 100, if 0, always visible 
    [Range(0.0f, 100.0f)]
    public int invisibleProbability = 30;
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        Generate();
	}

    //Generate a new random color or hide the object
	public void Generate(){
		if (invisibleProbability > 0 && Random.Range (0, 100) < invisibleProbability) {
            spriteRenderer.color = Color.clear;
			return;
		}
		int colorSelected = Random.Range (0, colors.Length);
		if (colors.Length > 0) {
            spriteRenderer.color = colors[colorSelected];
		}
	}
	
	void Update () {
	
	}
}
