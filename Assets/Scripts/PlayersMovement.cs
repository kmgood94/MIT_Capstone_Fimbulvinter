using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayersMovement : MonoBehaviour
{
    //variables
    public float PlayersMovementSpeed; //this is players movement speed.
    private float _playersMovementDirection = 0; //this will give the direction of the players movement.
    private Fimbulvinter_Controls _inputActionReference; // reference of the generated c# script form the input action
    private Rigidbody2D _playersRigidBody; //reference of the players rigid body.


    private void Start()
    {
        //Getting the reference of the players rigid body.
        _playersRigidBody ??= GetComponent<Rigidbody2D>();

        _inputActionReference = new Fimbulvinter_Controls();
        //enabling the Input actions
        _inputActionReference.Enable();
        //reading the values of the player movement direction for the players movement.
        _inputActionReference.Gameplay.Move.performed += moving =>
        {
            _playersMovementDirection = moving.ReadValue<float>();
        };
    }


    private void FixedUpdate()
    {
        //Moving player using player rigid body.
        _playersRigidBody.velocity =
            new Vector2(_playersMovementDirection * PlayersMovementSpeed, _playersRigidBody.velocity.y);
    }

}
