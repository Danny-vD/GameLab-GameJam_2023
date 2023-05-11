using Console.Commands;
using UnityEngine.SceneManagement;
using VDFramework;

namespace Player
{
	public class ResetScene : BetterMonoBehaviour
	{
		private AbstractCommand resetCommand;

		private void Start()
		{
			resetCommand = new Command("Reset", SetPositionToOriginal);
			resetCommand.AddAlias("reset");
			
			CommandManager.AddCommand(resetCommand);
		}

		private static void SetPositionToOriginal()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		private void OnDestroy()
		{
			CommandManager.RemoveCommand(resetCommand);
		}
	}
}