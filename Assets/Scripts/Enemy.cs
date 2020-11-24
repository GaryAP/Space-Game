using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	
	GameManager mgr = new GameManager();
	public Transform playerTransform;
	public Rigidbody2D enemy;
	public float moveSpeed = 10.0f;
	public bool changeDirection = false;
	private Transform enemyT;
	
	[System.Serializable]
	public class EnemyStats{
		public int maxHealth = 10;
		private int currentHealth;
		
		public int curHealth{
			get{return currentHealth;}
			set{currentHealth = Mathf.Clamp(value, 0, maxHealth); }
		}
	
		public void Init(){
			currentHealth = maxHealth;
		}
		
	}
	
	
	
	public void DamageEnemy(int damage){
		stats.curHealth -= damage;
		if(stats.curHealth <= 0){
			Object.Destroy(this.gameObject);
			mgr.RestartGame();
		}
		
		if(statInd != null){
			statInd.SetHealth(stats.curHealth, stats.maxHealth);
		}
		
	}
	
	
    public EnemyStats stats = new EnemyStats();
	
	[Header("optional: ")]
	[SerializeField]
	private StatusIndicator statInd; 
	
    void Start()
    {
		stats.Init();
		enemy = this.gameObject.GetComponent<Rigidbody2D>();
		enemyT = this.gameObject.GetComponent<Transform>();
		if(statInd != null){
			statInd.SetHealth(stats.curHealth, stats.maxHealth);
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveEnemy();
    }
	
	public void moveEnemy(){
		
		enemyT.position = Vector3.Lerp(enemyT.position, new Vector3(enemyT.position.x,playerTransform.position.y,0),.08f);

		/*if(changeDirection == true){
			enemy.velocity = new Vector2(0,1) * -1 * moveSpeed;
		}else if(changeDirection != true){
			enemy.velocity = new Vector2(0,1) * moveSpeed;
		}*/
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "TopWall"){
			Debug.Log("Hit TopWall");
			changeDirection = true;
		}
		if(col.gameObject.name == "BottomWall"){
			Debug.Log("Hit BotWall");
			changeDirection = false;
		}
	}
}
