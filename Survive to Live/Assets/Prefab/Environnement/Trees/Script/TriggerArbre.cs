using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class TriggerArbre : MonoBehaviour {

	Color tmp;
	public float AlphaEr = 0.5f; 

	// Use this for initialization
	void Start () {
		tmp = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.tag.Equals("Player"))
		{
			
			tmp.a = AlphaEr;
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = tmp;

        	//gameObject.GetComponent<Renderer>().material.color.a = 0.3f ;

		}
    }
	void OnTriggerExit2D(Collider2D other)
    {
		tmp.a = 1.0f;
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = tmp;
      //  gameObject.GetComponent<Renderer>().material.color.a = 1.0f ; 
    }

	
	// Update is called once per frame
	void Update () {

		//Si Player entre dans le trigger "Cube"

		//Arbre = Opacity 0.3;

		//Si player sort du trigger "Cube"

		//Arbre = Opacity 1; 
	}


}

