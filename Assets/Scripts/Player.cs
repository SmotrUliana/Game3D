using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private Camera _playerCamera;

    private Rigidbody _rigidbody;
    [SerializeField]
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.3f);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = _playerCamera.transform.forward * move.z + _playerCamera.transform.right * move.x;
        move.y = 0f;

        if (move.magnitude > 0.1f)
        {
            // Move and rotate the player
            _rigidbody.MovePosition(_rigidbody.position + move * _speed * Time.deltaTime);
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

}