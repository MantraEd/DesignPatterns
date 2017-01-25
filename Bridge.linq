<Query Kind="Program" />

void Main()
{
//The Bridge pattern is designed to separate a class's interface from its implementation so you can vary or replace the implementation without changing the client code.

//* The intent of this pattern is to decouple abstraction from implementation so that the two can vary independently.

	        ITelevision philipsTV = new PhilipsTV();
            RemoteController remoteController = new RemoteController();
            remoteController.SetTelevision(philipsTV);

            remoteController.On();
            remoteController.ChangeChannel(10);
            remoteController.GoNextChannel();
            remoteController.Off();
			
					
			
	        SonyTV sonyTV = new SonyTV();
            remoteController.SetTelevision(sonyTV);

            remoteController.On();
            remoteController.ChangeChannel(30);
            remoteController.GoNextChannel();
            remoteController.Off();
}

// Define other methods and classes here
    public interface ITelevision
    {
        string BrandName { get; }

        void SwitchOn();
        void SwitchOff();
        void TuneChannel(int channel);
    }

    public class SonyTV : ITelevision
    {
        public SonyTV()
        {
            Console.WriteLine("Invoked " + BrandName);
        }

        public string BrandName
        {
            get { return "Sony"; }
        }

        public void SwitchOn()
        {
            Console.WriteLine("Switched On Sony TV");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Switching Off Sony TV");
        }

        public void TuneChannel(int channel)
        {
            Console.WriteLine("Sony TV: Channel changed to " + channel);
        }
    }

    public class PhilipsTV : ITelevision
    {
        public PhilipsTV()
        {
            Console.WriteLine("Invoked " + BrandName);
        }

        public string BrandName
        {
            get { return "Philips"; }
        }

        public void SwitchOn()
        {
            Console.WriteLine("Switched On Philips TV");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Switching Off Philips TV");
        }

        public void TuneChannel(int channel)
        {
            Console.WriteLine("Philips TV: Channel changed to " + channel);
        }
    }

    public abstract class RemoteControl
    {
        protected ITelevision _Television;

		public void SetTelevision(ITelevision television)
		{
			this._Television = television;
		}

        public void On()
        {
            _Television.SwitchOn();
        }

        public void Off()
        {
            _Television.SwitchOff();
        }

        public virtual void ChangeChannel(int channel)
        {
            _Television.TuneChannel(channel);
        }
    }

    public class RemoteController : RemoteControl
    {
        private int _CurrentChannel;

        public override void ChangeChannel(int channel)
        {
            _CurrentChannel = channel;
            Console.WriteLine(_Television.BrandName + ": Switched Channel to " + _CurrentChannel);
        }

        public void GoNextChannel()
        {
            _Television.TuneChannel(++_CurrentChannel);
        }

        public void GoPreviousChannel()
        {
            _Television.TuneChannel(--_CurrentChannel);
        }
    }
