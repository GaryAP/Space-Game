using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
	public Rigidbody2D projectile;
	
	public float moveSpeed = 10.0f;
	
    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        projectile.velocity = new Vector2(1,0) * moveSpeed;
    }
	
	public Enemy stats = new Enemy();
	
	void OnCollisionEnter2D(Collision2D col){
		
		Enemy enemyR = col.gameObject.GetComponent<Enemy>();
		
		if(col.gameObject.name == "EnemyShip"){
			enemyR.DamageEnemy(1);
			Debug.Log("Hit");
			Object.Destroy(this.gameObject);
		}
		if(col.gameObject.name == "RightWall"){
			Object.Destroy(this.gameObject);
		}
	}
}
