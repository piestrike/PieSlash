﻿using UnityEngine;
using System.Collections;

public class SearchCharacter : MonoBehaviour
{
    private MoveEnemy moveEnemy;
    public GameObject target;
    public bool OnArea = false;
    public GameObject PIE;
    public GameObject Pond;
    public bool attackflag;
    public bool pieflag;
<<<<<<< HEAD
    public int PIEgaege = 100;
=======
	CharacterStatus status;

>>>>>>> 895241d... 2019/10/02の作業分

    private GameObject HitRange;

    //　経過時間
    private float elapsedTime;
    //　攻撃した後のフリーズ時間
    [SerializeField]
    private float freezeTime = 1.5f;
<<<<<<< HEAD
    public float PieSpeed;

    void Start()
    {
        moveEnemy = GetComponent<MoveEnemy>();
=======

    void Start()
    {
		status = transform.root.GetComponent<CharacterStatus>();
		moveEnemy = transform.root.GetComponent<MoveEnemy>();
>>>>>>> 895241d... 2019/10/02の作業分
        attackflag = true;
        pieflag = true;
        elapsedTime = 0f;
    }
    void Update()
    {
<<<<<<< HEAD
        if(PIEgaege >= 25)
        {
            this.gameObject.GetComponent<BoxCollider>().size = new Vector3(25, 1, 20);
=======
		if(status.pieCream >= 25)
        {
            //this.gameObject.GetComponent<BoxCollider>().size = new Vector3(25, 1, 20);
>>>>>>> 895241d... 2019/10/02の作業分
        }
        if (attackflag == true && OnArea == true)
        {
            //PIE.GetComponent<Rigidbody>().AddForce(target.transform.position.x/10, target.transform.position.y / 10, target.transform.position.z / 10);
            attackflag = false;
        }
<<<<<<< HEAD
        if (PIEgaege >= 25 && pieflag == true && OnArea == true)
        {
            PIE.transform.position = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 1.5f, this.transform.position.z);
            GameObject PIEs = Instantiate(PIE) as GameObject;
            PIEs.GetComponent<Rigidbody>().velocity = transform.forward * PieSpeed;
            pieflag = false;
            PIEgaege -= 5;
        }
        if(PIEgaege < 25)
        {
            this.gameObject.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
=======
		if (status.pieCream >= 25 && pieflag == true && OnArea == true)
        {
			Transform trans = transform;
			trans.position = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 1.5f, this.transform.position.z);
			trans.Rotate(0,90,0);

			//GameObject PIEs = Instantiate(PIE) as GameObject;
			GameObject PIEs = Instantiate(PIE,trans);
			PIEs.tag = "EnemyPie";
			PIEs.GetComponent<Rigidbody>().velocity = transform.forward * status.throwSpeed;
            pieflag = false;
			status.pieCream -= 5;

		}
		if(status.pieCream < 25)
        {
            //this.gameObject.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
>>>>>>> 895241d... 2019/10/02の作業分
            MoveEnemy.EnemyState state = moveEnemy.GetState();
            if (state == MoveEnemy.EnemyState.Wait || state == MoveEnemy.EnemyState.Walk)
            {
                moveEnemy.SetState(MoveEnemy.EnemyState.Chase, Pond.transform.transform);                
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        //　プレイヤーキャラクターを発見
<<<<<<< HEAD
        if (col.tag == "Player" && PIEgaege >= 25)
=======
		if (col.tag == "Player" && status.pieCream >= 25)
>>>>>>> 895241d... 2019/10/02の作業分
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > freezeTime)
            {
                elapsedTime = 0.0f;
                pieflag = true;
            }
            //　敵キャラクターの状態を取得
            MoveEnemy.EnemyState state = moveEnemy.GetState();
            //　敵キャラクターが追いかける状態でなければ追いかける設定に変更
            if (state == MoveEnemy.EnemyState.Wait || state == MoveEnemy.EnemyState.Walk)
            {
                moveEnemy.SetState(MoveEnemy.EnemyState.Chase, col.transform);
            }
            transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
            OnArea = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("見失う");
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
            OnArea = false;
        }
    }
<<<<<<< HEAD
    void OnTriggerEnter(Collider col)
    {        
        if (col.tag == "Pond" && PIEgaege < 25)
        {
            PIEgaege = 100;
=======
	//要　変更検討
    void OnTriggerEnter(Collider col)
    {        
		if (col.tag == "Pond" && status.pieCream < 25)
        {
			status.pieCream = status.maxPieCream;
>>>>>>> 895241d... 2019/10/02の作業分
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
        }
    }
}



