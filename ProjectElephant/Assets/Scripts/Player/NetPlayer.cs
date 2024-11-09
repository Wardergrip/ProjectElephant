using UnityEngine;
using Mirror;

namespace Elephant
{
    public class NetPlayer : NetworkBehaviour
    {
        [SerializeField] private NetworkBehaviour _pawnToSpawn;
    }
}