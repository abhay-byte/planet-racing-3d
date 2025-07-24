using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public GameObject loadingScene;
	public Slider slider;
	public Text percent;
	//public GameObject destroy;
	public int Level;	

	public void LoadScene(){
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
	
		StartCoroutine(LoadAsynchronously(Level));
		
	}
	
	IEnumerator LoadAsynchronously (int sceneIndex)
	{	
		yield return new WaitForSeconds(1);

		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		loadingScene.SetActive(true);		

		
		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			int val = Convert.ToInt32(progress*100);
			percent.text = val+"%";
			
			yield return null;
		}
	}
}
