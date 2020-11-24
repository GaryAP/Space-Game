using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	
	public GameObject projectile;
	public Transform projectileSpawn;
	public float nextFire = 1.0f;
	public float currentTime = 0.0f;
	public static AudioClip shootSound;
    static AudioSource audioSource = new AudioSource();
	
    // Start is called before the first frame update
    void Start()
    {
        projectileSpawn = this.gameObject.transform;
		shootSound = Resources.Load<AudioClip>("Pew");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }
	
	public void shoot(){
		currentTime += Time.deltaTime;
		if(Input.GetButton("Fire1") && currentTime > nextFire){
			nextFire += currentTime;
			audioSource.PlayOneShot(shootSound);
			Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
			
			nextFire -= currentTime;
			currentTime = 0.0f;
		}
	}
}
