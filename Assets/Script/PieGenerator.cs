﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pieを生成する機能を持つクラス
public class PieGenerator : MonoBehaviour
{
	public GameObject piePrefab;
	public CharacterStatus status;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	//Playerの手元で生成する用
	public GameObject Generate(Transform _transform, OVRInput.Controller controller)
	{
		if(status.pieCream < 5.0f){
			return null;
		}
		if(SceneManager.GetActiveScene().name == "Play"){
			status.pieCream -= 5.0f;
		}
		Transform trans = _transform;
		//Vector3 size = _transform.localScale;

		if (controller == OVRInput.Controller.RTouch)
		{
			trans.Translate(-0.1f, 0, 0);
			//trans.Rotate(0,0,180);
		}
		if (controller == OVRInput.Controller.LTouch)
		{
			trans.Translate(0.075f, 0, 0);
			trans.Rotate(0, 180, 0);
		}

		//trans.Rotate(new Vector3(0,0,90));

		GameObject newPie = Instantiate(piePrefab, trans.position,trans.rotation);

		newPie.tag = "PlayerPie";

		return newPie;
	}
	//Tableの上に生成する用
	public GameObject Generate(Transform _trans){
		Transform trans = _trans;
		trans.Translate(0, piePrefab.transform.position.y, 0);
		GameObject newPie = Instantiate(piePrefab,trans);
		return newPie;
	}
}
