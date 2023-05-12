using System.Globalization;
using Gameplay;
using TMPro;
using VDFramework;

namespace UI.Menu.EndScreen
{
	public class MoneyRemainingCount : BetterMonoBehaviour
	{
		private TMP_Text label;
		
		private void Awake()
		{
			label = GetComponent<TMP_Text>();

			label.text = GameplayStats.Money.ToString("N0", CultureInfo.CreateSpecificCulture("en-US"));
		}
	}
}