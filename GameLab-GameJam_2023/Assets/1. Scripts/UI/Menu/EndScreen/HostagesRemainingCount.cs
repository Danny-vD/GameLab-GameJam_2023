using Gameplay;
using TMPro;
using VDFramework;

namespace UI.Menu.EndScreen
{
	public class HostagesRemainingCount : BetterMonoBehaviour
	{
		private TMP_Text label;
		
		private void Awake()
		{
			label = GetComponent<TMP_Text>();

			label.text = GameplayStats.Hostages.ToString();
		}
	}
}