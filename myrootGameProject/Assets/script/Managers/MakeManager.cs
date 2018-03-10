﻿using UnityEngine;
using System.Collections;

public class MakeManager : MonoBehaviour {//オブジェクト生成を行うクラス。
	
	float blocklength = Config.blocklength;
	private GameObject goalobject;
	private GameObject playerobject;
	private int slidespace = 4;
	float groundhight;
	float instancehight;
	public GameObject ground;
	[SerializeField]DataManager datamanager;
	public GameObject[] instanceObjects;
	[SerializeField]GameObject [] makedraggerdobjects;
	public GameObject[] _LeftCountbuttons;

	void Start() {
		groundhight = ground.transform.position.y;
		instancehight = groundhight + 0.5f;
	}


	void Update() {
		if (Input.GetMouseButtonDown(0)) {
		}
	}

	public void instanciateAllObject(int[,] aPrefabKind) {
		for (int j = 0; j < aPrefabKind.GetLength(1); ++j) {
			for (int i = 0; i < aPrefabKind.GetLength(0); ++i) {
				if (aPrefabKind[i, j] == 0) {
				}
				else if (aPrefabKind[i, j] == 1) {
					Instantiate(instanceObjects[aPrefabKind[i, j]], settingObjectPos(i, j, instancehight), Quaternion.identity);
				}
				else if (aPrefabKind[i, j] == 2) {//プレイヤーオブジェクトを生成する時はプレイヤーオブジェクトの参照を保持
					playerobject = Instantiate(instanceObjects[aPrefabKind[i, j]], settingObjectPos(i, j, instancehight), Quaternion.identity) as GameObject;
				}
				else if (aPrefabKind[i, j] == 3) {//ゴールオブジェクトを生成する時はゴールオブジェクトの参照を保持
					goalobject = Instantiate(instanceObjects[aPrefabKind[i, j]], settingObjectPos(i, j, instancehight), Quaternion.identity) as GameObject;
				}

			}
		}
	}
	public void makeDraggedObject() {
		for(int i = 0;i < makedraggerdobjects.Length;i++ ) {
			makedraggerdobjects[i] = Instantiate(makedraggerdobjects[i], makedraggerdobjects[i].GetComponent<Transform>().position, Quaternion.identity)as GameObject;
		}
	}

	public GameObject getPlayerObject() {
		return playerobject;
	}
	public GameObject getGoalObject() {
		return goalobject;
	}


	Vector3 settingObjectPos(int x, int y,float z)
	{
		Vector3 returnPos = new Vector3(x * blocklength, z, y * blocklength);
		return returnPos;
	}
	public float getObjecthight() {
		return instancehight;
	}
	public float getBlockLength(){
		return blocklength;
	}
	public GameObject getInstanceObject(int index) {
		return instanceObjects[index];
	}
	public GameObject InstanciateandGetRef(int onjectindex,Vector3 instancepos) {
		GameObject objectref;
		objectref = Instantiate(getInstanceObject(onjectindex), instancepos, Quaternion.identity) as GameObject;
		return objectref;

	}
	public void makeleftbutton(Transform parenttransform)
	{
		for (int i = 0; i < _LeftCountbuttons.Length; i++)
		{
			_LeftCountbuttons[i] = Instantiate(_LeftCountbuttons[i], _LeftCountbuttons[i].GetComponent<Transform>().position, Quaternion.identity) as GameObject;
			_LeftCountbuttons[i].transform.parent = parenttransform;
		}
	}

}

