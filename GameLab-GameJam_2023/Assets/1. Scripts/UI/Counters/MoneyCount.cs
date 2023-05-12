using System.Globalization;
using Events;
using TMPro;
using VDFramework;

namespace UI.Counters
{
	public class MoneyCount : BetterMonoBehaviour
	{
		private TMP_Text moneyLabel;

		private void Awake()
		{
			moneyLabel = GetComponent<TMP_Text>();

			MoneyAmountChangedEvent.Listeners += UpdateUI;
		}

		private void UpdateUI(MoneyAmountChangedEvent moneyAmountChangedEvent)
		{
			moneyLabel.text = moneyAmountChangedEvent.CurrentMoney.ToString("N0", CultureInfo.CreateSpecificCulture("en-US"));
		}

		private void OnDestroy()
		{
			MoneyAmountChangedEvent.Listeners -= UpdateUI;
		}
	}
}