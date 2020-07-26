using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TunnelGame
{
	public class GameUI : MonoBehaviour
	{
		#region Inspector Variables

		[SerializeField] private Camera			gameCamera;
		[SerializeField] private Canvas			parentCanvas;
		[SerializeField] private Text			currentScoreText;
		[SerializeField] private Text			currentDropAmountText;
		[SerializeField] private RectTransform 	highScoreMarker;
		[SerializeField] private RectTransform 	averageScoreMarker;
		[SerializeField] private Text			highScoreMarkerText; 
		[SerializeField] private Text			averageScoreMarkerText; 
		
		#endregion

		#region Member Variables

		private float scale;

		#endregion

		#region Unity Methods

		private void Start()
		{
			scale = (parentCanvas.transform as RectTransform).rect.height / Utilities.WorldHeight(gameCamera);
		}

		private void OnDisable()
		{
			highScoreMarker.gameObject.SetActive(false);
			averageScoreMarker.gameObject.SetActive(false);
			
			UpdateUI();
		}

		private void Update()
		{
			UpdateUI();
		}

		#endregion

		#region Private Methods

		private void UpdateUI()
		{
			int highScore		= GameManager.Instance.HighScore;
			int averageScore	= GameManager.Instance.AverageScore;

			highScoreMarker.gameObject.SetActive(highScore != 0);
			averageScoreMarker.gameObject.SetActive(averageScore != 0 && averageScore != highScore);

			currentScoreText.text		= GameManager.Instance.CurrentScore.ToString();
			this.currentDropAmountText.text = GameManager.Instance.CurrentDropsAmount.ToString();
			highScoreMarkerText.text	= "High: " + highScore;
			averageScoreMarkerText.text	= "Average: " + averageScore;

			highScoreMarker.anchoredPosition	= new Vector2(highScoreMarker.anchoredPosition.x, GameManager.Instance.HighScoreYPos * scale);
			averageScoreMarker.anchoredPosition	= new Vector2(averageScoreMarker.anchoredPosition.x, GameManager.Instance.AverageScoreYPos * scale);
		}

		#endregion
	}
}
