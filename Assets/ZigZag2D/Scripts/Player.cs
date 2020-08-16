using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TunnelGame
{
	public class Player : MonoBehaviour
	{
		public enum PlayerType : int
		{
			None = 0,
			Blue = 1,
			Red,
			Star,
			Target,
		}

		#region Inspector Variables

		[SerializeField] private float collisionSize;

		[SerializeField] private PlayerType type;
		[SerializeField] private ParticleSystem feverParticle;

		#endregion

		#region Properties

		public float CollisionSize { get { return collisionSize; } }
		public PlayerType Type { get { return this.type; } protected set { this.type = value; } }

		public void AppearParticle()
        {
			var feverParticle = Instantiate(this.feverParticle, this.transform.position, Quaternion.identity);
			Destroy(feverParticle.gameObject, 1);
		}

		public void PlayerAbility(List<Drop> drops, float deltaTime)
        {
			switch (this.type)
            {
				case PlayerType.Star: this.MagnetAbility(drops, deltaTime);
					break;
            }
        }

		private void MagnetAbility(List<Drop> drops, float deltaTime)
        {
			foreach (var drop in drops)
			{
				// check range
				var distance = Vector2.Distance((this.transform.position), (drop.transform.position));
				if (distance < 40.0f)
				{
					// move
					var pos = Vector2.MoveTowards(drop.transform.position, this.transform.position, 1+(10 * Time.deltaTime));
					drop.transform.position = pos;

					//drop.transform.position += (this.transform.position - drop.transform.position).normalized * Time.deltaTime;
				}
			}
		}

		#endregion
	}
}
