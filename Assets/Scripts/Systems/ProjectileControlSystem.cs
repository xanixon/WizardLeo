using Leopotam.Ecs;
using UnityEngine;

public class ProjectileControlSystem : IEcsRunSystem
{
    private EcsFilter<Projectile> _filter;
    public void Run()
    {
        foreach(int i in _filter)
        {
            ref Projectile proj = ref _filter.Get1(i);

            Vector3 position = proj.ProjectileGO.transform.position;
            position += proj.Direction * proj.ProjectileSpeed * Time.deltaTime;
            proj.ProjectileGO.transform.position = position;

            Vector3 lastFrameMovement = position - proj.PrevPosition;
            RaycastHit hitInfo;
            bool hit = Physics.SphereCast(proj.PrevPosition, 
                                          proj.ProjectileRadius, 
                                          lastFrameMovement.normalized, 
                                          out hitInfo, 
                                          lastFrameMovement.magnitude);

            if(hit)
            {
                ref EcsEntity projEntity = ref _filter.GetEntity(i);
                ref ProjectileHit projHit = ref projEntity.Get<ProjectileHit>();
                projHit.HitInfo = hitInfo;
            }
            proj.PrevPosition = position;
        }
    }
}
