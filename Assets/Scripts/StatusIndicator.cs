using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{
	[SerializeField]
	private RectTransform healthBarRect;
	
	void Start(){
		if(healthBarRect == null){
			Debug.LogError("No health bar");
		}
	}
	
	public void SetHealth(int current, int max){
		float valueH = (float)current / max;
		
		healthBarRect.localScale = new Vector3(valueH, healthBarRect.localScale.y, healthBarRect.localScale.z);
		
	}
	
}
