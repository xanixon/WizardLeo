using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellMediator : MonoBehaviour
{
    public EcsEntity PlayerEntity;

    public void Cast()
    {
        if(PlayerEntity.IsAlive())
           PlayerEntity.Get<Cast>();
    }


}
