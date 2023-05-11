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
			resetCommand = new Command("Reset", ReloadScene);
			resetCommand.AddAlias("reset");
			resetCommand.SetHelpMessage("Reload the current scene");
			
			CommandManager.AddCommand(resetCommand);
		}

		private static void ReloadScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		private void OnDestroy()
		{
			CommandManager.RemoveCommand(resetCommand);
		}
	}
}