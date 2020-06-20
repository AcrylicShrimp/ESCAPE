using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private float _lead;

    private void LateUpdate()
    {
        var lead = this._lead;

        if (this._player.Dir == Player.Direction.Left)
            lead = -lead;

        var position = this.transform.position;
        position.x = this._player.transform.position.x + lead;
        this.transform.position = position;
    }
}
