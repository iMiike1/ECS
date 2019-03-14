using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

namespace Assets.ECS_ASSETS.Hybrid
{
    public class PlayerMovementSystem : ComponentSystem
    {
        private struct Group
        {
            public Transform Transform;
            public PlayerInput PlayerInput;
            public Speed Speed;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Group>())
            {
                var position = entity.Transform.position;
                var rotation = entity.Transform.rotation;

                position.x += entity.Speed.value * entity.PlayerInput.Horizontal * Time.deltaTime;
                rotation.w = math.clamp(entity.PlayerInput.Horizontal, -0.5f, 0.5f);

                entity.Transform.position = position;
                entity.Transform.rotation = rotation;
                
            }
        }

    }
}
