﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

public class setObject
{
	Vector3 mypos;
	public setObject(int x,int y)
	{
		mypos.x = x;
		mypos.y = y;
	}
	public Vector3 returnPos() {
		return mypos;
	}

}
