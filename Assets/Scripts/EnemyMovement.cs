using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private DisableTrigger _target;
    private SpriteRenderer _spriteRenderer;

    private bool _isFlipped = false;

    private float _speed = 5f;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _target = FindObjectOfType<DisableTrigger>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveLeft = -1f;
        float moveRight = 1f;

        float direction = transform.position.x > _target.transform.position.x  ?  moveLeft: moveRight;

        if (direction == moveLeft && _isFlipped == false)
        {
            _isFlipped = true;
            _spriteRenderer.flipX = true;
        }

         transform.Translate(_speed * direction * Time.deltaTime, 0, 0); 
    }
}
