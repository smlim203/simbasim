﻿using UnityEngine;
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
		}

		#region Inspector Variables

		[SerializeField] private float collisionSize;

		[SerializeField] private PlayerType type;

		#endregion

		#region Properties

		public float CollisionSize { get { return collisionSize; } }

		public void PlayerAbility(List<Drop> drops)
        {
			switch (this.type)
            {
				case PlayerType.Blue: this.MagnetAbility(drops);
					break;
            }
        }

		private void MagnetAbility(List<Drop> drops)
        {
			foreach (var drop in drops)
			{
				// check range
				var distance = Vector2.Distance((this.transform.position), (drop.transform.position));
				if (distance < 40.0f)
				{
					// move
					var pos = Vector2.MoveTowards(drop.transform.position, this.transform.position, 1);
					drop.transform.position = pos;
				}
			}
		}

		#endregion
	}
}
