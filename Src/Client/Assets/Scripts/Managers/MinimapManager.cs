using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using UnityEngine;

namespace Managers
{
    class MinimapManager : Singleton<MinimapManager>
    {
        public UIMinimap minimap;
        private Collider minimapBoundingBox;
        public Collider MinimapBuildingBox
        {
            get { return minimapBoundingBox; }
        }
        public Transform PlayerTansform
        {
            get
            {
                if (User.Instance.CurrentCharacter==null)
                    return null;
                return User.Instance.CurrentCharacterObject.transform;

            }

        }

        public Sprite LoadSpriteMinimap()
        {
            return Resloader.Load<Sprite>("UI/Minimap/" + User.Instance.CurrentMapData.MiniMap);
        }

        public void UpdateMinimap(Collider minimapBoundingBox)
        {
            this.minimapBoundingBox = minimapBoundingBox;
            if (this.minimap!=null)
            {
                this.minimap.UpdateMap();
            }
        }
    }
}
