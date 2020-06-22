using System.Collections.Generic;

using UnityEngine;

public class Enemy : MonoBehaviour
{
	public static List<Enemy> Enemies { get { return Enemy.enemies; } }
	private static List<Enemy> enemies = new List<Enemy>();

	private void OnEnable()
	{
		Enemy.enemies.Add(this);
	}

	private void OnDisable()
	{
		Enemy.enemies.Remove(this);
	}
}
