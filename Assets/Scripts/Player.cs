using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    public Direction Dir { get; private set; }

    [SerializeField]
    private float _speed;

    private void Awake()
    {
        this.Dir = Direction.Right;
    }

    private void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(movement) < .5f)
            return;

        this.Dir = movement < 0f ? Direction.Left : Direction.Right;
        this.transform.position += Vector3.right * movement * Time.deltaTime * this._speed;
        this.transform.localScale = new Vector3(movement < 0f ? -1f : 1f, 1f, 1f);
    }
}
