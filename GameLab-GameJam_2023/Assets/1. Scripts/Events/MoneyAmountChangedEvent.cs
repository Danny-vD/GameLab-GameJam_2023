using VDFramework.EventSystem;

namespace Events
{
	public class MoneyAmountChangedEvent : VDEvent<MoneyAmountChangedEvent>
	{
		public int Delta { get; private set; }
		public int CurrentMoney { get; private set; }
		
		public MoneyAmountChangedEvent(int delta, int currentAmount)
		{
			Delta        = delta;
			CurrentMoney = currentAmount;
		}
	}
}