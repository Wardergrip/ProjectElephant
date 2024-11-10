using UnityEngine;
using Mirror;

namespace Elephant
{
    public class NetPlayer : NetworkBehaviour
    {
        [SerializeField] private NetworkBehaviour _pawn;

        [Client]
        private void OnEnable()
        {
            if (GameCamera.Active != null)
            {
                GameCamera.Active.ToFollow = _pawn.transform;
            }
        }

        private void Update()
        {
            if (isClient)
            {
                ClientUpdate();
            }
        }

        [Client]
        private void ClientUpdate()
        {
            if (Input.GetKey(KeyCode.W)) 
            {
                RPC_MoveInput(Vector3.forward);
            }
            if (Input.GetKey(KeyCode.S)) 
            {
                RPC_MoveInput(Vector3.back);
            }
            if (Input.GetKey(KeyCode.A)) 
            {
                RPC_MoveInput(Vector3.left);
            }
            if (Input.GetKey(KeyCode.D)) 
            {
                RPC_MoveInput(Vector3.right);
            }
        }

        [Command]
        private void RPC_MoveInput(Vector3 direction)
        {
            transform.position += direction * Time.deltaTime;
        }
    }
}