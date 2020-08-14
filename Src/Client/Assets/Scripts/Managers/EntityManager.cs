using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using SkillBridge.Message;

namespace Assets.Scripts.Managers
{
    interface IEntityNotify
    {
        void OnEntityRemove();
        void OnEntityChanged(Entity entity);
        void OnEntityEvent(EntityEvent @event);
    }
    class EntityManager:Singleton<EntityManager>
    {
        Dictionary<int,Entity> entities=new Dictionary<int, Entity>();
        Dictionary<int,IEntityNotify> notiflies=new Dictionary<int, IEntityNotify>();

        public void RegisterEntityCharacterNotify(int entityId,IEntityNotify notify)
        {
            this.notiflies[entityId] = notify;
        }

        public void AddEntity(Entity entity)
        {
            entities[entity.entityId] = entity;
        }

        public void RemoveEntity(NEntity entity)
        {
            this.entities.Remove(entity.Id);
            if (notiflies.ContainsKey(entity.Id))
            {
                notiflies[entity.Id].OnEntityRemove();
                notiflies.Remove(entity.Id);
            }
        }

        internal void OnEntitySync(NEntitySync data)
        {
            Entity entity = null;
            entities.TryGetValue(data.Id, out entity);
            if (entity!=null)
            {
                if (data.Entity!=null)
                {
                    entity.EntityData = data.Entity;
                    if (notiflies.ContainsKey(data.Id))
                    {
                        notiflies[entity.entityId].OnEntityChanged(entity);
                        notiflies[entity.entityId].OnEntityEvent(data.Event);
                    }
                }
            }
        }
    }
}
