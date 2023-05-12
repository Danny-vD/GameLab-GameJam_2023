using System;
using Console.Commands;
using Singletons;
using VDFramework;

namespace Commands
{
	public class PauseGameTimer : BetterMonoBehaviour
	{
		private AbstractCommand pauseCommand;
		private AbstractCommand resumeCommand;
		
		private void Start()
		{
			pauseCommand = new Command("Pause", PauseTimer);
			pauseCommand.AddAlias("pause");
			pauseCommand.SetHelpMessage("Pause the game timer");

			resumeCommand = new Command("Resume", ResumeTimer);
			resumeCommand.AddAlias("resume");
			resumeCommand.SetHelpMessage("Resume the game timer");
			
			CommandManager.AddCommand(pauseCommand);
			CommandManager.AddCommand(resumeCommand);
		}

		private static void PauseTimer()
		{
			GameTimerManager.Instance.TimerHandle.SetPause(true);
		}

		private static void ResumeTimer()
		{
			GameTimerManager.Instance.TimerHandle.SetPause(false);
		}

		private void OnDestroy()
		{
			CommandManager.RemoveCommand(resumeCommand);
			CommandManager.RemoveCommand(pauseCommand);
		}
	}
}