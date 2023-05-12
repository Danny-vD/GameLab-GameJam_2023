using UnityEngine.SceneManagement;
using VDFramework;

namespace UI.Menu
{
	public class UIFunctionality : BetterMonoBehaviour
	{
		public static void LoadScene(int index)
		{
			SceneManager.LoadScene(index);
		}

		public static void GoToMainMenu()
		{
			LoadScene(0);
		}

		public static void LoadLevel()
		{
			LoadScene(1);
		}
		
		public static void GoToEndScreen()
		{
			LoadScene(2);
		}
	}
}
