using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	GameManager mgr = new GameManager();
	public Rigidbody2D projectile;
	
	public float moveSpeed = 15.0f;
	
    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(-1,0) * moveSpeed;
    }
	
		void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SetActive(false);
			Object.Destroy(this.gameObject);
			mgr.RestartGame();
		}
		
		if(col.gameObject.name == "LeftWall"){
			Object.Destroy(this.gameObject);
		}
	}
}
