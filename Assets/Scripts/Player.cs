using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float gravity = 1.0f;
    [SerializeField]
    private float jumpHeight = 15.0f;
    public float _yVelocity;
    public bool canDoubleJump;
    public int Coin;
    private UImanager _uiManager;
    [SerializeField]
    private int _lives = 3;
    public bool _canWallJump = false;
    private Vector3 WallSurfaceNormal;
    public float pushPower = 2.0f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager =GameObject.Find("Canvas").GetComponent<UImanager>();
        _uiManager.UpdateCoinDisplay(Coin);
        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if(_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = jumpHeight;
                canDoubleJump = true;
                _canWallJump = true;
            }
            
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && !_canWallJump)
            {
                _yVelocity += jumpHeight;
                canDoubleJump = false;
            }

            if(Input.GetKeyDown(KeyCode.Space) && _canWallJump)
            {
                _yVelocity = jumpHeight;
                velocity = WallSurfaceNormal * _speed;
            }
            _yVelocity -= gravity;

        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Moveable")
        {
            Rigidbody box = hit.collider.GetComponent<Rigidbody>();
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
            box.velocity = pushDirection * pushPower;
        }

        if(!_controller.isGrounded && hit.transform.tag =="Wall")
        {
            WallSurfaceNormal = hit.normal;
            _canWallJump = true;
        }
        Debug.DrawRay(hit.point, hit.normal, Color.blue);
    }

    public void AddCoin()
    {
        Coin++;
        _uiManager.UpdateCoinDisplay(Coin);
    }

    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLivesDisplay(_lives);
        if(_lives<1)
        {
            SceneManager.LoadScene(0);
        }
    }

    public int CoinCount()
    {
        return Coin;
    }


}
