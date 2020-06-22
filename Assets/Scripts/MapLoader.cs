using System;

using UnityEngine;

public class MapLoader : MonoBehaviour
{
	public static MapLoader Instance { get; private set; }

	public Map CurrentMap { get; private set; }

	[SerializeField]
	private GameObject[] _mapPrefabs;

	private Map[] maps;

	private void Awake()
	{
		this.maps = new Map[this._mapPrefabs.Length];

		if (this.maps.Length == 0)
			throw new Exception("no map found!");

		for (int count = 0; count < this.maps.Length; ++count)
		{
			GameObject mapObject = GameObject.Instantiate(this._mapPrefabs[count], Vector3.zero, Quaternion.identity, this.transform);
			mapObject.SetActive(false);

			Map map = mapObject.GetComponent<Map>();

			this.maps[count] = map;
		}

		(this.CurrentMap = this.maps[0]).gameObject.SetActive(true);

		foreach (var teleporter in this.CurrentMap.GetComponentsInChildren<Teleporter>(true))
			teleporter.resetState();

		MapLoader.Instance = this;
	}

	public void changeMap(int mapIndex, Action callback)
	{
		Fader.Instance.doFadeOut(() =>
		{
			this.CurrentMap.gameObject.SetActive(false);
			(this.CurrentMap = this.maps[mapIndex]).gameObject.SetActive(true);

			foreach (var teleporter in this.CurrentMap.GetComponentsInChildren<Teleporter>(true))
				teleporter.resetState();

			callback?.Invoke();

			Fader.Instance.doFadeIn(null);
		});
	}
}
