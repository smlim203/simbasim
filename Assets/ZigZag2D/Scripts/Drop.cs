using UnityEngine;
using System.Collections;

namespace TunnelGame
{
	public class Drop : MonoBehaviour
	{
		#region Inspector Variables

		[SerializeField] private float collisionSize;
		[SerializeField] private ParticleSystem disappearParticle;

		#endregion

		#region Properties

		public float CollisionSize { get { return collisionSize; } }

		public void Disappear()
        {
			var particalSystem = Instantiate(this.disappearParticle, this.transform.position, Quaternion.identity);
			Destroy(particalSystem.gameObject, 1);
		}
		
		#endregion
	}
}
