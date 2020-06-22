using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Teleporter : MonoBehaviour
{
	[SerializeField]
	private int _mapIndex;
	[SerializeField]
	private Vector3 _position;

	public void resetState()
	{
		this.gameObject.SetActive(true);
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag != "Player")
			return;

		if (!Input.GetKey(KeyCode.E))
			return;

		if (Fader.Instance.Fading)
			return;

		SFXManager.Instance.playDoor();
		MapLoader.Instance.changeMap(this._mapIndex, () => Player.Instance.transform.position = this._position);

		this.gameObject.SetActive(false);
	}
}
