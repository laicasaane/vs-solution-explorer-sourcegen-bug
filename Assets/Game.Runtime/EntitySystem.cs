using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Game.Assets.Game.Runtime
{
    public struct ComponnetA : IComponentData
    {
        public int data;
    }

    [BurstCompile]
    internal partial struct EntitySystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            var query = SystemAPI.QueryBuilder()
                .WithAll<ComponnetA>()
                .Build();

            state.RequireForUpdate(query);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (componentA, entity) in SystemAPI.Query<ComponnetA>().WithEntityAccess())
            {
                FixedString128Bytes fs = default;
                fs.Append(entity.ToFixedString());
                fs.Append(':');
                fs.Append(' ');
                fs.Append(componentA.data);
                UnityEngine.Debug.Log(fs);
            }

            state.Dependency = new IncreaseComponentAJob().Schedule(state.Dependency);
        }

        [BurstCompile]
        public partial struct IncreaseComponentAJob : IJobEntity
        {
            private void Execute(ref ComponnetA componentA)
            {
                componentA.data++;
            }
        }
    }
}
