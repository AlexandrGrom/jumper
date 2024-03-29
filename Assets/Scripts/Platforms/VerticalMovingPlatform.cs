﻿using UnityEngine;

public class VerticalMovingPlatform : Platform
{
    private float randomnes;
    private Vector3 startPosition;

    void Awake()
    {
        OnStartGame();
        startPosition = transform.position;
        randomnes = Random.Range(0f, 1f);
    }


    void Update()
    {
        if (!isAction) return;

        float floatingValue = Mathf.Sin(Time.time + randomnes);
        transform.position = new Vector3(startPosition.x , startPosition.y + floatingValue, startPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnCollisionPlatformBehaviour(player);
        }
    }

    protected override void OnCollisionPlatformBehaviour(Player player)
    {
        base.OnCollisionPlatformBehaviour(player);
    }

    public override void Reinitialize(Vector3 newPosition)
    {
        startPosition = newPosition;
    }

}
