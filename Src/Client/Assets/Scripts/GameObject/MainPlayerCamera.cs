using Models;
using UnityEngine;

namespace Assets.Scripts.GameObject
{
    public class MainPlayerCamera : MonoSingleton<MainPlayerCamera>
    {
        public Camera camera;
        public Transform viewPoint;

        public UnityEngine.GameObject player;
        // Use this for initialization
	

        private void LateUpdate()
        {
            if (player == null)
            {
                player = User.Instance.CurrentCharacterObject;
            }
            if (player == null)
                return;

            this.transform.position = player.transform.position;
            this.transform.rotation = player.transform.rotation;
        }
    }
}
