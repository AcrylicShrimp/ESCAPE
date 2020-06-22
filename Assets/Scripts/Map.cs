using UnityEngine;

public class Map : MonoBehaviour
{
	[SerializeField]
	private Object _floor;
	[SerializeField]
	private int _length;

	private void Awake()
	{
		for (int count = 0; count < this._length; ++count)
			GameObject.Instantiate(this._floor, new Vector3(count * 2f, 0f, 0f), Quaternion.identity, this.transform);
	}
}
