using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popkoControl : MonoBehaviour
{
	//Platform movement speed.平台移动速度
	public float speed;

	//This is the position where the platform will move.平台移动的位置
	public Transform MovePosition;//创建一个空物体作为移动的位置

	private Vector3 StartPosition;
	private Vector3 EndPosition;
	private bool OnTheMove;

	// Use this for initialization
	void Start()
	{
		//Store the start and the end position. Platform will move between these two points.储存左右两端点位置
		//StartPosition = this.transform.position;
	//	EndPosition = MovePosition.position;
	}

	void FixedUpdate()
	{

		float step = speed * Time.deltaTime;

        if (OnTheMove == false)
        {
			

		}

		if (OnTheMove == false)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, EndPosition, step);
		}
		else
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, StartPosition, step);
		}

		//When the platform reaches end. Start to go into other direction.
		if (this.transform.position.x == EndPosition.x && this.transform.position.y == EndPosition.y && OnTheMove == false)
		{
			OnTheMove = true;
		}
		else if (this.transform.position.x == StartPosition.x && this.transform.position.y == StartPosition.y && OnTheMove == true)
		{
			OnTheMove = false;
		}
	}

}
